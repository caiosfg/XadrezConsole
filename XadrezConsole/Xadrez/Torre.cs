using System;
using Tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(Campo camp, Cor cor) : base(camp, cor)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
