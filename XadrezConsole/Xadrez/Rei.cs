using System;
using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca 
    {
        public Rei(Campo camp, Cor cor) : base(camp, cor)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
