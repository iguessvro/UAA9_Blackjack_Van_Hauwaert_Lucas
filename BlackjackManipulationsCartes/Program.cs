using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlackjackManipulationsCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cartesValeurs = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
            string[] cartesCouleurs = { "♠", "♥", "♦", "♣" };
            List<InfoCard> deck = new List<InfoCard>();
            string carte = "";
            int pointsTotal = 0;
            int points = 0;
            string infoUser;
            InfoCard card;
            string visuelCarte = "";
            bool burn = false;

            Console.WriteLine("hi");

            CreerDeck(cartesValeurs, cartesCouleurs, carte, ref deck);
            ShuffleDeck(ref deck);

            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.NoName, false, false, false);

            do
            {
                Console.WriteLine("\nPress on a key (h to hit, s to stand)");
                key = Console.ReadKey(true);

                if (key.KeyChar == 'h')
                {
                    PiocherCarte(ref deck, points, pointsTotal, burn, out card);
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
        static void CreerDeck(string[] cartesValeurs, string[] cartesCouleurs, string carte, ref List<InfoCard> deck)
        {
            deck.Clear();
            InfoCard iguessvro = default;

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
        static void PiocherCarte(ref List<InfoCard> deck, int points, int pointsTotal, bool burn, out InfoCard card)
        {
            card = default;
            bool vide = false;
            string visuelCarte;

            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.NoName, false, false, false);

            do
            {
                if (deck.Count > 0)
                {
                    Random alea = new Random();
                    int placeCarte = alea.Next(deck.Count - 1);
                    card = deck[placeCarte];
                    deck.RemoveAt(placeCarte);

                    CompterPoints(card, pointsTotal, out points);

                    pointsTotal = pointsTotal + points;

                    AfficherCarte(card, out visuelCarte);

                    Console.WriteLine(visuelCarte);
                    Console.WriteLine("points de la carte = " + points + "\npoints totaux = " + pointsTotal + "\n");

                    if (pointsTotal > 21)
                    {
                        burn = true;

                        Console.WriteLine("\nyou burned");
                    }

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
        static void CompterPoints(InfoCard card, int pointsTotal, out int points)
        {
            points = 0;

            if (card.carteValeur == "J" || card.carteValeur == "Q" || card.carteValeur == "K")
            {
                points = 10;
            }
            else if (card.carteValeur == "A")
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
                int.TryParse(card.carteValeur, out points);
            }
        }
        static void AfficherCarte(InfoCard card, out string visuelCarte)
        {
            visuelCarte = "";

            //affichage carte

            if (card.carteValeur == "10")
            {
                visuelCarte = " +----+ \n |    | \n | " + card.carteValeur + card.carteCouleur + "| \n |    | \n +----+";
            }
            else
            {
                visuelCarte = " +----+ \n |    | \n | " + card.carteValeur + card.carteCouleur + " | \n |    | \n +----+";
            }
        }
    }
}