using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;

namespace EntidadesXadrez
{
    internal class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor)
            : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] PossiveisMovimentos()
        {
            bool[,] possiveisMovimentos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicaoProvavel = new Posicao(0, 0);

            // Acima
            posicaoProvavel.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
                if(Tabuleiro.Peca(posicaoProvavel) != null && Tabuleiro.Peca(posicaoProvavel).Cor != Cor)
                {
                    break;
                }

                posicaoProvavel.Linha--;
            }
            
            // Direita
            posicaoProvavel.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
                if(Tabuleiro.Peca(posicaoProvavel) != null && Tabuleiro.Peca(posicaoProvavel).Cor != Cor)
                {
                    break;
                }

                posicaoProvavel.Coluna++;
            }
            
            // Abaixo
            posicaoProvavel.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
                if(Tabuleiro.Peca(posicaoProvavel) != null && Tabuleiro.Peca(posicaoProvavel).Cor != Cor)
                {
                    break;
                }
                posicaoProvavel.Linha++;
            }
            
            // Esquerda
            posicaoProvavel.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
                if(Tabuleiro.Peca(posicaoProvavel) != null && Tabuleiro.Peca(posicaoProvavel).Cor != Cor)
                {
                    break;
                }

                posicaoProvavel.Coluna--;
            }

            return possiveisMovimentos;
        }
    }
}