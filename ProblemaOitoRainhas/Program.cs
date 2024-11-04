using ProblemaOitoRainhas;

namespace ProblemaOitoRainhas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TabuleiroGUI tabuleiroGUI = new TabuleiroGUI();

            tabuleiroGUI.IniciarTabuleiro();
            Console.ReadLine();
        }
    }
}
