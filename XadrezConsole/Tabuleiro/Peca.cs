namespace Tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Campo camp { get; protected set; }

        public Peca(Posicao posicao, Campo camp, Cor cor)
        {
            this.posicao = posicao;
            this.camp = camp;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

    }
}