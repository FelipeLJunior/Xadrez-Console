using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;

namespace EntidadesXadrez
{
    internal class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor)
            : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] PossiveisMovimentos()
        {
            bool[,] possiveisMovimentos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicaoProvavel = new Posicao(0, 0);

            // Acima
            posicaoProvavel.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
            }
            
            // Nordeste
            posicaoProvavel.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
            }
            
            // Direita
            posicaoProvavel.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
            }
            
            // Sudeste
            posicaoProvavel.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
            }
            
            // Abaixo
            posicaoProvavel.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
            }
            
            // Sudoeste
            posicaoProvavel.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
            }
            
            // Esquerda
            posicaoProvavel.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
            }
            
            // Noroeste
            posicaoProvavel.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if(Tabuleiro.VerificarPosicao(posicaoProvavel) && PodeMover(posicaoProvavel))
            {
                possiveisMovimentos[posicaoProvavel.Linha, posicaoProvavel.Coluna] = true;
            }

            return possiveisMovimentos;
        }
    }
}
