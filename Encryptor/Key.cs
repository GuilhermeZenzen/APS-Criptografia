using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Numerics;

namespace Encryptor
{
	public class Key
	{
		public string KeyName { get; set; }
		public string PublicKeyString { get; set; }
		public string PrivateKeyString { get; set; }

		public enum KeyType { PublicAndPrivate, Public, Private }
		public KeyType keyType { get; set; }

		public enum EncryptionMode { Automatic, Manual }
		public EncryptionMode encryptionMode { get; set; }

		// Automatic
		private RSAParameters publicKey;
		public RSAParameters PublicKey
		{
			get
			{
				return publicKey;
			}
			set
			{
				publicKey = value;

				if (value.Exponent == null || value.Modulus == null) return;

				using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
				{
					csp.ImportParameters(publicKey);
					PublicKeyString = csp.ToXmlString(false);
				}
			}
		}

		private RSAParameters privateKey;
		public RSAParameters PrivateKey
		{
			get
			{
				return privateKey;
			}
			set
			{
				privateKey = value;

				if (value.Exponent == null || value.Modulus == null || value.P == null || value.Q == null || value.DP== null || value.DQ == null || value.InverseQ == null || value.D == null) return;

				using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
				{
					csp.ImportParameters(privateKey);
					PrivateKeyString = csp.ToXmlString(true);
				}
			}
		}

		// Manual
		public int Exponent { get; set; }
		private byte[] modulus;
		private byte[] p;
		private byte[] q;
		private byte[] d;
		private byte[] inverseQ;
		private byte[] dp;
		private byte[] dq;

		public BigInteger Modulus
		{
			get
			{
				if (modulus == null) return 0;

				return new BigInteger(modulus);
			}
			set
			{
				modulus = value.ToByteArray();
			}
		}
		public BigInteger P
		{
			get
			{
				if (p == null) return 0;

				return new BigInteger(p);
			}
			set
			{
				p = value.ToByteArray();
			}
		}
		public BigInteger Q
		{
			get
			{
				if (q == null) return 0;

				return new BigInteger(q);
			}
			set
			{
				q = value.ToByteArray();
			}
		}
		public BigInteger DP
		{
			get
			{
				if (dp == null) return 0;

				return new BigInteger(dp);
			}
			set
			{
				dp = value.ToByteArray();
			}
		}
		public BigInteger DQ
		{
			get
			{
				if (dq == null) return 0;

				return new BigInteger(dq);
			}
			set
			{
				dq = value.ToByteArray();
			}
		}
		public BigInteger InverseQ
		{
			get
			{
				if (inverseQ == null) return 0;

				return new BigInteger(inverseQ);
			}
			set
			{
				inverseQ = value.ToByteArray();
			}
		}
		public BigInteger D
		{
			get
			{
				if (d == null) return 0;

				return new BigInteger(d);
			}
			set
			{
				d = value.ToByteArray();
			}
		}

		public int GenerationExponent { get; set; }
		private byte[] generationP;
		private byte[] generationQ;

		public BigInteger GenerationP
		{
			get
			{
				if (generationP == null) return 0;

				return new BigInteger(generationP);
			}
			set
			{
				generationP = value.ToByteArray();
			}
		}
		public BigInteger GenerationQ
		{
			get
			{
				if (generationQ == null) return 0;

				return new BigInteger(generationQ);
			}
			set
			{
				generationQ = value.ToByteArray();
			}
		}

		public bool IsManualPublicKeyValid
        {
            get
            {
                return Exponent != 0 && Modulus != 0;
            }
        }
        public bool IsManualPrivateKeyValid
        {
            get
            {
                return IsManualPublicKeyValid && P != 0 && Q != 0 && DP != 0 && DQ != 0 && D != 0;
            }
        }

        public Key()
		{

		}

		public void SetName(string keyName)
		{
			this.KeyName = keyName;
		}
	}
}
