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
                    if (camp.peca(i, j) == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(camp.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" A B C D E F G H");
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

        }
    }
}
