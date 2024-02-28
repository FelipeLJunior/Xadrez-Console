namespace EntidadesTabuleiro.Exceptions
{
    internal class TabuleiroException : ApplicationException
    {
        public TabuleiroException(string mensagem) 
            : base(mensagem)
        { 
        }
    }
}
