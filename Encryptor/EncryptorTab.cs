using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Encryptor
{
	public partial class EncryptorTab : UserControl
	{
		#region Constructor

		public EncryptorTab()
		{
			InitializeComponent();
		}

		public void EncryptorTab_Load()
		{
			ResizeTexts();

			EnableProcessedMessage(false, true);
			EnableProcessedMessage(false, false);

			EncryptionKeysDropdown.DataSource = RSAEncryptor.keys;
			EncryptionKeysDropdown.DisplayMember = "KeyName";
			DecryptionKeysDropdown.DataSource = RSAEncryptor.keys;
			DecryptionKeysDropdown.DisplayMember = "KeyName";
		}

		#endregion

		#region Encryption Methods

		private void EncryptButton_Click(object sender, EventArgs e)
		{
			if (MessageTextBox.Text == string.Empty) return;

			var key = (Key)EncryptionKeysDropdown.SelectedItem;

			if(key.encryptionMode == Key.EncryptionMode.Manual)
			{
				if (!key.IsManualPublicKeyValid)
				{
					MessageBox.Show("A chave que deseja utilizar não suporta criptografar.");

					return;
				}
				else
				{
					if (new BigInteger(Encoding.Unicode.GetBytes(MessageTextBox.Text)) >= key.Modulus / 2)
					{
						MessageBox.Show("A mensagem é muito grande para ser criptografada usando a chave selecionada");

						return;
					}
				}
			}

			string encryptedMessage = EncryptionAgent.Encrypt(MessageTextBox.Text, key);

            if(encryptedMessage != string.Empty)
            {
                ProcessedMessageTextBox.Text = encryptedMessage;
                EnableProcessedMessage(true, true);
            }
		}

		private void DecryptButton_Click(object sender, EventArgs e)
		{
			if (EncryptedMessageTextBox.Text == string.Empty) return;

			var key = (Key)EncryptionKeysDropdown.SelectedItem;

			if (key.encryptionMode == Key.EncryptionMode.Manual)
			{
				if (!key.IsManualPrivateKeyValid)
				{
					MessageBox.Show("A chave que deseja utilizar não suporta descriptografar.");
					return;
				}
			}

			string decryptedMessage = EncryptionAgent.Decrypt(EncryptedMessageTextBox.Text, key);

            if (decryptedMessage != string.Empty)
            {
                DecryptedMessageTextBox.Text = decryptedMessage;
                EnableProcessedMessage(true, false);
            }
		}

		#endregion

		#region Clearing Methods

		private void EncryptionClearButton_Click(object sender, EventArgs e)
		{
			MessageTextBox.Clear();
			ProcessedMessageTextBox.Clear();
			EnableProcessedMessage(false, true);
		}

		private void DecryptionClearButton_Click(object sender, EventArgs e)
		{
			EncryptedMessageTextBox.Clear();
			DecryptedMessageTextBox.Clear();
			EnableProcessedMessage(false, false);
		}

		#endregion

		#region Copy Methods

		private void EncryptionCopyButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(ProcessedMessageTextBox.Text);
		}
		private void DecryptionCopyButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(DecryptedMessageTextBox.Text);
		}

		private void PasteMessageButton_Click(object sender, EventArgs e)
		{
			MessageTextBox.Text = Clipboard.GetText();
		}
		private void PasteEncryptedMessageButton_Click(object sender, EventArgs e)
		{
			EncryptedMessageTextBox.Text = Clipboard.GetText();
		}

		#endregion

		#region Enabling Methods

		/// <summary>
		/// Enable the processed message and components related to it
		/// </summary>
		/// <param name="enable">If true enables, else disables</param>
		/// <param name="encryption">If true enables the encryption message, else enables the decryption message</param>
		private void EnableProcessedMessage(bool enable, bool encryption)
		{
			if (encryption)
			{
				EncryptButton.Visible = !enable;
				ProcessedMessageTitle.Visible = enable;
				ProcessedMessageTextBox.Visible = enable;
				EncryptionClearButton.Visible = enable;
				EncryptionCopyButton.Visible = enable;
			}
			else
			{
				DecryptButton.Visible = !enable;
				DecryptedMessageTitle.Visible = enable;
				DecryptedMessageTextBox.Visible = enable;
				DecryptionClearButton.Visible = enable;
				DecryptionCopyButton.Visible = enable;
			}
		}

		private void MessageTextBox_TextChanged(object sender, EventArgs e)
		{
			if (ProcessedMessageTextBox.Visible)
				EnableProcessedMessage(false, true);
		}
		private void EncryptedMessageTextBox_TextChanged(object sender, EventArgs e)
		{
			if (DecryptedMessageTextBox.Visible)
				EnableProcessedMessage(false, false);
		}

		#endregion

		#region Size Methods

		private void EncryptorTab_SizeChanged(object sender, EventArgs e)
		{
			ResizeTexts();
		}

		#endregion

		private void ResizeTexts()
		{
			RSAEncryptor.ResizeTexts(15, EncryptorLayout, EncryptionPanel, DecryptionPanel);
			RSAEncryptor.ResizeText(25, EncryptionKeysDropdown);
			RSAEncryptor.ResizeText(25, DecryptionKeysDropdown);
		}
	}
}
