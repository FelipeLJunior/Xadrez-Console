using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using System.Net.Http.Headers;

namespace EntidadesXadrez
{
    internal class Peao : Peca
    {
        private PartidaDeXadrez _partida;
        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida)
            : base(tabuleiro, cor)
        {
            _partida = partida;
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
                if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao) && QuantidadeMovimentos == 0)
                {
                    movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                }

                provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao) && !ExisteInimigo(provavelPosicao))
                {
                    movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                }
                
                provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if(Tabuleiro.PosicaoValida(provavelPosicao) && ExisteInimigo(provavelPosicao))
                {
                    movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                }

                provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if(Tabuleiro.PosicaoValida(provavelPosicao) && ExisteInimigo(provavelPosicao))
                {
                    movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
                }

                // Jogada especial: En passant
                if(Posicao.Linha == 3)
                {
                    Posicao posicaoEsquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if(Tabuleiro.PosicaoValida(posicaoEsquerda) 
                        && ExisteInimigo(posicaoEsquerda) 
                        && Tabuleiro.Peca(posicaoEsquerda) == _partida.VulneravelEnPassant)
                    {
                        movimentosPossiveis[Posicao.Linha - 1, Posicao.Coluna - 1] = true;
                    }

                    Posicao posicaoDireita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if(Tabuleiro.PosicaoValida(posicaoDireita) 
                        && ExisteInimigo(posicaoDireita) 
                        && Tabuleiro.Peca(posicaoDireita) == _partida.VulneravelEnPassant)
                    {
                        movimentosPossiveis[Posicao.Linha - 1, Posicao.Coluna + 1] = true;
                    }
                }

                return movimentosPossiveis;
            }
                
            provavelPosicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao) && QuantidadeMovimentos == 0)
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao) && !ExisteInimigo(provavelPosicao))
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

            // Jogada especial: En passant
            if (Posicao.Linha == 4)
            {
                Posicao posicaoEsquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicaoEsquerda)
                    && ExisteInimigo(posicaoEsquerda)
                    && Tabuleiro.Peca(posicaoEsquerda) == _partida.VulneravelEnPassant)
                {
                    movimentosPossiveis[posicaoEsquerda.Linha + 1, posicaoEsquerda.Coluna] = true;
                }

                Posicao posicaoDireita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicaoDireita)
                    && ExisteInimigo(posicaoDireita)
                    && Tabuleiro.Peca(posicaoDireita) == _partida.VulneravelEnPassant)
                {
                    movimentosPossiveis[posicaoDireita.Linha + 1, posicaoDireita.Coluna] = true;
                }
            }

            return movimentosPossiveis;
        }
    }
}
