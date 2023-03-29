using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forca
{
    internal class Program

    {
        static void DesenharForca(int quantidadeErros)
        {
            string cabecaDoBoneco = quantidadeErros >= 1 ? " o " : " ";
            string bracoEsquerdo = quantidadeErros >= 3 ? "/" : " ";
            string tronco = quantidadeErros >= 2 ? "x" : " ";
            string troncoBaixo = quantidadeErros >= 2 ? " x " : " ";
            string bracoDireito = quantidadeErros >= 3 ? @"\" : " ";
            string pernas = quantidadeErros >= 4 ? "/ \\" : " ";

            Console.Clear();
            Console.WriteLine(" ___________        ");
            Console.WriteLine(" |/        |        ");
            Console.WriteLine(" |        {0}       ", cabecaDoBoneco);
            Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
            Console.WriteLine(" |        {0}       ", troncoBaixo);
            Console.WriteLine(" |        {0}       ", pernas);
            Console.WriteLine(" |                  ");
            Console.WriteLine(" |                  ");
            Console.WriteLine("_|____              ");
        }

        static string PalavraAleatoria()
        {
            string[] palavras =
           {
            "ABACATE",
            "ABACAXI",
            "ACEROLA",
            "AÇAÍ",
            "ARAÇA",
            "ABACATE",
            "BACABA",
            "BACURI",
            "BANANA",
            "CAJÁ",
            "CAJÚ",
            "CARAMBOLA",
            "CUPUAÇU",
            "GRAVIOLA",
            "GOIABA",
            "JABUTICABA",
            "JENIPAPO",
            "MAÇÃ",
            "MANGABA",
            "MANGA",
            "MARACUJÁ",
            "MURICI",
            "PEQUI",
            "PITANGA",
            "PITAYA",
            "SAPOTI",
            "TANGERINA",
            "UMBU",
            "UVA",
            "UVAIA" };
            Random rand = new Random();
            string palavra = palavras[rand.Next(palavras.Length)];
            return palavra;
        }

        static char[] PalavraExibidaAoJogador(int tamanhodoArray)
        {
            char[] palavraExibida = new char[tamanhodoArray];
            for (int i = 0; i < palavraExibida.Length; i++)
            {
                palavraExibida[i] = '_';
            }
            return palavraExibida;
        }

        static void LoopPrincipalDoGame(string palavra, char[] palavraExibida, ref int erros, ref bool acertou)
        {
            while (erros < 5 && !acertou)
            {
                DesenharForca(erros);
                // Exibe a palavra parcialmente descoberta

                Console.WriteLine("Palavra: " + new string(palavraExibida));

                // Lê a próxima letra do jogador
                Console.Write("Digite uma letra: ");
                char letra = Console.ReadLine().ToUpper()[0];

                // Verifica se a letra está na palavra
                bool letraEncontrada = false;
                for (int i = 0; i < palavra.Length; i++)
                {

                    if (palavra[i] == letra)
                    {
                        palavraExibida[i] = letra;
                        letraEncontrada = true;
                    }
                }

                // Se a letra não foi encontrada, incrementa o número de erros
                if (!letraEncontrada)
                {
                    erros++;
                    Console.WriteLine("Erros: " + erros);
                }

                // Verifica se o jogador acertou a palavra
                if (new string(palavraExibida) == palavra)
                {
                    acertou = true;
                }
            }

            // Exibe o resultado final
            if (acertou)
            {
                Console.WriteLine("Parabéns, você acertou a palavra!");
            }
            else
            {
                Console.WriteLine("Você perdeu, a palavra era: " + palavra);
            }
        }

        static void Main(string[] args)
        {
            string palavra = PalavraAleatoria();
            // Inicializa a palavra a ser exibida ao jogador com traços
            char[] palavraExibida = PalavraExibidaAoJogador(palavra.Length);
            // Inicializa variáveis de controle do jogo
            int erros = 0;
            bool acertou = false;
            DesenharForca(4);
            LoopPrincipalDoGame(palavra, palavraExibida, ref erros, ref acertou);

        }



    }


}

