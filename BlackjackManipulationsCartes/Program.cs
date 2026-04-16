using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlackjackManipulationsCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cartesValeurs = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] cartesCouleurs = { "♠", "♥", "♦", "♣" };
            List<InfoCard> deck = new List<InfoCard>();
            string carte = "";
            int pointsTotal = 12;
            int points = 0;
            string infoUser;
            InfoCard card;
            string visuelCarte = "";
            InfoCard iguessvro;

            Console.WriteLine("hi");

            CreerDeck(cartesValeurs, cartesCouleurs, carte, ref deck, out iguessvro);
            ShuffleDeck(ref deck);

            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.NoName, false, false, false);

            do
            {
                Console.WriteLine("\nPress on a key (h to hit, s to stand)");
                key = Console.ReadKey(true);

                if (key.KeyChar == 'h')
                {
                    PiocherCarte(ref deck, iguessvro, visuelCarte, points, pointsTotal, out card);
                }
                else if (key.KeyChar == 's')
                {
                    Console.WriteLine("\nyou stood");
                }
                else
                {
                    Console.WriteLine("\ninput error");
                }

            } while (key.KeyChar != 's');

            //CompterPointsTest(ref deck, out points);
            //Console.WriteLine(points);
        }
        static void CreerDeck(string[] cartesValeurs, string[] cartesCouleurs, string carte, ref List<InfoCard> deck, out InfoCard iguessvro)
        {
            deck.Clear();
            iguessvro = default;

            //creation deck
            for (int i = 0; i < cartesValeurs.Length; i++)
            {
                for (int j = 0; j < cartesCouleurs.Length; j++)
                {
                    iguessvro = new InfoCard();
                    iguessvro.carteValeur = cartesValeurs[i];
                    iguessvro.carteCouleur = cartesCouleurs[j];
                    deck.Add(iguessvro);
                }
            }

            //affichage deck
            for (int i = 0; i < deck.Count; i++)
            {
                if (deck[i].carteValeur.Length == 2)
                {
                    carte = " +----+ \n |    | \n | " + deck[i].carteValeur + deck[i].carteCouleur + "| \n |    | \n +----+";
                }
                else
                {
                    carte = " +----+ \n |    | \n | " + deck[i].carteValeur + deck[i].carteCouleur + " | \n |    | \n +----+";
                }

            }

        }
        static void ShuffleDeck(ref List<InfoCard> deck)
        {
            Random alea = new Random();

            for (int i = 0; i < deck.Count(); i++)
            {
                int j = alea.Next(deck.Count);

                InfoCard temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }
        static void PiocherCarte(ref List<InfoCard> deck, InfoCard iguessvro, string visuelCarte, int points, int pointsTotal, out InfoCard card)
        {
            card = default;
            bool vide = false;

            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.NoName, false, false, false);

            do
            {
                if (deck.Count > 0)
                {
                    Random alea = new Random();
                    int placeCarte = alea.Next(deck.Count - 1);
                    card = deck[placeCarte];
                    deck.RemoveAt(placeCarte);

                    CompterPointsTest(ref deck, card, iguessvro, pointsTotal, out points);
                    AfficherCarte(ref deck, iguessvro, card,  out visuelCarte);

                    Console.WriteLine(visuelCarte);
                    Console.WriteLine(points);

                    Console.WriteLine("Press h to hit again");
                    key = Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("The deck is empty");
                    vide = true;
                }

            } while (!vide && key.KeyChar == 'h');
        }
        /*static void CompterPoints(in string carteValeur, string carte, out int points)
        {
            string infoUser;
            points = 0;

            if (carteValeur == "2" || carteValeur == "3" || carteValeur == "4" || carteValeur == "5" || carteValeur == "6" || carteValeur == "7" || carteValeur == "8" || carteValeur == "9" || carteValeur == "10")
            {
                int.TryParse(carteValeur, out points);
            }
            else if (carteValeur == "J" || carteValeur == "Q" || carteValeur == "K")
            {
                points = 10;
            }
            else if (carteValeur == "A")
            {
                Console.WriteLine("card = 1 ou 11 ? \n type 1 for 1, anything else for 11");
                infoUser = Console.ReadLine();

                if (infoUser == "1")
                {
                    points = 1;
                }
                else
                {
                    points = 11;
                }
            }
        }*/
        static void CompterPointsTest(ref List<InfoCard> deck, InfoCard card, InfoCard iguessvro, in int pointsTotal, out int points)
        {
            points = 0;

            if (iguessvro.carteValeur == "J" || iguessvro.carteValeur == "Q" || iguessvro.carteValeur == "K")
            {
                points = 10;
            }
            else if (iguessvro.carteValeur == "A")
            {
                if (pointsTotal <= 10)
                {
                    points = 11;
                }
                else
                {
                    points = 1;
                }
            }
            else
            {
                int.TryParse(iguessvro.carteValeur, out points);
            }
        }
        static void AfficherCarte(ref List<InfoCard> deck, InfoCard card, InfoCard iguessvro, out string visuelCarte)
        {
            visuelCarte = "";
            card = default;


            //affichage carte

            if (iguessvro.carteValeur == "10")
            {
                visuelCarte = " +----+ \n |    | \n | " + iguessvro.carteValeur + iguessvro.carteCouleur + "| \n |    | \n +----+";
            }
            else
            {
                visuelCarte = " +----+ \n |    | \n | " + iguessvro.carteValeur + iguessvro.carteCouleur + " | \n |    | \n +----+";
            }
        }
    }
}