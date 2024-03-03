using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;

namespace EntidadesXadrez
{
    internal class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) 
            : base(tabuleiro, cor) 
        { 
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao provavelPosicao = new Posicao(0, 0);

            // Nordeste
            provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;

                if(Tabuleiro.Peca(provavelPosicao) != null && Tabuleiro.Peca(provavelPosicao).Cor != Cor)
                {
                    break;
                }

                provavelPosicao.Linha--;
                provavelPosicao.Coluna++;
            }

            // Sudeste
            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;

                if(Tabuleiro.Peca(provavelPosicao) != null && Tabuleiro.Peca(provavelPosicao).Cor != Cor)
                {
                    break;
                }

                provavelPosicao.Linha++;
                provavelPosicao.Coluna++;
            }

            // Sudoeste 
            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;

                if(Tabuleiro.Peca(provavelPosicao) != null && Tabuleiro.Peca(provavelPosicao).Cor != Cor)
                {
                    break;
                }

                provavelPosicao.Linha++;
                provavelPosicao.Coluna--;
            }

            // Noroeste
            provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;

                if(Tabuleiro.Peca(provavelPosicao) != null && Tabuleiro.Peca(provavelPosicao).Cor != Cor)
                {
                    break;
                }

                provavelPosicao.Linha--;
                provavelPosicao.Coluna--;
            }

            return movimentosPossiveis;
        }
    }
}
