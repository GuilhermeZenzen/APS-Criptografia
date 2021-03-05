using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor
{
	class KeyEditTabBackUp
	{
		/*
		private Key key;

		private RSACryptoServiceProvider csp;
		private RSAParameters publicKey;
		private RSAParameters privateKey;

		private bool publicKeyValidated, privateKeyValidated;

		public Key.KeyType KeyType
		{
			get
			{
				return (Key.KeyType)KeyTypeDropdown.SelectedItem;
			}
		}
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
			KeyTypeDropdown.DataSource = Enum.GetValues(typeof(Key.KeyType));
			EncryptionModeDropdown.DataSource = Enum.GetValues(typeof(Key.EncryptionMode));
		}

		#endregion

		public void SetKey(Key key)
		{
			this.key = key;
			KeyNameTextBox.Text = key.KeyName;
			KeyTypeDropdown.SelectedItem = key.keyType;
			EncryptionModeDropdown.SelectedItem = key.encryptionMode;

			// Automatic
			PublicKeyTextBox.Text = key.PublicKeyString;
			PrivateKeyTextBox.Text = key.PrivateKeyString;
			KeySizeTextBox.Text = "512";

			// Manual


			EnableValidationMessage(true, false);
			EnableValidationMessage(false, false);
			EnablePQ(false);
			CalculateLastParameters(false);
			EnableManualValidationMessage(false);
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

			key.keyType = (Key.KeyType)KeyTypeDropdown.SelectedItem;
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

			switch (key.keyType)
			{
				case Key.KeyType.PublicAndPrivate:

					ParseStringToPublicKey(publicKeyString);
					ParseStringToPrivateKey(privateKeyString);

					if (publicKeyValidated)
						key.PublicKey = publicKey;

					if (privateKeyValidated)
						key.PrivateKey = privateKey;

					break;
				case Key.KeyType.Public:

					ParseStringToPublicKey(publicKeyString);

					if (publicKeyValidated)
						key.PublicKey = publicKey;

					break;
				case Key.KeyType.Private:

					ParseStringToPrivateKey(privateKeyString);

					if (privateKeyValidated)
						key.PrivateKey = privateKey;

					break;
			}
		}

		private void SaveManualKey()
		{
			switch (KeyType)
			{
				case Key.KeyType.PublicAndPrivate:
				case Key.KeyType.Private:

					if (isManualPrivateKeyValid)
					{
						key.P = new BigInteger(Convert.FromBase64String(p64Value));
						key.Q = new BigInteger(Convert.FromBase64String(q64Value));
						key.Modulus = new BigInteger(Convert.FromBase64String(n64Value));
						key.Exponent = new BigInteger(Convert.FromBase64String(e64Value));
						key.D = new BigInteger(Convert.FromBase64String(d64Value));
					}
					else
					{
						if (isEValid)
						{
							key.Exponent = EValue;
							key.P = isPValid ? PValue : 0;
							key.Q = isQValid ? QValue : 0;

							if (isPValid && isQValid)
							{
								key.Modulus = NValue;
								key.D = DValue;
							}
						}
					}

					break;
				case Key.KeyType.Public:

					if (isManualPublicKeyValid)
					{
						key.Exponent = new BigInteger(Convert.FromBase64String(e64Value));
						key.Modulus = new BigInteger(Convert.FromBase64String(n64Value));
					}
					else
					{
						key.Exponent = EValue;
						key.Modulus = NValue;
					}

					break;
			}
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
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
			catch (Exception ex)
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
			catch (Exception e)
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

		#region Manual Generation

		private bool isEValid, isPValid, isQValid;
		private bool isManualPublicKeyValid, isManualPrivateKeyValid;

		public BigInteger EValue
		{
			get
			{
				if (ETextBox.Text == string.Empty)
					return 0;

				return BigInteger.Parse(ETextBox.Text);
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
		public BigInteger NValue
		{
			get
			{
				if (NTextBox.Text == string.Empty)
					return 0;

				return BigInteger.Parse(NTextBox.Text);
			}
		}
		public BigInteger PhiNValue
		{
			get
			{
				if (PhiNTextBox.Text == string.Empty)
					return 0;

				return BigInteger.Parse(PhiNTextBox.Text);
			}
		}
		public BigInteger DValue
		{
			get
			{
				if (DTextBox.Text == string.Empty)
					return 0;

				return BigInteger.Parse(DTextBox.Text);
			}
		}

		private string e64Value, p64Value, q64Value, n64Value, d64Value;

		private BigInteger previousEValue;
		private int[] previousLimits = new int[2];
		private List<int> previousPrimes;

		#region Paramaters Random Methods

		#region Prime Methods

		private bool ValidPrime(BigInteger x)
		{
			if (x <= 2 || x % 2 == 0) return false;

			for (BigInteger i = 3; i * i <= x; i += 2)
			{
				if (x % i == 0)
					return false;
			}

			return true;
		}

		private int RandomPrime(int min, int max)
		{
			var random = new Random();

			List<int> primes;

			if (previousEValue == EValue && previousLimits[0] == min && previousLimits[1] == max)
				primes = previousPrimes;
			else
			{
				primes = Primes(min, max);
				previousPrimes = primes;
				previousLimits[0] = min;
				previousLimits[1] = max;
				previousEValue = EValue;
			}

			if (primes.Count == 0)
			{
				MessageBox.Show("Impossível gerar um número que atenda as especificações usando os valores informados.");
				return 0;
			}

			return primes[random.Next(0, primes.Count)];
		}

		private int RandomOdd(int min, int max)
		{
			var random = new Random();

			List<int> odds = Odds(min, max);

			if (odds.Count == 0)
			{
				MessageBox.Show("Impossível gerar um número que atenda as especificações usando os valores informados.");
				return 0;
			}

			return odds[random.Next(0, odds.Count)];
		}

		private List<int> Primes(int min, int max)
		{
			List<int> result = Enumerable.Range(2, max - 1).ToList();

			for (int i = 1; i < result.Count; ++i)
			{
				int prime = result[i - 1];

				for (int j = result.Count - 1; j > i; --j)
				{
					if (result[j] % prime == 0)
						result.RemoveAt(j);
				}
			}

			result = result.Where(x => x >= min && ValidatePrimeParameter(int.Parse(ETextBox.Text), x, false)).ToList();

			return result;
		}

		private List<int> Odds(int min, int max)
		{
			List<int> result = Enumerable.Range(3, max - 1).ToList();

			return result.Where(x => x % 2 != 0).ToList();
		}

		private bool ValidatePrimeParameter(BigInteger e, BigInteger x, bool checkPrime)
		{
			if (checkPrime)
				return ValidPrime(x) && AreCoprimes(e, x - 1);

			return AreCoprimes(e, x - 1);
		}

		#endregion

		private void EnablePQ(bool enable)
		{
			PTitle.Visible = enable;
			PTextBox.Visible = enable;
			PMinTextBox.Visible = enable;
			PMaxTextBox.Visible = enable;
			PRandomButton.Visible = enable;
			PValidateButton.Visible = enable;

			QTitle.Visible = enable;
			QTextBox.Visible = enable;
			QMinTextBox.Visible = enable;
			QMaxTextBox.Visible = enable;
			QRandomButton.Visible = enable;
			QValidateButton.Visible = enable;

			if (!enable)
				CalculateLastParameters(false);
		}

		private BigInteger GetGCD(BigInteger a, BigInteger b)
		{
			BigInteger c = BigInteger.Min(a, b), d = BigInteger.Max(a, b);
			BigInteger e = 0;

			do
			{
				if (e != 0)
				{
					d = c;
					c = e;
				}

				e = d % c;
			}
			while (e != 0);

			return c;
		}

		private bool AreCoprimes(BigInteger a, BigInteger b)
		{
			if (GetGCD(a, b) == 1) return true;

			return false;
		}

		private BigInteger CalculateD(BigInteger e, BigInteger n)
		{
			BigInteger x = 0, y = 0;
			BigInteger gcd = ExtendedGCD(e, n, ref x, ref y);

			return (x % n + n) % n;
		}

		private BigInteger ExtendedGCD(BigInteger a, BigInteger b, ref BigInteger x, ref BigInteger y)
		{
			if (a == 0)
			{
				x = 0;
				y = 1;

				return b;
			}

			BigInteger x1 = 0, y1 = 0;
			BigInteger gcd = ExtendedGCD(b % a, a, ref x1, ref y1);

			x = y1 - (b / a) * x1;
			y = x1;

			return gcd;
		}

		#endregion

		private void CalculateLastParameters(bool calculate)
		{
			if (!isPValid || !isQValid)
				calculate = false;

			if (calculate)
			{
				NTextBox.Text = (PValue * QValue).ToString();
				PhiNTextBox.Text = ((PValue - 1) * (QValue - 1)).ToString();

				DTextBox.Text = CalculateD(EValue, PhiNValue).ToString();
			}

			NTitle.Visible = calculate;
			NTextBox.Visible = calculate;
			PhiNTitle.Visible = calculate;
			PhiNTextBox.Visible = calculate;
			DTitle.Visible = calculate;
			DTextBox.Visible = calculate;

			ManualGenerateKeysButton.Visible = calculate;
		}

		#endregion

		#region Paramaters

		// Random Paramaters
		private void ERandomButton_Click(object sender, EventArgs e)
		{
			if (EMinTextBox.Text == string.Empty || EMaxTextBox.Text == string.Empty) return;

			Random random = new Random();

			int minValue = int.Parse(EMinTextBox.Text), maxValue = int.Parse(EMaxTextBox.Text);
			minValue = minValue > 1 ? minValue : 2;

			if (ValidLimits(minValue, maxValue))
			{
				BigInteger value = RandomOdd(minValue, maxValue);
				ETextBox.Text = value != 0 ? value.ToString() : string.Empty;
				ValidateParamater(EValidateButton, ref isEValid, true);
				EnablePQ(isEValid);
			}
		}

		private void PRandomButton_Click(object sender, EventArgs e)
		{
			if (PMinTextBox.Text == string.Empty || PMaxTextBox.Text == string.Empty) return;

			int minValue = int.Parse(PMinTextBox.Text), maxValue = int.Parse(PMaxTextBox.Text);
			minValue = minValue > 2 ? minValue : 3;

			if (ValidLimits(minValue, maxValue))
			{
				int value = RandomPrime(minValue, maxValue);

				if (value == 0) return;

				PTextBox.Text = value.ToString();
				ValidateParamater(PValidateButton, ref isPValid, true);
				CalculateLastParameters(true);
			}
		}

		private void QRandomButton_Click(object sender, EventArgs e)
		{
			if (QMinTextBox.Text == string.Empty || QMaxTextBox.Text == string.Empty) return;

			int minValue = int.Parse(QMinTextBox.Text), maxValue = int.Parse(QMaxTextBox.Text);
			minValue = minValue > 2 ? minValue : 3;

			if (ValidLimits(minValue, maxValue))
			{
				int value = RandomPrime(minValue, maxValue);

				if (value == 0) return;

				QTextBox.Text = value.ToString();
				ValidateParamater(QValidateButton, ref isQValid, true);
				CalculateLastParameters(true);
			}
		}

		private bool ValidLimits(int min, int max)
		{
			if (max <= min)
			{
				MessageBox.Show("O limite máximo deve ser maior que o limite mínimo.");
				return false;
			}

			return true;
		}

		//

		// Parameters Validation Button

		private void EValidateButton_Click(object sender, EventArgs e)
		{
			if (ETextBox.Text == string.Empty) return;

			ValidateParamater(EValidateButton, ref isEValid, EValue > 1 && EValue % 2 != 0);

			EnablePQ(isEValid);

			if (isEValid)
			{
				PValidateButton_Click(this, null);
				QValidateButton_Click(this, null);
			}
		}

		private void PValidateButton_Click(object sender, EventArgs e)
		{
			if (PTextBox.Text == string.Empty) return;

			PValidateButton.Enabled = false;
			ValidateParamater(PValidateButton, ref isPValid, ValidatePrimeParameter(EValue, PValue, true));

			CalculateLastParameters(true);
		}

		private void QValidateButton_Click(object sender, EventArgs e)
		{
			if (QTextBox.Text == string.Empty) return;

			QValidateButton.Enabled = false;
			ValidateParamater(QValidateButton, ref isQValid, ValidatePrimeParameter(EValue, QValue, true));

			CalculateLastParameters(true);
		}

		//

		// Parameters Changed

		private void ETextBox_TextChanged(object sender, EventArgs e)
		{
			if (!EValidateButton.Enabled)
			{
				ResetValidationButton(EValidateButton);
				isEValid = false;
				EnablePQ(false);
				ResetValidationButton(PValidateButton);
				ResetValidationButton(QValidateButton);
			}
		}

		private void PTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!PValidateButton.Enabled)
			{
				ResetValidationButton(PValidateButton);
				isPValid = false;
				CalculateLastParameters(false);
			}
		}

		private void QTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!QValidateButton.Enabled)
			{
				ResetValidationButton(QValidateButton);
				isQValid = false;
				CalculateLastParameters(false);
			}
		}

		private void EncryptionModeDropdown_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((Key.EncryptionMode)EncryptionModeDropdown.SelectedItem == Key.EncryptionMode.Automatic)
			{
				AutoEditLayout.Visible = true;
				ManualEditLayout.Visible = false;
			}
			else
			{
				AutoEditLayout.Visible = false;
				ManualEditLayout.Visible = true;
			}
		}

		private void ManualKeyValidationButton_Click(object sender, EventArgs e)
		{
			bool isValidated = false;

			switch ((Key.KeyType)KeyTypeDropdown.SelectedItem)
			{
				case Key.KeyType.PublicAndPrivate:

					if (ManualPublicKeyTextBox.Text == string.Empty || ManualPrivateKeyTextBox.Text == string.Empty) return;

					ReadPublicXMLKey(ManualPublicKeyTextBox.Text);
					ReadPrivateXMLKey(ManualPrivateKeyTextBox.Text);

					isValidated = isManualPublicKeyValid && isManualPrivateKeyValid;
					MessageBox.Show(isManualPublicKeyValid.ToString());
					MessageBox.Show(isManualPrivateKeyValid.ToString());

					break;
				case Key.KeyType.Public:

					if (ManualPublicKeyTextBox.Text == string.Empty) return;

					ReadPublicXMLKey(ManualPublicKeyTextBox.Text);
					MessageBox.Show(isManualPublicKeyValid.ToString());
					isValidated = isManualPublicKeyValid;

					break;
				case Key.KeyType.Private:

					if (ManualPrivateKeyTextBox.Text == string.Empty) return;

					ReadPrivateXMLKey(ManualPrivateKeyTextBox.Text);
					MessageBox.Show(isManualPrivateKeyValid.ToString());
					isValidated = isManualPrivateKeyValid;

					break;
			}

			EnableManualValidationMessage(true, isValidated);
		}

		private void ManualPublicKeyTextBox_TextChanged(object sender, EventArgs e)
		{
			isManualPublicKeyValid = false;

			EnableManualValidationMessage(false);
		}

		private void ManualPrivateKeyTextBox_TextChanged(object sender, EventArgs e)
		{
			isManualPrivateKeyValid = false;

			EnableManualValidationMessage(false);
		}

		private void ReadPublicXMLKey(string key)
		{
			var readKey = ReadXML(key, 2);

			var n64 = readKey[0];
			var e64 = readKey[1];

			BigInteger e = new BigInteger(Convert.FromBase64String(e64));

			if (e > 1 && e % 2 != 0)
			{
				if (KeyType == Key.KeyType.Public || KeyType == Key.KeyType.PublicAndPrivate)
				{
					n64Value = n64;
					e64Value = e64;
					isManualPublicKeyValid = true;
				}
			}
			else
				isManualPublicKeyValid = false;
		}

		private void ReadPrivateXMLKey(string key)
		{
			var readKey = ReadXML(key, 5);

			string n64 = readKey[0], e64 = readKey[1], p64 = readKey[2], q64 = readKey[3], d64 = readKey[4];

			BigInteger n = new BigInteger(Convert.FromBase64String(n64));
			BigInteger e = new BigInteger(Convert.FromBase64String(e64));
			BigInteger p = new BigInteger(Convert.FromBase64String(p64));
			BigInteger q = new BigInteger(Convert.FromBase64String(q64));
			BigInteger d = new BigInteger(Convert.FromBase64String(d64));

			bool isValidated = false;

			if (e > 1 && e % 2 != 0)
			{
				if (ValidatePrimeParameter(e, p, true) && ValidatePrimeParameter(e, q, true))
				{
					if (p * q == n)
					{
						if (CalculateD(e, (p - 1) * (q - 1)) == d)
						{
							isValidated = true;
							isManualPrivateKeyValid = true;

							n64Value = n64;
							e64Value = e64;
							p64Value = p64;
							q64Value = q64;
							d64Value = d64;
						}
					}
				}
			}

			if (!isValidated)
			{
				isManualPrivateKeyValid = false;
			}
		}

		private string[] ReadXML(string xml, int paramsAmount)
		{
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

		private void ManualGenerateKeysButton_Click(object sender, EventArgs e)
		{
			n64Value = Convert.ToBase64String(NValue.ToByteArray());
			e64Value = Convert.ToBase64String(EValue.ToByteArray());
			p64Value = Convert.ToBase64String(PValue.ToByteArray());
			q64Value = Convert.ToBase64String(QValue.ToByteArray());
			d64Value = Convert.ToBase64String(DValue.ToByteArray());

			string publicKeyString = "<RSAKeyValue><Modulus>" + n64Value + "</Modulus><Exponent>" + e64Value + "</Exponent></RSAKeyValue>";

			string privateKeyString = "<RSAKeyValue><Modulus>" + n64Value + "</Modulus><Exponent>" + e64Value + "</Exponent><P>" + p64Value + "</P><Q>" + q64Value + "</Q><D>" + d64Value + "</D></RSAKeyValue>";

			ManualPublicKeyTextBox.Text = publicKeyString;
			ManualPrivateKeyTextBox.Text = privateKeyString;

			isManualPublicKeyValid = true;
			isManualPrivateKeyValid = true;

			EnableManualValidationMessage(true, true);
		}

		private void EnableManualValidationMessage(bool enable, bool validated = false)
		{
			ManualKeyValidationButton.Visible = !enable;
			ManualKeyValidationMessage.Visible = enable;
			ManualKeyValidationMessage.ForeColor = validated ? Color.LimeGreen : Color.Red;

			if ((Key.KeyType)KeyTypeDropdown.SelectedItem == Key.KeyType.PublicAndPrivate)
				ManualKeyValidationMessage.Text = validated ? "Chaves válidas" : "Chaves inválidas";
			else
				ManualKeyValidationMessage.Text = validated ? "Chave válida" : "Chave inválida";
		}

		//

		//Validation

		private void ValidateParamater(Button button, ref bool paramater, bool isValid)
		{
			paramater = isValid;
			button.Enabled = false;
			button.Text = isValid ? "Válido" : "Inválido";
		}

		private void ResetValidationButton(Button button)
		{
			button.Enabled = true;
			button.ForeColor = Color.Black;
			button.Text = "Validar";
		}

		//

		#endregion

		#region Input Methods

		private string DigitText(string text)
		{
			string digitText = text;

			foreach (char c in text)
			{
				if (!char.IsDigit(c))
					digitText = text.Replace(c.ToString(), string.Empty);
			}

			return digitText;
		}

		#endregion
		*/
	}
}
