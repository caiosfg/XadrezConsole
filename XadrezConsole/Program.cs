﻿using System;
using Tabuleiro;
using Xadrez;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);


                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoDeOrigem(origem);
                    
                        bool[,] posicoesPossiveis = partida.camp.peca(origem).movimentosPossiveis();
                    
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.camp, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroExceptions e)
            {
                Console.Write(e.Message);
            }
            Console.ReadLine();
        }
    }
}
