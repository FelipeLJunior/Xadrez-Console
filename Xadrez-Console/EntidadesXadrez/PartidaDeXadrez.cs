using System;
using EntidadesTabuleiro;
using EntidadesTabuleiro.Enums;
using EntidadesTabuleiro.Exceptions;
using EntidadesXadrez;

namespace EntidadesXadrez
{
    internal class PartidaDeXadrez
    {
        private HashSet<Peca> _pecas;
        private HashSet<Peca> _capturadas;
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
            _pecas = new HashSet<Peca>();
            _capturadas = new HashSet<Peca>();
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
            if(pecaCapturada != null) 
            { 
                _capturadas.Add(pecaCapturada);
            }
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

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> pecasDeUmaCor = new HashSet<Peca>();
            foreach(Peca capturada in _capturadas)
            {
                if(capturada.Cor == cor)
                {
                    pecasDeUmaCor.Add(capturada);
                }
            }

            return pecasDeUmaCor;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> pecasDeUmaCor = new HashSet<Peca>();
            foreach(Peca peca in _pecas)
            {
                if(peca.Cor == cor)
                {
                    pecasDeUmaCor.Add(peca);
                }
            }

            pecasDeUmaCor.ExceptWith(PecasCapturadas(cor));
            return pecasDeUmaCor;
        }

        public void ColocarNovaPeca(Peca peca, char coluna, int linha)
        {
            Tabuleiro.AdicionarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            _pecas.Add(peca);
        }

        public void ColocarPecas()
        {
           
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Branca), 'c', 1);
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Branca), 'c', 2);
            ColocarNovaPeca(new Rei(Tabuleiro, Cor.Branca), 'd', 1);
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Branca), 'd', 2);
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Branca), 'e', 1);
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Branca), 'e', 2);

            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Preta), 'c', 7);
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Preta), 'c', 8);
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Preta), 'd', 7);
            ColocarNovaPeca(new Rei(Tabuleiro, Cor.Preta), 'd', 8);            
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Preta), 'e', 8);
            ColocarNovaPeca(new Torre(Tabuleiro, Cor.Preta), 'e', 7);
        }
    }
}
