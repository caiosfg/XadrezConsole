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
        public abstract bool[,] movimentosPossiveis();

    }
}