using ProblemaOitoRainhas;

namespace ProblemaOitoRainhas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeradorTabuleiro gerador = new GeradorTabuleiro();

            gerador.PosicionarRainhasNoTabuleiro();
            Console.ReadLine();
        }
    }
}
