using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Numerics;

namespace Encryptor
{
	public partial class KeyEditTab : UserControl
	{
		private Key key;

		private ManualKeyEditTab manualKeyEditor;

		private RSACryptoServiceProvider csp;
		private RSAParameters publicKey;
		private RSAParameters privateKey;

		private bool publicKeyValidated, privateKeyValidated;

        public Key.EncryptionMode EncryptionMode
        {
            get
            {
                return (Key.EncryptionMode)EncryptionModeDropdown.SelectedItem;
            }
        }

        #region Constructor

        public KeyEditTab()
		{
			InitializeComponent();
		}

		public void KeyEditTab_Load()
		{
			EncryptionModeDropdown.DataSource = Enum.GetValues(typeof(Key.EncryptionMode));
			ResizeTexts();
		}

		#endregion

		public void SetKey(Key key)
		{
			this.key = key;
			KeyNameTextBox.Text = key.KeyName;
			EncryptionModeDropdown.SelectedItem = key.encryptionMode;

            // Automatic
			if(key.encryptionMode == Key.EncryptionMode.Automatic)
			{
				PublicKeyTextBox.Text = key.PublicKeyString;
				PrivateKeyTextBox.Text = key.PrivateKeyString;

				ValidatePublicKeyButton_Click(this, null);
				ValidatePrivateKeyButton_Click(this, null);
			}

			KeySizeTextBox.Text = "512";

			// Manual
			manualKeyEditor = new ManualKeyEditTab();
			EditPanel.Controls.Add(manualKeyEditor);
			manualKeyEditor.Dock = DockStyle.Fill;
			manualKeyEditor.Margin = new Padding(0);
			manualKeyEditor.SetEditor(this.key);

			if (key.encryptionMode == Key.EncryptionMode.Automatic)
				manualKeyEditor.Visible = false;
			else
				AutoEditLayout.Visible = false;

			EnableValidationMessage(true, false);
			EnableValidationMessage(false, false);
		}

		private void RevertButton_Click(object sender, EventArgs e)
		{
			SetKey(key);
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (KeyNameTextBox.Text != string.Empty)
				key.KeyName = KeyNameTextBox.Text;
			else
				key.KeyName = RSAEncryptor.ValidateKeyName("Chave");

			key.encryptionMode = (Key.EncryptionMode)EncryptionModeDropdown.SelectedItem;

			if (key.encryptionMode == Key.EncryptionMode.Automatic)
				SaveAutomaticKey();
			else
				SaveManualKey();

			KeysTab.UpdateKeysList();
			RSAEncryptor.UpdateKeysList();
		}

		private void SaveAutomaticKey()
		{
			string publicKeyString = PublicKeyTextBox.Text, privateKeyString = PrivateKeyTextBox.Text;

			ParseStringToPublicKey(publicKeyString);
			ParseStringToPrivateKey(privateKeyString);

			if (publicKeyValidated)
				key.PublicKey = publicKey;

			if (privateKeyValidated)
				key.PrivateKey = privateKey;
		}

		private void SaveManualKey()
		{
			key.GenerationExponent = manualKeyEditor.EValue;
			key.GenerationP = manualKeyEditor.PValue;
			key.GenerationQ = manualKeyEditor.QValue;
			key.PublicKeyString = manualKeyEditor.PublicKey;
			key.PrivateKeyString = manualKeyEditor.PrivateKey;
			key.Modulus = manualKeyEditor.Modulus;
			key.Exponent = manualKeyEditor.Exponent;
			key.P = manualKeyEditor.P;
			key.Q = manualKeyEditor.Q;
			key.DP = manualKeyEditor.DP;
			key.DQ = manualKeyEditor.DQ;
			key.InverseQ = manualKeyEditor.InverseQ;
			key.D = manualKeyEditor.D;
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			EditPanel.Controls.Remove(manualKeyEditor);

			RSAEncryptor.OpenKeyEdit(false);
		}

		#region Automatic Generation

		private void GenerateKeysButton_Click(object sender, EventArgs e)
		{
			try
			{
				csp = new RSACryptoServiceProvider(int.Parse(KeySizeTextBox.Text));

				publicKey = csp.ExportParameters(false);
				privateKey = csp.ExportParameters(true);
			}
			catch(Exception ex)
			{
				MessageBox.Show("O tamanho da chave que deseja gerar está fora dos limites.\nO tamanho da chave pode ser de 384 bits a 16384 bits.\nMáximo de 4096 bits recomendado.");

				return;
			}

			PublicKeyTextBox.Text = csp.ToXmlString(false);
			PrivateKeyTextBox.Text = csp.ToXmlString(true);

			ValidatePublicKeyButton_Click(this, null);
			ValidatePrivateKeyButton_Click(this, null);
		}

