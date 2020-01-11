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
        private bool podeMover(Posicao pos)
        {
            Peca p = camp.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[camp.linhas, camp.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while(camp.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(camp.peca(pos) != null && camp.peca(pos).cor !=cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1 ;
            }
            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while(camp.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(camp.peca(pos) != null && camp.peca(pos).cor !=cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1 ;
            }
            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while(camp.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(camp.peca(pos) != null && camp.peca(pos).cor !=cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1 ;
            }
            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while(camp.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(camp.peca(pos) != null && camp.peca(pos).cor !=cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1 ;
            }

            
            return mat;
        }   
    }
}
