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

                Campo campo = new Campo(8, 8);

                campo.colocarPeca(new Torre(campo, Cor.Preta), new Posicao(0, 0));
                campo.colocarPeca(new Torre(campo, Cor.Preta), new Posicao(1, 3));
                campo.colocarPeca(new Rei(campo, Cor.Preta), new Posicao(0, 2));

                campo.colocarPeca(new Torre(campo, Cor.Branca), new Posicao(3, 5));

                Tela.imprimirTabuleiro(campo);
            }
            catch (TabuleiroExceptions e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
