using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Encryptor
{
	public partial class RSAEncryptor : Form
	{
		public static RSAEncryptor instance;

		public static BindingList<Key> keys = new BindingList<Key>();
		public static BindingList<Key> publicKeys = new BindingList<Key>();
		public static BindingList<Key> privateKeys = new BindingList<Key>();

		public static int defaultClientHeight;

		#region Constructor

		public RSAEncryptor()
		{
			InitializeComponent();

			instance = this;
			keys.AllowEdit = true;
			keys.RaiseListChangedEvents = true;
		}

		private void RSAEncryptor_Load(object sender, EventArgs e)
		{
			LoadKeysData();

			WindowState = FormWindowState.Maximized;
			defaultClientHeight = ClientSize.Height;

			//ResizeTexts(15, EncryptorLayout);
			EncryptorTabButton_Click(this, null);
			EncryptorTab.EncryptorTab_Load();
			KeysTab.KeysTab_Load();
			KeyEditTab.KeyEditTab_Load();
			OpenKeyEdit(false);
		}

		#endregion

		#region Keys Database Methods

		public static void LoadKeysData()
		{
			string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\KeysDatabase.xml";

			if (!File.Exists(path)) return;

			XmlSerializer deserializer = new XmlSerializer(typeof(BindingList<Key>));

			using (FileStream fs = File.OpenRead(path))
			{
				keys = (BindingList<Key>)deserializer.Deserialize(fs);
			}
		}

		public static void SaveKeysData()
		{
			string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\KeysDatabase.xml";

			using (Stream fs = new FileStream(path, FileMode.Create))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Key>));
				serializer.Serialize(fs, keys);
			}
		}

		#endregion

		#region Tabs Methods

		private void EncryptorTabButton_Click(object sender, EventArgs e)
		{
			EncryptorTab.Visible = true;
			KeysTab.Visible = false;
		}

		private void KeysTabButton_Click(object sender, EventArgs e)
		{
			EncryptorTab.Visible = false;
			KeysTab.Visible = true;
		}

		public static void OpenKeyEdit(bool open, Key key = null)
		{
			instance.EncryptorLayout.Visible = !open;
			instance.KeyEditTab.Visible = open;

			if (open && key != null)
				instance.KeyEditTab.SetKey(key);
		}

		public static void UpdateKeysList()
		{
			publicKeys.Clear();
			privateKeys.Clear();

			foreach(Key k in keys)
			{
				AddKey(k);
			}
		}

		#endregion

		#region Size Methods

		private void RSAEncryptor_SizeChanged(object sender, EventArgs e)
		{
			ResizeTexts(15, EncryptorLayout);
		}

		/// <summary>
		/// Iterate through an array of controls parents and resize the font of every label found
		/// </summary>
		/// <param name="controlsParents">The array of controls parents</param>
		public static void ResizeTexts(float baseFontSize, params Control[] controlsParents)
		{
			if (instance == null || defaultClientHeight == 0) return;

			foreach (Control cP in controlsParents)
			{
				foreach (Control c in cP.Controls)
				{
					ResizeText(baseFontSize, c);
				}
			}
		}

		public static void ResizeText(float baseFontSize, Control text)
		{
			if (instance == null || defaultClientHeight == 0) return;

			switch (text)
			{
				case Label label:
					label.Font = new Font(label.Font.Name, GetDynamicFontSize(baseFontSize), FontStyle.Regular);

					break;
				case ComboBox comboBox:
					comboBox.Font = new Font(comboBox.Font.Name, GetDynamicFontSize(baseFontSize), FontStyle.Regular);

					break;
				case Button button:
					button.Font = new Font(button.Font.Name, GetDynamicFontSize(baseFontSize), FontStyle.Regular);

					break;
			}
		}

		public static float GetDynamicFontSize(float baseSize)
		{
			return baseSize * 1f/*((float)instance.ClientSize.Height / defaultClientHeight)*/;
		}

		#endregion

		#region Helper Methods

		public static void AddKey(Key key)
		{
			if (!keys.Contains(key))
				keys.Add(key);

			switch (key.keyType)
			{
				case Key.KeyType.PublicAndPrivate:
					publicKeys.Add(key);
					privateKeys.Add(key);

					break;
				case Key.KeyType.Public:
					publicKeys.Add(key);

					break;
				case Key.KeyType.Private:
					privateKeys.Add(key);

					break;
			}
		}

		public static void RemoveKey(int index)
		{
			Key key = keys[index];
			keys.RemoveAt(index);

			if (publicKeys.Contains(key))
				publicKeys.Remove(key);
			if (privateKeys.Contains(key))
				privateKeys.Remove(key);
		}

		public static void RemoveAllKeys()
		{
			keys.Clear();
			publicKeys.Clear();
			privateKeys.Clear();
		}

		public static string ValidateKeyName(string keyName)
		{
			string validatedKeyName = keyName;
			int repIndex = 0, repCount;

			while (true)
			{
				repCount = keys.Count(k => k.KeyName == validatedKeyName);

				if (repCount > 0)
					repIndex++;
				else
					break;

				validatedKeyName = keyName + (repIndex > 0 ? " " + repIndex.ToString() : string.Empty);
			}

			return validatedKeyName;
		}

		#endregion
	}
}
