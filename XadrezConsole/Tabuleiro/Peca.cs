namespace Tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Campo camp { get; protected set; }

        public Peca(Campo camp, Cor cor)
        {
            this.posicao = null;
            this.camp = camp;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        public void IncrementarQteMovimentos()
        {
            qteMovimentos++;
        }
<<<<<<< HEAD
=======

>>>>>>> ddb8078c3647efc7058fee52121f8e8f819b2662
        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }
<<<<<<< HEAD
=======

>>>>>>> ddb8078c3647efc7058fee52121f8e8f819b2662
        public bool existeMovimentosPossiveis ()
    	{
            bool[,] mat = movimentosPossiveis();
            for(int i=0; i<camp.linhas;i++)
            {
              for(int j=0; j<camp.colunas; j ++)
              {
                if(mat[i, j] == true)
                {
                  return true;
                }
              }
            }
            return false;
	    }
        public bool podeMoverPara (Posicao pos)
    	{
            return movimentosPossiveis()[pos.linha, pos.coluna];

    	}


        public abstract bool[,] movimentosPossiveis();

    }
}