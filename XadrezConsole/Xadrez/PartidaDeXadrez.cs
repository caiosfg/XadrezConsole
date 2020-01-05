using System;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Campo camp { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }


        public PartidaDeXadrez()
        {
            camp = new Campo(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = camp.retirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = camp.retirarPeca(destino);
            camp.colocarPeca(p, destino);
        }
        public void colocarPecas()
        {
            camp.colocarPeca(new Torre(camp, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            camp.colocarPeca(new Torre(camp, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            camp.colocarPeca(new Torre(camp, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            camp.colocarPeca(new Torre(camp, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            camp.colocarPeca(new Torre(camp, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            camp.colocarPeca(new Rei(camp, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            camp.colocarPeca(new Torre(camp, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            camp.colocarPeca(new Torre(camp, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            camp.colocarPeca(new Torre(camp, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            camp.colocarPeca(new Torre(camp, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            camp.colocarPeca(new Torre(camp, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            camp.colocarPeca(new Rei(camp, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());

        }



    }
}
