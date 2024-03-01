using System;
using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using EntidadesTabuleiro.Exceptions;
using EntidadesXadrez;

namespace EntidadesXadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public int Turno { get; private  set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            JogadorAtual = Cor.Branca;
            Turno = 1;
            Terminada = false;
            ColocarPecas();
        }

        public void ValidarPosicaoDeOrigem(Posicao posicao)
        {
            if(Tabuleiro.Peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça nessa posição!");
            }
            if(Tabuleiro.Peca(posicao).Cor != JogadorAtual)
            {
                throw new TabuleiroException("Essa peça pertence ao outro jogador!");
            }
            if(!Tabuleiro.Peca(posicao).ExisteMovimento(posicao))
            {
                throw new TabuleiroException("Essa peça não possui movimentos possíveis!");
            }
        }
        public void ValidarPosicaoDeDestino(Posicao posicaoDeOrigem, Posicao posicaoDeDestino)
        {
            if(!Tabuleiro.Peca(posicaoDeOrigem).PodeMoverPara(posicaoDeDestino))
            {
                throw new TabuleiroException("Não pode mover para essa posição!");
            }
        }

        public void MovimentarPeca(Posicao origem, Posicao destino)
        {
            Peca pecaSelecionada = Tabuleiro.RemoverPeca(origem);
            pecaSelecionada.IncrementarMovimento();
            Peca pecaCapturada = Tabuleiro.RemoverPeca(destino);
            Tabuleiro.AdicionarPeca(pecaSelecionada, destino);
        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            MovimentarPeca(origem, destino);
            Turno++;
            MudarJogador();
        }

        private void MudarJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ColocarPecas()
        {
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.AdicionarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());

            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.AdicionarPeca(new Rei(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.AdicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
        }
    }
}
