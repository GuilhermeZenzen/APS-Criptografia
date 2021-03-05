using System;
using System.Numerics;
using System.Security.Cryptography;

namespace Encryptor
{
	// Clase usada para a geração da chave pública e privada
	public class ManualKeyGenerator
	{
		// Propriedas para guardar os resultados
		public int Exponent { get; set; }
		public BigInteger P { get; set; }
		public BigInteger Q { get; set; }
		public BigInteger Modulus { get; set; }
		public BigInteger D { get; set; }
		public BigInteger DP { get; set; }
		public BigInteger DQ { get; set; }
		public BigInteger InverseQ { get; set; }

		// Variáveis que guardam o último número obtido ao gear p ou q,
		// com utilidade de utilizá-los caso não seja possível gerar um novo p ou q
		private BigInteger lastP, lastQ;

		#region Exponent

		// Recebe como parâmetros um valor mínimo e maximo que serão usados para gerar um número aleatório
		public int GenerateExponent(int min, int max)
		{
			// Cria um agente de aleatoriedade
			Random random = new Random();

			// Caso o parâmetro min seja menor ou igual à 2
			if (min <= 2)
				// min recebe 3
				min = 3;

			// Gera um número aleatório entre min e max
			int exponent = random.Next(min, max + 1);
			
			// Caso o expoente seja par
			if(exponent % 2 == 0)
			{
				// Se o expoente for menor que max
				if (exponent < max)
					// Expoente é acrescentado, se tornando ímpar
					exponent++;
				// Senão
				else
					// Expoente é  , se tornando ímpar
					exponent--;
			}

			// Atribui o expoente da variável local para a proprieda Exponent
			this.Exponent = exponent;

			// Retorna o expoente
			return this.Exponent;
		}

		// Recebe como parâmetro um expoente e verifica se ele cumpre os requisitos
		public void VerifyExponent(int exponent)
		{
			// Caso o parâmetro exponent seja 0
			if(exponent == 0)
			{
				// Atribui o valor zero a proprieda Exponent
				this.Exponent = 0;

				//Retorna
				return;
			}

			// Se o expoente for menor ou igual à 2 ou for par
			if (exponent <= 2 || exponent % 2 == 0)
			{
				// Atribui o valor zero para a proprieda
				this.Exponent = 0;
			}
			// Senão
			else
			{
				// Atribui o parâmetro exponent para a proprieda ExponentExponent
				this.Exponent = exponent;
			}
		}

		#endregion

		#region P & Q

		// Verifica P, recebendo como parâmetro o valor de P a ser verificado
		public void VerifyP(BigInteger p)
		{
			// Se p é igual à 0
			if (p == 0)
			{
				// this.P recebe 0
				this.P = p;

				// Retorna
				return;
			}

			// Verifica se p cumpre os requisitos: número primo e coprimo ao expoente
			if (VerifyPrimeParamater(p))
				// this.P recebe p
				this.P = p;
			// Senão
			else
				// this.P recebe 0
				this.P = 0;
		}

		// Verifica Q, recebendo como parâmetro o valor de Q a ser verificado
		public void VerifyQ(BigInteger q)
		{
			// Se q é igual à 0
			if (q == 0)
			{
				// this.Q recebe 0
				this.Q = q;

				// Retorna
				return;
			}

			// Verifica se q cumpre os requisitos: número primo e coprimo ao expoente
			if (VerifyPrimeParamater(q))
				// this.Q recebe q
				this.Q = q;
			// Senão
			else
				// this.Q recebe 0
				this.Q = 0;
		}

		// Verificação genérica de um parâmetro primo, recebendo como parâmetro valor a ser checado
		private bool VerifyPrimeParamater(BigInteger param)
		{
			// Checa se param é primo e coprimo ao expoente
			if (IsPrime(param, 40) && BigInteger.GreatestCommonDivisor(param - 1, new BigInteger(Exponent)) == 1)
				// Retorna verdadeiro
				return true;
			// Caso não seja
			else
				// Retorna falso
				return false;
		}

		// Gera P e retorna um boolean informando se a geração foi bem sucedida
		public bool GenerateP(int size)
		{
			// Cria um BigInteger que recebe o valor retorna pelo método que recebe size como parâmetro
			BigInteger p = GeneratePrimeParamater(size, ref lastP);

			// Se p for maior que 0
			if (p > 0)
			{
				// this.P = p
				this.P = p;

				// Retorna verdadeiro
				return true;
			}
			// Senão
			else
				// Retorna falso
				return false;
		}

