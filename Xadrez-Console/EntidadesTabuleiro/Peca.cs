using EntidadesTabuleiro.Enums;

namespace EntidadesTabuleiro
{
    internal abstract class Peca
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

        public void DecrementarMovimento()
        {
            QuantidadeMovimentos--;
        }

        public bool PodeMover(Posicao posicao)
        {
            Peca pecaNoDestino = Tabuleiro.Peca(posicao);

            return pecaNoDestino == null || pecaNoDestino.Cor != Cor;
        }

        public bool ExisteMovimento(Posicao pos)
        {
            bool[,] movimentosPossiveis = MovimentosPossiveis();
            for(int  i = 0; i < Tabuleiro.Linhas; i++)
            {
                for(int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (movimentosPossiveis[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PossibilidadeDeMovimento(Posicao posicao)
        {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
