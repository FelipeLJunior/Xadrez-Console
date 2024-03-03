using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;

namespace EntidadesXadrez
{
    internal class Peao : Peca
    {
        public Peao(Tabuleiro tabuleiro, Cor cor)
            : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);

            return peca != null && peca.Cor != Cor;
        }

        private bool Livre(Posicao posicao)
        {
            return Tabuleiro.Peca(posicao) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao provavelPosicao = new Posicao(0, 0);

            if(Cor == Cor.Branca)
            {
                provavelPosicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if(PodeMover(provavelPosicao) && Tabuleiro.PosicaoValida(provavelPosicao) && QuantidadeMovimentos == 0)
                {
                    movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                }

                provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if(PodeMover(provavelPosicao) && Tabuleiro.PosicaoValida(provavelPosicao))
                {
                    movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                }
                
                provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if(Tabuleiro.PosicaoValida(provavelPosicao) && ExisteInimigo(provavelPosicao))
                {
                    movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                }

                provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if(Tabuleiro.PosicaoValida(provavelPosicao) && ExisteInimigo(provavelPosicao))
                {
                    movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                }
                return movimentosPossiveis;
            }
                
            provavelPosicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
            if(PodeMover(provavelPosicao) && Tabuleiro.PosicaoValida(provavelPosicao) && QuantidadeMovimentos == 0)
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if(PodeMover(provavelPosicao) && Tabuleiro.PosicaoValida(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }
                
            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && ExisteInimigo(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && ExisteInimigo(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            return movimentosPossiveis;
        }
    }
}
