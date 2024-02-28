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
    }
}