		// Gera Q e retorna um boolean informando se a geração foi bem sucedida
		public bool GenerateQ(int size)
		{
			// Cria um BigInteger que recebe o valor retorna pelo método que recebe size como parâmetro
			BigInteger q = GeneratePrimeParamater(size, ref lastQ);

			// Se q for maior que 0
			if (q > 0)
			{
				// this.Q = q
				this.Q = q;

				// Retorna verdadeiro
				return true;
			}
			// Senão
			else
				// Retorna falso
				return false;
		}

		// Geração genérica de um parâmetro primo, recebendo como parâmetro o tamanho em bits do valor a ser gerado
		private BigInteger GeneratePrimeParamater(int size, ref BigInteger lastGenerated)
		{
			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
			{
				// Cria um int para armazenar o tamanho do valor que deve ser gerado em bytes, isso é feito dividindo o tamanho em bits por 8
				int byteSize = size / 8;

				// Cria um array de bytes para armazenar o número gerado em bytes
				var paramData = new byte[byteSize];

				// Cria um BigInteger para receber os bytes aleatórios
				BigInteger param = 0;

				// Repita
				do
				{
					// Gera um valor em bytes aleatório
					rng.GetBytes(paramData);

					// Converte o array de bytes para BigInteger e o armazena
					param = BuildPositiveBigInteger(paramData);
				}
				// até que o valor gerado esteja dentro dos limites
				while (param >= new BigInteger(Math.Pow(2, size) - 1) || param <= new BigInteger(Math.Pow(2, size - 1) - 1));

				// Se param for par
				if (param % 2 == 0)
					// param é acrescentado
					param++;

				// Cria um BigInteger para armazenar o valor padrão de param
				BigInteger defaultParam = param;

				// Boolean que indica se o tamanho em bits
				bool hittedMax = false;

				// Quando esse boolean for verdadeiro é porque o último número gerado foi um candidato na iteração em busca de um número elegível. Caso essa iteração falhe e esse boolean seja verdadeiro, param receberá o último número gerado
				bool canRepeatNumber = false;

				// Enquanto param não for primo ou não for coprimo com o expoente
				while (!IsPrime(param, 40) || BigInteger.GreatestCommonDivisor(param - 1, new BigInteger(Exponent)) != 1 || param == lastGenerated)
				{
					// Checa se param é igual ao último número gerado
					if (param == lastGenerated)
						// Se for, canRepeatNumber torna-se verdadeiro
						canRepeatNumber = true;

					// Se param for maior ou igual ao limite máximo determinado pela quantidade de bits
					if (param >= new BigInteger(Math.Pow(2, size) - 1))
					{
						// A quantidade de bits de param ultrapassou a quantidade exigida, então param atingiu o máximo
						hittedMax = true;

						// É atribuído à param seu valor padrão
						param = defaultParam;
					}
					// Senão, caso param seja menor ou igual ao limite mínimo determinado pela quantidade de bits
					else if (param <= new BigInteger(Math.Pow(2, size - 1) - 1))
					{
						// Se pode repetir o número,
						if (canRepeatNumber)
							// retorna o último número gerado
							return lastGenerated;
						// Senão,
						else
							// é assumido que não há um número que cumpra os requisitos com o tamanho definido, retornando 0
							return 0;
					}

					// Se param ainda não atingiu o limite
					if (!hittedMax)
						// param é incrementado
						param += 2;
					// Senão
					else
						// param é decrementado
						param -= 2;
				}

				// Salva o número gerado como o último número gerado
				lastGenerated = param;

				// Retorna param
				return param;
			}
		}

