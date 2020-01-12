using System;
using Tabuleiro;
using System.Collections.Generic;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Campo camp { get; private set; }
        public int turno {get; private set;}
        public Cor jogadorAtual {get; private set;}
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;


        public PartidaDeXadrez()
        {
            camp = new Campo(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = camp.retirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = camp.retirarPeca(destino);
            camp.colocarPeca(p, destino);

            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
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

        public void validarPosicaoDeDestino (Posicao origem, Posicao destino)
    	{
            if(!camp.peca(origem).podeMoverPara(destino))
            {
              throw new TabuleiroExceptions("Posição de destino inválida!");
            }
	    }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
             foreach(Peca x in capturadas)
             {
              if(x.cor == cor)
              {
                aux.Add(x);
              }
             }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
         HashSet<Peca> aux = new HashSet<Peca>();
          foreach(Peca x in pecas)
          {
           if(x.cor == cor)
           {
             aux.Add(x);
           }
          }
          aux.ExceptWith(pecasCapturadas(cor));
          return aux;
        }
            
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            camp.colocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        public void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(camp, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(camp, Cor.Branca));
            colocarNovaPeca('d', 2 ,new Torre(camp, Cor.Branca));
            colocarNovaPeca('e', 2 ,new Torre(camp, Cor.Branca));
            colocarNovaPeca('e', 1 ,new Torre(camp, Cor.Branca));
            colocarNovaPeca('d', 1 ,new Rei(camp, Cor.Branca));
            
            colocarNovaPeca('c', 7 ,new Torre(camp, Cor.Preta));
            colocarNovaPeca('c', 8 ,new Torre(camp, Cor.Preta));
            colocarNovaPeca('d', 7 ,new Torre(camp, Cor.Preta));
            colocarNovaPeca('e', 7 ,new Torre(camp, Cor.Preta));
            colocarNovaPeca('e', 8 ,new Torre(camp, Cor.Preta));
            colocarNovaPeca('d', 8 ,new Rei(camp, Cor.Preta));

        }

    }
}
