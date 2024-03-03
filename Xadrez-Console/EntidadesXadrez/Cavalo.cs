using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;

namespace EntidadesXadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor)
            : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "C";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao provavelPosicao = new Posicao(0, 0);

            provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            provavelPosicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            provavelPosicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }
 
            provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            // 
            provavelPosicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            // 
            provavelPosicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            // 
            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            return movimentosPossiveis;
        }
    }
}
