using System.Reflection.Metadata.Ecma335;

namespace BlackjackCompterPoints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cartesValeurs = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            int carteValeur; //valeur de la carte
            int pointsTotal; //le total des points
            string carte;
            string infoUser;

            Console.WriteLine("hi");

            do
            {
                Console.WriteLine("carte");
                carte = Console.ReadLine();

                if (carte == "2" || carte == "3" || carte == "4" || carte == "5" || carte == "6" || carte == "7" || carte == "8" || carte == "9" || carte == "10")
                {
                    int.TryParse(carte, out carteValeur);
                    Console.WriteLine("carte = " + carteValeur);
                }
                else if (carte == "J" || carte == "Q" || carte == "K")
                {
                    carteValeur = 10;
                    Console.WriteLine("carte = " + carteValeur);
                }
                else if (carte == "A")
                {
                    Console.WriteLine("carte = 1 ou 11 ? \n type 1 for 1, anything else for 11");
                    infoUser = Console.ReadLine();

                    if (infoUser == "1")
                    {
                        carteValeur = 1;
                        Console.WriteLine("carte = " + carteValeur);
                    }
                    else
                    {
                        carteValeur = 11;
                        Console.WriteLine("carte = " + carteValeur);
                    }  
                }
                else
                {
                    Console.WriteLine("pas une carte");
                }

                    infoUser = Console.ReadLine();

            } while (infoUser == "y");
        }
    }
}
