using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;

namespace EntidadesXadrez
{
    internal class Rei : Peca
    {
        private readonly PartidaDeXadrez _partida;

        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida)
            : base(tabuleiro, cor)
        {
            _partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool TorreValidaParaRoque(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);

            return peca != null && peca.Cor == Cor && peca.QuantidadeMovimentos == 0 && peca is Torre;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao provavelPosicao = new Posicao(0, 0);

            // Acima
            provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }
            
            // Nordeste
            provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }
            
            // Direita
            provavelPosicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }
            
            // Sudeste
            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }
            
            // Abaixo
            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }
            
            // Sudoeste
            provavelPosicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }
            
            // Esquerda
            provavelPosicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }
            
            // Noroeste
            provavelPosicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(provavelPosicao) && PodeMover(provavelPosicao))
            {
                movimentosPossiveis[provavelPosicao.Linha, provavelPosicao.Coluna] = true;
            }

            // #Jogada especial: roque
            if(!_partida.Xeque && QuantidadeMovimentos == 0)
            {
                // Roque pequeno
                Posicao posicaoInicialDaTorreMaisProxima = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if(TorreValidaParaRoque(posicaoInicialDaTorreMaisProxima))
                {
                    Posicao posicaoInicialDoBispoMaisProximo = new Posicao(Posicao.Linha, Posicao.Coluna + 1); 
                    Posicao posicaoInicialDoCavaloMaisProximo = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if(Tabuleiro.Peca(posicaoInicialDoBispoMaisProximo) == null && Tabuleiro.Peca(posicaoInicialDoCavaloMaisProximo) == null)
                    {
                        movimentosPossiveis[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // Roque pequeno
                Posicao posicaoInicialDaTorreMaisDistante = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if(TorreValidaParaRoque(posicaoInicialDaTorreMaisDistante))
                {
                    Posicao posicaoInicialDaDama = new Posicao(Posicao.Linha, Posicao.Coluna - 1); 
                    Posicao posicaoInicialDoBispoMaisDistanteDoRei = new Posicao(Posicao.Linha, Posicao.Coluna - 2); 
                    Posicao posicaoInicialDoCavaloMaisDistanteDoRei = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if(Tabuleiro.Peca(posicaoInicialDaDama) == null 
                        && Tabuleiro.Peca(posicaoInicialDoBispoMaisDistanteDoRei) == null
                        && Tabuleiro.Peca(posicaoInicialDoCavaloMaisDistanteDoRei) == null)
                    {
                        movimentosPossiveis[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return movimentosPossiveis;
        }
    }
}
