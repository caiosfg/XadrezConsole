using System;
using Tabuleiro;
using Xadrez;

namespace Tabuleiro
{
    class Tela
    {

        public static void imprimirTabuleiro(Campo camp)
        {
            
            for (int i = 0; i < camp.linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 -i + " ");
                
                for (int j = 0; j < camp.colunas; j++)
                {
                 Console.ForegroundColor = ConsoleColor.Green;
                 ImprimirPeca(camp.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  A B C D E F G H");
        }

        public static void imprimirTabuleiro(Campo camp, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < camp.linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 -i + " ");
                
                for (int j = 0; j < camp.colunas; j++)
                {
                 if(posicoesPossiveis[i, j]) 
                 {
                    Console.BackgroundColor = fundoAlterado;
                    Console.ForegroundColor = ConsoleColor.Green;
                 }
                 else 
                 {
                  Console.BackgroundColor = fundoOriginal;
                 }
                  ImprimirPeca(camp.peca(i, j));
                  Console.BackgroundColor = fundoOriginal;
                }           
                
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if(peca == null)
            {
                 Console.Write("- ");
            }
            else
            {
            if(peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
                   Console.Write(" ");
            }

        }
    }
}
