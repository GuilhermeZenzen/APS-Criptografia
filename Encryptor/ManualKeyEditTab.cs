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
	public partial class ManualKeyEditTab : UserControl
	{
		private Key key;
		public ManualKeyGenerator KeyGenerator { get; private set; }

		public Key.KeyType KeyType { get; set; }

		public int Exponent { get; set; }
		public BigInteger Modulus { get; set; }
		public BigInteger P { get; set; }
		public BigInteger Q { get; set; }
		public BigInteger DP { get; set; }
		public BigInteger DQ { get; set; }
		public BigInteger InverseQ { get; set; }
		public BigInteger D { get; set; }

		public bool isPublicKeyValid { get; private set; }
		public bool isPrivateKeyValid { get; private set; }

		public string PublicKey
		{
			get
			{
				return PublicKeyTextBox.Text;
			}
		}
		public string PrivateKey
		{
			get
			{
				return PrivateKeyTextBox.Text;
			}
		}

		public int EValue
		{
			get
			{
				if (ETextBox.Text == string.Empty)
					return 0;

				return int.Parse(ETextBox.Text);
			}
		}
		public BigInteger PValue
		{
			get
			{
				if (PTextBox.Text == string.Empty)
					return 0;

				return BigInteger.Parse(PTextBox.Text);
			}
		}
		public BigInteger QValue
		{
			get
			{
				if (QTextBox.Text == string.Empty)
					return 0;

				return BigInteger.Parse(QTextBox.Text);
			}
		}

		public bool isEValid
		{
			get
			{
				return KeyGenerator.Exponent != 0;
			}
		}
		public bool isPValid
		{
			get
			{
				return KeyGenerator.P != 0;
			}
		}
		public bool isQValid
		{
			get
			{
				return KeyGenerator.Q != 0;
			}
		}

		#region Constructor

		public ManualKeyEditTab()
		{
			InitializeComponent();
		}

		private void ManualKeyEditTab_Load(object sender, EventArgs e)
		{
			ResizeTexts();
		}

		#endregion

		public void SetEditor(Key key)
		{
			this.key = key;
			KeyGenerator = new ManualKeyGenerator();

			PublicKeyTextBox.Text = key.PublicKeyString;
			PrivateKeyTextBox.Text = key.PrivateKeyString;

			ValidatePublicKey(false);
			ValidatePrivateKey(false);

			if (key.GenerationExponent != 0)
				ETextBox.Text = key.GenerationExponent.ToString();
			if (key.GenerationP != 0)
				PTextBox.Text = key.GenerationP.ToString();
			if (key.GenerationQ != 0)
				QTextBox.Text = key.GenerationQ.ToString();

			ValidateE(key.GenerationExponent);
			if (KeyGenerator.Exponent != 0)
			{
				ValidateP(key.GenerationP);
				ValidateQ(key.GenerationQ);
			}
		}

		#region Parameters Setting Events

		// Exponent
		private void ERandomButton_Click(object sender, EventArgs e)
		{
			RandomE();
		}
		private void EValidateButton_Click(object sender, EventArgs e)
		{
			ValidateE(EValue);
		}
		private void ETextBox_TextChanged(object sender, EventArgs e)
		{
			string defaultText = ETextBox.Text;

			ETextBox.Text = KeyEditTab.DigitText(ETextBox.Text);

			if(ETextBox.Text == defaultText)
			{
				EnableValidation(EValidateButton, false);
				EnablePrimeParameters(false);
			}
		}
		private void EMinTextBox_TextChanged(object sender, EventArgs e)
		{
			EMinTextBox.Text = KeyEditTab.DigitText(EMinTextBox.Text);
		}
		private void EMaxTextBox_TextChanged(object sender, EventArgs e)
		{
			EMaxTextBox.Text = KeyEditTab.DigitText(EMaxTextBox.Text);
		}

		// P
		private void PRandomButton_Click(object sender, EventArgs e)
		{
			RandomP();
		}
		private void PValidateButton_Click(object sender, EventArgs e)
		{
			ValidateP(PValue);
		}
		private void PTextBox_TextChanged(object sender, EventArgs e)
		{
			string defaultText = PTextBox.Text;

			PTextBox.Text = KeyEditTab.DigitText(PTextBox.Text);

			if(PTextBox.Text == defaultText)
			{
				EnableValidation(PValidateButton, false);
				EnableLastParameters(false);
			}
		}
		private void PSizeTextBox_TextChanged(object sender, EventArgs e)
		{
			PSizeTextBox.Text = KeyEditTab.DigitText(PSizeTextBox.Text);
		}

		// Q
		private void QRandomButton_Click(object sender, EventArgs e)
		{
			RandomQ();
		}
		private void QValidateButton_Click(object sender, EventArgs e)
		{
			ValidateQ(QValue);
		}
		private void QTextBox_TextChanged(object sender, EventArgs e)
		{
			string defaultText = QTextBox.Text;

			QTextBox.Text = KeyEditTab.DigitText(QTextBox.Text);

			if (QTextBox.Text == defaultText)
			{
				EnableValidation(QValidateButton, false);
				EnableLastParameters(false);
			}
		}
		private void QSizeTextBox_TextChanged(object sender, EventArgs e)
		{
			QSizeTextBox.Text = KeyEditTab.DigitText(QSizeTextBox.Text);
		}

		#endregion

		#region Exponent, P & Q

		// Exponent
		private void RandomE()
		{
			if (EMinTextBox.Text == string.Empty || EMaxTextBox.Text == string.Empty) return;

			int eMin = int.Parse(EMinTextBox.Text), eMax = int.Parse(EMaxTextBox.Text);

			if (eMax <= eMin)
			{
				MessageBox.Show("O valor máximo deve ser maior que o valor mínimo.");

				return;
			}

			ETextBox.Text = KeyGenerator.GenerateExponent(eMin, eMax).ToString();
			EnableValidation(EValidateButton, true, true);
			EnablePrimeParameters(true);
		}
		private void ValidateE(int value)
		{
			KeyGenerator.VerifyExponent(value);

			EnableValidation(EValidateButton, value != 0 ? true : false, isEValid);
			EnablePrimeParameters(isEValid);
		}

		// P
		private void RandomP()
		{
			if (PSizeTextBox.Text == string.Empty) return;

			int size = int.Parse(PSizeTextBox.Text);

			if(size % 8 != 0)
			{
				MessageBox.Show("O tamanho de P deve ser múltiplo de oito.");

				return;
			}

			if (KeyGenerator.GenerateP(size))
			{
				PTextBox.Text = KeyGenerator.P.ToString();
				EnableValidation(PValidateButton, true, true);

				if (isQValid)
					EnableLastParameters(true);
			}
		}
		private void ValidateP(BigInteger value)
		{
			if (value == 0) return;

			KeyGenerator.VerifyP(PValue);

			EnableValidation(PValidateButton, true, isPValid);

			if (isPValid && isQValid)
				EnableLastParameters(true);
		}

		// Q
		private void RandomQ()
		{
			if (QSizeTextBox.Text == string.Empty) return;

			int size = int.Parse(QSizeTextBox.Text);

			if (size % 8 != 0)
			{
				MessageBox.Show("O tamanho de Q deve ser múltiplo de oito.");

				return;
			}

			if (KeyGenerator.GenerateQ(size))
			{
				QTextBox.Text = KeyGenerator.Q.ToString();
				EnableValidation(QValidateButton, true, true);

				if (isPValid)
					EnableLastParameters(true);
			}
		}
		private void ValidateQ(BigInteger value)
		{
			if (value == 0) return;

			KeyGenerator.VerifyQ(QValue);

			EnableValidation(QValidateButton, true, isQValid);

			if (isQValid && isPValid)
				EnableLastParameters(true);
		}

		#endregion

		#region Modulus, PhiModulus & D

		// Modulus
		private void CalculateModulus()
		{
			NTextBox.Text = KeyGenerator.GenerateModulus().ToString();
		}

		// Phi Modulus
		private void CalculatePhiModulus()
		{
			PhiNTextBox.Text = KeyGenerator.GeneratePhiModulus().ToString();
		}

		// D
		private void CalculateD()
		{
			DTextBox.Text = KeyGenerator.GenerateD().ToString();

			KeyGenerator.GenerateDP();
			KeyGenerator.GenerateDQ();
			KeyGenerator.GenerateInverseQ();
		}

		#endregion

		#region Enabling Methods

		private void EnableValidation(Button button, bool enable, bool validate = false)
		{
			button.Enabled = !enable;

			if (enable)
				button.Text = validate ? "Válido" : "Inválido";
			else
				button.Text = "Validar";
		}

		private void EnablePrimeParameters(bool enable)
		{
			if (enable)
			{
				ValidateP(PValue);
				ValidateQ(QValue);

				if (isPValid && isQValid)
					EnableLastParameters(true);
			}
			else
				EnableLastParameters(false);
			
			PTitle.Visible = enable;
			PTextBox.Visible = enable;
			PSizeTextBox.Visible = enable;
			PRandomButton.Visible = enable;
			PValidateButton.Visible = enable;

			QTitle.Visible = enable;
			QTextBox.Visible = enable;
			QSizeTextBox.Visible = enable;
			QRandomButton.Visible = enable;
			QValidateButton.Visible = enable;
		}

		private void EnableLastParameters(bool enable)
		{
			NTitle.Visible = enable;
			NTextBox.Visible = enable;

			PhiNTitle.Visible = enable;
			PhiNTextBox.Visible = enable;

			DTitle.Visible = enable;
			DTextBox.Visible = enable;

			EnableGenerationButton(enable);

			if (enable)
			{
				CalculateModulus();
				CalculatePhiModulus();
				CalculateD();
			}
		}

		private void EnableGenerationButton(bool enable)
		{
			GenerateKeysButton.Visible = enable;
		}

		private void EnableKeyValidation(bool publicKey, bool enable, bool validate = false)
		{
			if (publicKey)
			{
				PublicKeyValidationButton.Visible = !enable;
				PublicKeyValidationMessage.Visible = enable;
			}
			else
			{
				PrivateKeyValidationButton.Visible = !enable;
				PrivateKeyValidationMessage.Visible = enable;
			}

			if (!enable) return;

			if (publicKey)
			{
				PublicKeyValidationMessage.Text = validate ? "Chave válida" : "Chave inválida";
				PublicKeyValidationMessage.ForeColor = validate ? Color.LimeGreen : Color.Red;
			}
			else
			{
				PrivateKeyValidationMessage.Text = validate ? "Chave válida" : "Chave inválida";
				PrivateKeyValidationMessage.ForeColor = validate ? Color.LimeGreen : Color.Red;
			}

		}

		#endregion

		#region Keys

		public void SetKey(int exponent, params BigInteger[] parameters)
		{
			this.Exponent = exponent;
			this.Modulus = parameters.Length >= 1 ? parameters[0] : this.Modulus;
			this.P = parameters.Length >= 2 ? parameters[1] : this.P;
			this.Q = parameters.Length >= 3 ? parameters[2] : this.Q;
			this.DP = parameters.Length >= 4 ? parameters[3] : this.DP;
			this.DQ = parameters.Length >= 5 ? parameters[4] : this.DQ;
			this.InverseQ = parameters.Length >= 6 ? parameters[5] : this.InverseQ;
			this.D = parameters.Length >= 7 ? parameters[6] : this.D;
		}

		#endregion

		#region Keys Generation

		private void GenerateKeysButton_Click(object sender, EventArgs e)
		{
			GenerateKeys();
		}

		private void GenerateKeys()
		{
			SetKey(KeyGenerator.Exponent, KeyGenerator.Modulus, KeyGenerator.P, KeyGenerator.Q, KeyGenerator.DP, KeyGenerator.DQ, KeyGenerator.InverseQ, KeyGenerator.D);

			var e64Data = Convert.ToBase64String(BitConverter.GetBytes(KeyGenerator.Exponent));
			var n64Data = Convert.ToBase64String(KeyGenerator.Modulus.ToByteArray());
			var p64Data = Convert.ToBase64String(KeyGenerator.P.ToByteArray());
			var q64Data = Convert.ToBase64String(KeyGenerator.Q.ToByteArray());
			var dP64Data = Convert.ToBase64String(KeyGenerator.DP.ToByteArray());
			var dQ64Data = Convert.ToBase64String(KeyGenerator.DQ.ToByteArray());
			var invQ64Data = Convert.ToBase64String(KeyGenerator.InverseQ.ToByteArray());
			var d64Data = Convert.ToBase64String(KeyGenerator.D.ToByteArray());

			string publicKeyString = "<RSAKeyValue><Modulus>" + n64Data + "</Modulus><Exponent>" + e64Data + "</Exponent></RSAKeyValue>";

			string privateKeyString = "<RSAKeyValue><Modulus>" + n64Data + "</Modulus><Exponent>" + e64Data + "</Exponent><P>" + p64Data + "</P><Q>" + q64Data + "</Q><DP>" + dP64Data + "</DP><DQ>" + dQ64Data + "</DQ><InverseQ>" + invQ64Data + "</InverseQ><D>" + d64Data + "</D></RSAKeyValue>";

			PublicKeyTextBox.Text = publicKeyString;
			PrivateKeyTextBox.Text = privateKeyString;

			isPublicKeyValid = true;
			isPrivateKeyValid = true;

			EnableKeyValidation(true, true, true);
			EnableKeyValidation(false, true, true);
		}

		#endregion

		#region Keys Validation

		private void PublicKeyValidationButton_Click(object sender, EventArgs e)
		{
			ValidatePublicKey();
		}

		private void PrivateKeyValidationButton_Click(object sender, EventArgs e)
		{
			ValidatePrivateKey();
		}

		private void PublicKeyTextBox_TextChanged(object sender, EventArgs e)
		{
			isPublicKeyValid = false;
			EnableKeyValidation(true, false);
		}

		private void PrivateKeyTextBox_TextChanged(object sender, EventArgs e)
		{
			isPrivateKeyValid = false;
			EnableKeyValidation(false, false);
		}

		private void ValidatePublicKey(bool showWarning = true)
		{
			try
			{
				isPublicKeyValid = false;

				var formatting = new string[3]
				{
					"<RSAKeyValue><Modulus>",
					"</Modulus><Exponent>",
					"</Exponent></RSAKeyValue>"
				};
				var readKey = ReadXMLKey(PublicKey, 2, true, formatting, showWarning);

				if (readKey == null)
					return;

				var n64 = readKey[0];
				var e64 = readKey[1];

				int e = BitConverter.ToInt32(Convert.FromBase64String(e64), 0);

				if (e > 1 && e % 2 != 0)
				{
					isPublicKeyValid = true;

					SetKey(e, new BigInteger(Convert.FromBase64String(n64)));
				}
				else
				{
					if (!isPrivateKeyValid)
						SetKey(0, 0);
				}

				EnableKeyValidation(true, true, isPublicKeyValid);
			}
			catch (Exception ex)
			{
				if (showWarning)
					MessageBox.Show("Impossível validar chave. " + ex.Message);
			}
		}

		private void ValidatePrivateKey(bool showWarning = true)
		{
			try
			{
				var formatting = new string[9]
				{
					"<RSAKeyValue><Modulus>",
					"</Modulus><Exponent>",
					"</Exponent><P>",
					"</P><Q>",
					"</Q><DP>",
					"</DP><DQ>",
					"</DQ><InverseQ>",
					"</InverseQ><D>",
					"</D></RSAKeyValue>"
				};

				var readKey = ReadXMLKey(PrivateKey, 8, false, formatting, showWarning);

				if(readKey == null)
				{
					isPrivateKeyValid = false;

					return;
				}

				bool isValidated = false;

				BigInteger n = new BigInteger(Convert.FromBase64String(readKey[0]));
				int e = BitConverter.ToInt32(Convert.FromBase64String(readKey[1]), 0);
				BigInteger p = new BigInteger(Convert.FromBase64String(readKey[2]));
				BigInteger q = new BigInteger(Convert.FromBase64String(readKey[3]));
				BigInteger dp = new BigInteger(Convert.FromBase64String(readKey[4]));
				BigInteger dq = new BigInteger(Convert.FromBase64String(readKey[5]));
				BigInteger invQ = new BigInteger(Convert.FromBase64String(readKey[6]));
				BigInteger d = new BigInteger(Convert.FromBase64String(readKey[7]));

				if (e > 1 && e % 2 != 0)
				{
					if (KeyGenerator.IsPrime(p, 40) && BigInteger.GreatestCommonDivisor(p - 1, new BigInteger(e)) == 1 && KeyGenerator.IsPrime(q, 40) && BigInteger.GreatestCommonDivisor(q - 1, new BigInteger(e)) == 1)
					{
						if (p * q == n)
						{
							if (KeyGenerator.CalculateD(e, (p - 1) * (q - 1)) == d)
							{

							}
						}
					}
				}

				if (isValidated)
					SetKey(e, n, p, q, dp, dq, invQ, d);
				else
				{
					if (isPublicKeyValid)
						SetKey(Exponent, Modulus, 0, 0, 0, 0, 0, 0);
					else
						SetKey(0, 0, 0, 0, 0, 0, 0, 0);
				}

				isPrivateKeyValid = isValidated;
				EnableKeyValidation(false, true, isPrivateKeyValid);
			}
			catch(Exception ex)
			{
				if (showWarning)
					MessageBox.Show("Impossível validar chave. " + ex.Message);

				isPrivateKeyValid = false;
			}
		}

		private string[] ReadXMLKey(string xml, int paramsAmount, bool publicKey, string[] formatting, bool showWarning = true)
		{
			for(int i = 0; i < formatting.Length; i++)
			{
				if (!xml.Contains(formatting[i]))
				{
					if (showWarning)
					{
						MessageBox.Show(publicKey ? "A chave pública possui uma formatação incorreta." : "A chave privada possui uma formatação incorreta.");
					}

					return null;
				}
			}

			string[] parameters = new string[paramsAmount];
			int readingStart = 0;

			for (int x = 0; x < paramsAmount; x++)
			{
				var paramBuilder = new StringBuilder();
				int limitEndCount = 0;

				for (int y = readingStart; y < xml.Length; y++)
				{
					if (limitEndCount == 2)
					{
						if (xml[y] == '<')
						{
							readingStart = y + 1;
							break;
						}

						paramBuilder.Append(xml[y]);
					}

					if (xml[y] == '>')
						limitEndCount++;
				}

				parameters[x] = paramBuilder.ToString();
			}

			return parameters;
		}

		#endregion

		private void ManualKeyEditTab_SizeChanged(object sender, EventArgs e)
		{
			ResizeTexts();
		}

		private void ResizeTexts()
		{
			RSAEncryptor.ResizeTexts(14, EditLayout, KeysLayout, PublicKeyValidationPanel, PrivateKeyValidationPanel);
		}
	}
}
