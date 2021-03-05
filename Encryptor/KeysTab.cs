using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryptor
{
	public partial class KeysTab : UserControl
	{
		public static KeysTab instance;

		#region Constructor

		public KeysTab()
		{
			InitializeComponent();
		}

		public void KeysTab_Load()
		{
			instance = this;

			KeysList.AllowUserToAddRows = false;
			KeysList.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
			KeysList.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;

			UpdateKeysList();
			ResizeTexts();
			KeyInfoDisplay.DisplayKeyInfo(false);
		}

		#endregion

		#region Keys List Methods

		private void KeysList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var grid = sender as DataGridView;

			if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
			{
				if (e.ColumnIndex == 1)
				{
					RSAEncryptor.OpenKeyEdit(true, RSAEncryptor.keys[e.RowIndex]);
				}
				else if (e.ColumnIndex == 2)
				{
					RSAEncryptor.RemoveKey(e.RowIndex);
					grid.Rows.RemoveAt(e.RowIndex);
					KeysList.ClearSelection();
					UpdateItemsSize();
				}
			}
		}

		private void KeysList_SelectionChanged(object sender, EventArgs e)
		{
			if (KeysList.SelectedCells.Count > 0)
			{
				KeyInfoDisplay.SetKey(RSAEncryptor.keys[KeysList.SelectedCells[0].RowIndex]);
				KeyInfoDisplay.DisplayKeyInfo(true);
			}
			else
				KeyInfoDisplay.DisplayKeyInfo(false);
		}

		public static void UpdateKeysList()
		{
			instance.KeysList.Rows.Clear();
			
			foreach(Key k in RSAEncryptor.keys)
			{
				instance.AddKey(k.KeyName);
			}

			instance.UpdateItemsSize();
			instance.KeysList.ClearSelection();
		}

		public void AddKey(string keyName)
		{
			instance.KeysList.Rows.Add(keyName, "Editar", "Remover");

			var key = instance.KeysList.Rows[instance.KeysList.RowCount - 1];

			if (instance.KeysList.RowCount % 2 == 0)
			{
				key.DefaultCellStyle.BackColor = Color.DarkGray;
			}
			else
				key.DefaultCellStyle.BackColor = Color.LightGray;
		}

		#endregion

		#region Button Methods

		private void AddKeyButton_Click(object sender, EventArgs e)
		{
			string newKeyName = RSAEncryptor.ValidateKeyName("Nova Chave");
			var key = new Key();
			key.SetName(newKeyName);
			RSAEncryptor.AddKey(key);

			AddKey(newKeyName);
			KeysList.CurrentCell = KeysList.Rows[KeysList.Rows.Count - 1].Cells[0];

			UpdateItemsSize();
		}

		private void RemoveAllButton_Click(object sender, EventArgs e)
		{
			RSAEncryptor.RemoveAllKeys();
			KeysList.Rows.Clear();
		}

		private void RevertButton_Click(object sender, EventArgs e)
		{
			RSAEncryptor.LoadKeysData();
			UpdateKeysList();
		}

		private void SaveChangesButton_Click(object sender, EventArgs e)
		{
			RSAEncryptor.SaveKeysData();
		}

		#endregion

		#region Size Methods

		private void KeysTab_SizeChanged(object sender, EventArgs e)
		{
			ResizeTexts();
			UpdateItemsSize();
		}

		private void KeysList_SizeChanged(object sender, EventArgs e)
		{
			UpdateItemsSize();
		}

		private void UpdateItemsSize()
		{
			for (int i = 0; i < KeysList.Rows.Count; i++)
			{
				var row = KeysList.Rows[i];
				row.Height = (int)(KeysList.Size.Height * 0.125f);
			}

			for (int i = 0; i < KeysList.Columns.Count; i++)
			{
				var column = KeysList.Columns[i];
				column.DefaultCellStyle.Font = new Font("Arial", RSAEncryptor.GetDynamicFontSize(15), FontStyle.Regular);

				bool isScrollbarVisible = false;

				foreach (var scroll in KeysList.Controls.OfType<VScrollBar>())
				{
					if (scroll.Visible)
					{
						isScrollbarVisible = true;
						break;
					}
				}

				int scrollWidth = isScrollbarVisible ? SystemInformation.VerticalScrollBarWidth : 0;

				if (i == 0)
					column.Width = (int)((KeysList.Size.Width - scrollWidth) * 0.6f);
				else
					column.Width = (int)((KeysList.Size.Width - scrollWidth) * 0.2f);
			}
		}

		private void ResizeTexts()
		{
			RSAEncryptor.ResizeTexts(15, KeysTabLayout);
		}

		#endregion
	}
}
