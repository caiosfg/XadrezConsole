using System;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Campo camp { get; private set; }
        public int turno {get; private set;}
        public Cor jogadorAtual {get; private set;}
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
        public void realizaJogada (Posicao origem, Posicao destino)
	    {
            executaMovimento(origem, destino);
            turno ++;
            mudaJogador();
	    }
        private void mudaJogador ()
	    {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;            
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
	    }
        public  void validarPosicaoDeOrigem (Posicao pos)
    	{
          if(camp.peca(pos) == null)
          {
            throw new TabuleiroExceptions("Não existe peça na posição de origem escolhida !") ;
          }  
          if(jogadorAtual != camp.peca(pos).cor)
          {
            throw new TabuleiroExceptions("A peça de origem escolhida não é sua !");
          }
          if(!camp.peca(pos).existeMovimentosPossiveis())
          {
            throw new TabuleiroExceptions("Não há movimentos possíveis para a peça escolhida !");
          }

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
