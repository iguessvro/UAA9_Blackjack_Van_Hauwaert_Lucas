using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlackjackManipulationsCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cartesValeurs = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
            string[] cartesCouleurs = { "♠", "♥", "♦", "♣" };
            string visuelCarte = "";
            string carte = "";
            string infoUser;
            int centerColumn = Console.WindowWidth / 2;
            int pointsTotal = 0;
            int points = 0;
            int points1 = 0;
            int points2 = 0;
            bool burn = false;
            List<InfoCard> deck = new List<InfoCard>();
            InfoCard croupierHand = default;
            InfoCard playerHand = default;
            InfoCard playerHand2 = default;
            InfoCard card;
            InfoCard card1;
            InfoCard card2;

            Console.WriteLine("BLACKJACK");

            CreerDeck(cartesValeurs, cartesCouleurs, carte, ref deck);
            ShuffleDeck(ref deck);

            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.NoName, false, false, false);

            PiocherPremiereMainCroupier(ref deck, out card, out points1, out pointsTotal);

            pointsTotal = pointsTotal + points;

            Console.WriteLine(" points totaux = " + pointsTotal + "\n");

            Console.WriteLine("\n \n \n");

            PiocherPremiereMainJoueur(ref deck, out card1, out card2, out points1, out points2, out pointsTotal);

            pointsTotal = pointsTotal + points;

            Console.WriteLine(" points totaux = " + pointsTotal + "\n");

            

            do
            {
                Console.WriteLine("\nPress on a key (h to hit, s to stand)");
                key = Console.ReadKey(true);

                if (key.KeyChar == 'h')
                {
                    PiocherCarte(ref deck, pointsTotal, burn, out card, out points);

                    pointsTotal = pointsTotal + points;

                    Console.WriteLine("points de la carte = " + points + "\npoints totaux = " + pointsTotal + "\n");

                    Console.WriteLine("Press h to hit again or s to stand");
                    key = Console.ReadKey(true);

                    do
                    {
                        PiocherCarte(ref deck, pointsTotal, burn, out card, out points);

                        pointsTotal = pointsTotal + points;

                        Console.WriteLine("points de la carte = " + points + "\npoints totaux = " + pointsTotal + "\n");

                        Console.WriteLine("Press h to hit again or s to stand");
                        key = Console.ReadKey(true);

                        if (pointsTotal > 21)
                        {
                            burn = true;

                            Console.WriteLine("you burned");
                        }

                    } while (key.KeyChar == 'h' && !burn);

                    Console.WriteLine("points de la carte = " + points + "\npoints totaux = " + pointsTotal + "\n");
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
        static void PiocherPremiereMainCroupier(ref List<InfoCard> deck, out InfoCard card, out int points, out int pointsTotal)
        {
            string visuelCartes;
            pointsTotal = 0;

            Random alea = new Random();
            int placeCarte = alea.Next(deck.Count - 1);
            card = deck[placeCarte];
            deck.RemoveAt(placeCarte);

            CompterPoints(card, pointsTotal, out points);

            pointsTotal = pointsTotal + points;

            Console.WriteLine("\n Main du croupier");

            AfficherCartesCroupier(card, out visuelCartes);

            Console.WriteLine(visuelCartes);
        }
        static void PiocherPremiereMainJoueur(ref List<InfoCard> deck, out InfoCard card1, out InfoCard card2, out int points1, out int points2, out int pointsTotal)
        {
            string visuelCartes;
            pointsTotal = 0;

            Random alea = new Random();
            int placeCarte = alea.Next(deck.Count - 1);
            card1 = deck[placeCarte];
            deck.RemoveAt(placeCarte);

            CompterPoints(card1, pointsTotal, out points1);

            alea = new Random();
            placeCarte = alea.Next(deck.Count - 1);
            card2 = deck[placeCarte];
            deck.RemoveAt(placeCarte);

            CompterPoints(card2, pointsTotal, out points2);

            pointsTotal = points1 + points2;

            Console.WriteLine(" Votre main");

            AfficherCartesDebut(card1, card2, out visuelCartes);

            Console.WriteLine(visuelCartes);
        }
        static void PiocherCarte(ref List<InfoCard> deck, int pointsTotal, bool burn, out InfoCard card, out int points)
        {
            card = default;
            bool vide = false;
            string visuelCarte;
            points = 0;

            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.NoName, false, false, false);

            /*do
            {*/
                if (deck.Count > 0)
                {
                    Random alea = new Random();
                    int placeCarte = alea.Next(deck.Count - 1);
                    card = deck[placeCarte];
                    deck.RemoveAt(placeCarte);

                    CompterPoints(card, pointsTotal, out points);

                    AfficherCarte(card, out visuelCarte);

                    Console.WriteLine(visuelCarte);
                    

                    if (pointsTotal > 21)
                    {
                        burn = true;

                        Console.WriteLine("\nyou burned");
                    }
                }
                else
                {
                    Console.WriteLine("The deck is empty");
                    vide = true;
                }

            /*} while (!vide && burn == false);*/
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
        static void AfficherCartesDebut(InfoCard card1, InfoCard card2, out string visuelCartes)
        {

            if (card1.carteValeur == "10" && card2.carteValeur != "10")
            {
                visuelCartes = " +----+   +----+ \n |    |   |    | \n | " + card1.carteValeur + card1.carteCouleur + "|   | " + card2.carteValeur + card2.carteCouleur + " | \n |    |   |    | \n +----+   +----+ ";
            }
            else if (card1.carteValeur != "10" && card2.carteValeur == "10")
            {
                visuelCartes = " +----+   +----+ \n |    |   |    | \n | " + card1.carteValeur + card1.carteCouleur + " |   | " + card2.carteValeur + card2.carteCouleur + "| \n |    |   |    | \n +----+   +----+ ";
            }
            else if (card1.carteValeur == "10" && card2.carteValeur == "10")
            {
                visuelCartes = " +----+   +----+ \n |    |   |    | \n | " + card1.carteValeur + card1.carteCouleur + "|   | " + card2.carteValeur + card2.carteCouleur + "| \n |    |   |    | \n +----+   +----+ ";
            }
            else
            {
                visuelCartes = " +----+   +----+ \n |    |   |    | \n | " + card1.carteValeur + card1.carteCouleur + " |   | " + card2.carteValeur + card2.carteCouleur + " | \n |    |   |    | \n +----+   +----+ ";
            }
        }     
        static void AfficherCartesCroupier(InfoCard card, out string visuelCartes)
        {
            if (card.carteValeur == "10")
            {
                visuelCartes = " +----+   +----+ \n |    |   |    | \n | " + card.carteValeur + card.carteCouleur + "|   | ?? | \n |    |   |    | \n +----+   +----+ ";
            }
            else
            {
                visuelCartes = " +----+   +----+ \n |    |   |    | \n | " + card.carteValeur + card.carteCouleur + " |   | ?? | \n |    |   |    | \n +----+   +----+ ";
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