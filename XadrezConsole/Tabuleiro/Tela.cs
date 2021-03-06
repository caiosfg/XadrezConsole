﻿using System;
using Tabuleiro;
using Xadrez;
using System.Collections.Generic;

namespace Tabuleiro
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.camp);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Turno : "+partida.turno);
<<<<<<< HEAD
            Console.WriteLine("Aguardando jogada : "+ partida.jogadorAtual);
            if (partida.xeque)
            {
                Console.WriteLine("XEQUE !");
            }
        
=======
            Console.WriteLine("Aguardando jogada : "+ partida.jogadorAtual);   
            if (partida.xeque)
            {
                Console.Write("XEQUE !");
            }
>>>>>>> ddb8078c3647efc7058fee52121f8e8f819b2662
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
          Console.WriteLine("Peças Capturadas :");
          ConsoleColor aux = Console.ForegroundColor;
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("Brancas :");
          imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
          Console.ForegroundColor = aux;
          Console.WriteLine();
          Console.Write("Pretas :");
          imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
          Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach( Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

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
