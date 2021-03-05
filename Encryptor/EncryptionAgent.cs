using System;
using System.Text;
using System.Security.Cryptography;
using System.Numerics;
using System.Windows.Forms;

namespace Encryptor
{
	// Classe responsável pela criptografia
    class EncryptionAgent
    {
		// Recebe como parâmetros a mensagem para criptografar, chave que deve ser usada para tal e o tipo de preenchimento
		// e retorna a mensagem criptografada
        public static string Encrypt(string plainText, Key key, bool oaep = false)
        {
			// O try é uma estrutura onde caso ocorra uma exceção no código sendo executado dentro do escopo try
			// os comandos dentro do escopo catch são executados, podendo tratar o erro
			// e evitar que o programa trave ou feche
			try
			{
				// Checa se a criptografia deve ser feita usando o RSACryptoServiceProvider
				if (key.encryptionMode == Key.EncryptionMode.Automatic)
				{
					// Cria um RSACryptoServiceProvider que será apagado quando o código sair do escopo using
					using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
					{
						// Importa para o csp a chave pública
						csp.ImportParameters(key.PublicKey);

						// Pega os bytes da mensagem
						var textData = Encoding.Unicode.GetBytes(plainText);

						// Criptografa os bytes usando o método Encrypt do csp
						var encryptedData = csp.Encrypt(textData, oaep);

						// Converte os bytes criptografados para Base64
						string encryptedText = Convert.ToBase64String(encryptedData);

						// Retorna a mensagem criptografada
						return encryptedText;
					}
				}
				// Caso não, faz a criptografia de maneira manual, usando um criptografador próprio
				else
				{
					// Pega os bytes da mensagem, os transforma em um BigInteger, eleva ao expoente da chave
					// e retorna o resto da divisão com o módulo da chave, assim criptografando a mensagem
					var encryptedInteger = BigInteger.ModPow(new BigInteger(Encoding.Unicode.GetBytes(plainText)), key.Exponent, key.Modulus);

					// Transforma o BigInteger em um array de bytes e os retorna convertidos para Base64
					return Convert.ToBase64String(encryptedInteger.ToByteArray());
				}
			}
			catch (Exception ex)
			{
				// Informa ao usuário que um erro que impossibilitou a criptografia ocorreu
				MessageBox.Show("Não é possível criptografar a mensagem. " + ex.Message);

				// Retorna uma string vazia
				return string.Empty;
			}
        }

		// Recebe como parâmetros a mensagem criptograda, chave que deve ser usada para descriptografar e o tipo de preenchimento
		// e retorna a mensagem descriptografada
        public static string Decrypt(string encryptedText, Key key, bool oaep = false)
        {
			// O try é uma estrutura onde caso ocorra uma exceção no código sendo executado dentro do escopo try
			// os comandos dentro do escopo catch são executados, podendo tratar o erro
			// e evitar que o programa trave ou feche
			try
			{
				// Checa se a mensagem deve ser descriptografada usando o RSACryptoServiceProvider
				if (key.encryptionMode == Key.EncryptionMode.Automatic)
				{
					// Cria um RSACryptoServiceProvider que será apagado quando o código sair do escopo de using
					using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
					{
						// Importa para o csp a chave privada
						csp.ImportParameters(key.PrivateKey);

						// Converte o texto criptografado e na Base64 para um array de bytes
						var encryptedData = Convert.FromBase64String(encryptedText);

						// Descriptografa os bytes usando o método Decrypt do csp
						var textData = csp.Decrypt(encryptedData, oaep);

						// Converte o array de bytes para string usando o padrão Unicode
						string plainText = Encoding.Unicode.GetString(textData);

						// Retorna a mensagem Descriptografada
						return plainText;
					}
				}
				// Caso não, descriptografa a mensagem manualmente, usando um descriptografador próprio
				else
				{
					// Cria um BigInteger usando os bytes adquiridos ao converter da Base64 a mensagem criptografada
					var encryptedInteger = new BigInteger(Convert.FromBase64String(encryptedText));

					// Realiza operações usando os parâmetros DP, DQ e InverseQ da chave privada
					// segundo o Teorema Chinês do Resto, o que resulta na descriptografia da mensagem.
					// Esse Teorema é usado pois acelera a descriptografia,
					// já que divide o valor à ser potencializado e divido em dois, o que torna a operação menor
					var m1 = BigInteger.ModPow(encryptedInteger, key.DP, key.P);
					var m2 = BigInteger.ModPow(encryptedInteger, key.DQ, key.Q);
					var h = (1 / key.Q) % key.P * (m1 - m2) % key.P;
					var decryptedData = (m2 + h * key.Q).ToByteArray();

					// Cria um array de bytes com o tamanho de decryptedData + 1,
					// esse array servirá para caso o decryptedData não tenha um tamanho par,
					// pois para transformar esses bytes para uma mensagem com caracteres se é usado o padrão Unicode,
					// o qual precisa de 2 bytes para cada caracter, significando que um array com tamanho ímpar passado à ele,
					// resultará numa mensagem incorreta
					var fixedDecryptedData = new byte[decryptedData.Length + 1];

					// Copia os bytes de decryptedData para fixedDecryptedData
					decryptedData.CopyTo(fixedDecryptedData, 0);

					// Cria uma string para guarda a mensagem em caracteres
					var decryptedText = string.Empty;

					// Se o tamanho de decryptedData for ímpar
					if (decryptedData.Length % 2 != 0)
						// Converta para Unicode usando os bytes de fixedDecryptedData
						decryptedText = Encoding.Unicode.GetString(fixedDecryptedData);
					// Senão
					else
						// Use os bytes de decryptedData
						decryptedText = Encoding.Unicode.GetString(decryptedData);

					// Retorna a mensagem descriptografada
					return decryptedText;
				}
			}
			catch (Exception ex)
			{
				// Informa ao usuário que um erro que impossibilitou a descriptografia ocorreu
				MessageBox.Show("Não é possível descriptografar a mensagem. " + ex.Message);

				// Retorna uma string vazia
				return string.Empty;
			}
        }
    }
}
