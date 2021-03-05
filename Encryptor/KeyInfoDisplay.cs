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
	public partial class KeyInfoDisplay : UserControl
	{
		private Key key;

		#region Constructor

		public KeyInfoDisplay()
		{
			InitializeComponent();
		}

		private void KeyInfoDisplay_Load(object sender, EventArgs e)
		{
			ResizeTexts();
		}

		#endregion

		public void SetKey(Key key)
		{
			this.key = key;

			KeyName.Text = key.KeyName;
			PublicKeyTextBox.Text = key.PublicKeyString;
			PrivateKeyTextBox.Text = key.PrivateKeyString;
		}

		#region Copy Methods

		private void PublicKeyCopyButton_Click(object sender, EventArgs e)
		{
			if (PublicKeyTextBox.Text != string.Empty)
				Clipboard.SetText(PublicKeyTextBox.Text);
		}

		private void PrivateKeyCopyButton_Click(object sender, EventArgs e)
		{
			if (PrivateKeyTextBox.Text != string.Empty)
				Clipboard.SetText(PrivateKeyTextBox.Text);
		}

		#endregion

		private void EditButton_Click(object sender, EventArgs e)
		{
			RSAEncryptor.OpenKeyEdit(true, key);
		}

		public void DisplayKeyInfo(bool display)
		{
			Visible = display;

			ResizeTexts();
		}

		private void KeyInfoDisplay_SizeChanged(object sender, EventArgs e)
		{
			ResizeTexts();
		}

		private void ResizeTexts()
		{
			RSAEncryptor.ResizeTexts(15, KeyInfoLayout);
			RSAEncryptor.ResizeText(25, KeyName);
		}
	}
}
