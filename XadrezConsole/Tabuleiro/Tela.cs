using System;
using Tabuleiro;

namespace Tabuleiro
{
    class Tela
    {

        public static void imprimirTabuleiro(Campo camp)
        {
            for (int i = 0; i < camp.linhas; i++)
            {
                for (int j = 0; j < camp.colunas; j++)
                {
                    if (camp.peca(i, j) == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(camp.peca(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
