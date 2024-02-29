using EntidadesTabuleiro.Enums;

namespace EntidadesTabuleiro
{
    internal class Peca
    {

        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QuantidadeMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QuantidadeMovimentos = 0;
        }

        public void IncrementarMovimento()
        {
            QuantidadeMovimentos++;
        }
    }
}