		#region Validation Methods

		private void ValidatePublicKeyButton_Click(object sender, EventArgs e)
		{
			ParseStringToPublicKey(PublicKeyTextBox.Text);

			EnableValidationMessage(true, true);
		}

		private void ValidatePrivateKeyButton_Click(object sender, EventArgs e)
		{
			ParseStringToPrivateKey(PrivateKeyTextBox.Text);

			EnableValidationMessage(false, true);
		}

		private void PublicKeyTextBox_TextChanged(object sender, EventArgs e)
		{
			if (PublicKeyValidationMessage.Visible)
				EnableValidationMessage(true, false);
		}

		private void PrivateKeyTextBox_TextChanged(object sender, EventArgs e)
		{
			if (PrivateKeyValidationMessage.Visible)
				EnableValidationMessage(false, false);
		}

		private void EnableValidationMessage(bool publicKey, bool enable)
		{
			if (publicKey)
			{
				ValidatePublicKeyButton.Visible = !enable;
				PublicKeyValidationMessage.Visible = enable;
				PublicKeyValidationMessage.Text = publicKeyValidated ? "Chave válida" : "Chave inválida";
				PublicKeyValidationMessage.ForeColor = publicKeyValidated ? Color.LimeGreen : Color.Red;
			}
			else
			{
				ValidatePrivateKeyButton.Visible = !enable;
				PrivateKeyValidationMessage.Visible = enable;
				PrivateKeyValidationMessage.Text = privateKeyValidated ? "Chave válida" : "Chave inválida";
				PrivateKeyValidationMessage.ForeColor = privateKeyValidated ? Color.LimeGreen : Color.Red;
			}
		}

		private void KeySizeTextBox_TextChanged(object sender, EventArgs e)
		{
			KeySizeTextBox.Text = DigitText(KeySizeTextBox.Text);
		}

		#endregion

		private void ParseStringToPublicKey(string publicKeyString)
		{
			try
			{
				csp = new RSACryptoServiceProvider();
				csp.FromXmlString(publicKeyString);
				publicKey = csp.ExportParameters(false);
			}
			catch(Exception e)
			{
				publicKeyValidated = false;

				MessageBox.Show("A chave pública é inválida, impedindo que ela seja salva.");

				return;
			}

			publicKeyValidated = true;
		}

		private void ParseStringToPrivateKey(string privateKeyString)
		{
			try
			{
				csp = new RSACryptoServiceProvider();
				csp.FromXmlString(privateKeyString);
				privateKey = csp.ExportParameters(true);
			}
			catch (Exception e)
			{
				privateKeyValidated = false;

				MessageBox.Show("A chave privada é inválida, impedindo que ela seja salva.");

				return;
			}

			privateKeyValidated = true;
		}

		#endregion

		private void EncryptionModeDropdown_SelectedIndexChanged(object sender, EventArgs e)
		{
			if((Key.EncryptionMode)EncryptionModeDropdown.SelectedItem == Key.EncryptionMode.Automatic)
			{
				AutoEditLayout.Visible = true;

				if (manualKeyEditor != null)
					manualKeyEditor.Visible = false;
			}
			else
			{
				AutoEditLayout.Visible = false;

				if (manualKeyEditor != null)
					manualKeyEditor.Visible = true;
			}
		}

		#region Input Methods

		public static string DigitText(string text, params char[] extraExclusions)
		{
			string digitText = text;

			foreach (char c in text)
			{
				if (!char.IsDigit(c) || extraExclusions.Any(x => x == c))
					digitText = text.Replace(c.ToString(), string.Empty);
			}

			return digitText;
		}

		#endregion

		private void KeyEditTab_SizeChanged(object sender, EventArgs e)
		{
			ResizeTexts();
		}

		private void ResizeTexts()
		{
			RSAEncryptor.ResizeTexts(15, KeyEditTabLayout, AutoEditLayout, PublicKeyValidationPanel, PrivateKeyValidationPanel);
			RSAEncryptor.ResizeText(25, EncryptionModeDropdown);
		}
	}
}
