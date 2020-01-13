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
        public bool xeque {get; private set}


        public PartidaDeXadrez()
        {
            camp = new Campo(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = camp.retirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = camp.retirarPeca(destino);
            camp.colocarPeca(p, destino);

            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = camp.retirarPeca(destino);
            p.decrementarQteMovimentos();
            if(pecaCapturada != null)
            {
                camp.colocarPeca(pecaCapturada,destino);
                capturadas.Remove(pecaCapturada);

                camp.colocarPeca(p, destino);
            }
        
        }

        public void realizaJogada (Posicao origem, Posicao destino)
	    {
            Peca pecaCapturada = executaMovimento(origem, destino);
            
            if(estaEmCheque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroExceptions("Você não pode se colocar em Xeque !");
            }
            if(estaEmCheque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

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

        private Cor adversaria(Cor cor)
        {
          if(cor == Cor.Branca)
          {
            return Cor.Preta;
          }
          else
          {
            return Cor.Branca;  
          }
        }

        private Peca rei (Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmCheque (Cor cor)
        {
            foreach(Peca x in pecasEmJogo(adversaria(cor)))
            {
                Peca R = rei(cor);
                
                if(R == null)
                {
                    throw new TabuleiroExceptions("Não existe Rei da Cor" + cor+ "no Tabuleiro !");
                }

                bool[,] mat = x.movimentosPossiveis();
                if(mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
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