		// Checa se o número passado como parâmetro é primo,
		// usando o teste de primalidade de Miller-Rabin
		public bool IsPrime(BigInteger number, int certainty)
		{
			// Se o número for menor que 2 ou par, retorna a igualdade desse número com 2
			if ((number < 2) || number % 2 == 0) return number == 2;

			BigInteger d = number - 1;
			int s = 0;

			// Enquanto d for par
			while(d % 2 == 0)
			{
				d /= 2;
				s += 1;
			}

			// Cria um agente de aleatoriedade
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

			// Cria um byte array para guardar os bytes aleatórios
			var bytes = new byte[number.ToByteArray().LongLength];

			// Cria um BigInteger para receber os bytes
			BigInteger a;

			for(int i = 0; i < certainty; i++)
			{
				// Repita
				do
				{
					// Gera bytes aleatórios
					rng.GetBytes(bytes);

					// Atribui à a um BigInteger criado usando os bytes
					a = new BigInteger(bytes);
				}
				// enquanto a for menor que 2 ou maior ou igual à number - 2
				while (a < 2 || a >= number - 2);

				BigInteger x = BigInteger.ModPow(a, d, number);

				// Se x for igual à 1 ou à number - 1, significa que nessa iteração, 
				// number foi considerado primo, mas por uma questão se segurança no resultado,
				// os cálculos são realizados novamente por certainty vezes.
				// Como nessa iteração já foi testada a primalidade de number,
				// não há necessidade de testar de outras formas, então é usado o comando continue,
				// que causa ao programa ignorar os comandos após ele e prosseguir para a próxima iteração
				if (x == 1 || x == number - 1) continue;

				// Os seguintes comandos são executados até que x sejá igual à 1 ou number - 1
				for(int r = 1; r < s; r++)
				{
					// x recebe a potêncialização modular
					x = BigInteger.ModPow(x, 2, number);

					// Se x for igual à 1, significa que o número não é primo,
					// e ser considerado não primo uma única vez por esse algoritmo,
					// já é suficiente para que se saiba que o número não é primo,
					// excluindo a necessidade de uma nova iteração para confirmar o resultado,
					// então é retornado falso, assim saindo desse método
					if (x == 1) return false;

					// Se x for igual à number - 1, então não há necessidade de testar além
					// então é usado o break para sair do laço
					if (x == number - 1) break;
				}

				// Há a possibilidade do programa ter saído do laço em sua última iteração, onde r == s,
				// então é testado se x é difente de number - 1, onde caso a resposta sejá sim
				// é retornado falso
				if (x != number - 1) return false;
			}

			// Após inumeras iterações, repetindo os testes, se a execução do método chegou até aqui,
			// é porque number é primo
			return true;
		}

		#endregion

		#region Modulus & Phi Modulus

		// Gera o módulo, ação realizada através da fórmula N = P * Q
		public BigInteger GenerateModulus()
		{
			// Armazena o resultado na proprieda Modulus
			Modulus = P * Q;

			// Retorna o módulo
			return Modulus;
		}

		// Gera o phi do módulo, ação realizada através da fórmula φ(N) = (P - 1) * (Q - 1)
		public BigInteger GeneratePhiModulus()
		{
			// Retorna o phi do módulo
			return (P - 1) * (Q - 1);
		}

		#endregion

		#region D

		// Gera D(Expoente privado)
		public BigInteger GenerateD()
		{
			// Atribui D
			D = CalculateD(Exponent, (P - 1) * (Q - 1));

			// Retorna D
			return D;
		}

		// Cálcula D usando o Algoritmo Extendido 
		public BigInteger CalculateD(int exponent, BigInteger modulus)
		{
			BigInteger x = 0, y = 0;
			BigInteger g = ExtendedGCD(exponent, modulus, ref x, ref y);

			return (x % modulus + modulus) % modulus;
		}

		// Algoritmo de Euclides Extendido, usando chamadas recursivas
		private BigInteger ExtendedGCD(BigInteger a, BigInteger b, ref BigInteger x, ref BigInteger y)
		{
			// Condição de saída, onde a descida de método para método terminará
			// e se iniciará uma ação reversa, como uma escalada
			if (a == 0)
			{
				x = 0;
				y = 1;

				// Retorna b
				return b;
			}

			BigInteger x1 = 0, y1 = 0;

			// Chamando a sí mesmo, quando uma das chamadas possui os requisistos da condição de saída,
			// os comandos após esse em todas as instâncias de métodos chamados serão executados
			// e será uma espécie de escalada dos valores do último método chamado até o primeiro,
			// onde o valor desejado será retornado
			BigInteger gcd = ExtendedGCD(b % a, a, ref x1, ref y1);

			x = y1 - (b / a) * x1;
			y = x1;

			// Retorna
			return gcd;
		}

		#endregion

		#region DP & DQ

		// Gera DP, que é útil na descriptografia usando o Teorema Chinês do Resto 
		public void GenerateDP()
		{
			DP = D % (P - 1);
		}

		// Gera DQ, que é útil na descriptografia usando o Teorema Chinês do Resto
		public void GenerateDQ()
		{
			DQ = D % (Q - 1);
		}

		#endregion

		#region InverseQ

		// Gera InverseQ, que é útil na descriptografia usando o Teorema Chinês do Resto
		public void GenerateInverseQ()
		{
			InverseQ = (1 / Q) % P;
		}

		#endregion

		// Gera um BigInteger garantido de ser positivo
		private BigInteger BuildPositiveBigInteger(byte[] bytes)
		{
			// Cria um array com tamanho de um a mais que o array passado como parâmetro
			var positiveBytes = new byte[bytes.Length + 1];

			// Copia o parâmetro array para o array local
			bytes.CopyTo(positiveBytes, 0);

			// Retorna um BigInteger usando o array positivo
			return new BigInteger(positiveBytes);
		}
	}
}
