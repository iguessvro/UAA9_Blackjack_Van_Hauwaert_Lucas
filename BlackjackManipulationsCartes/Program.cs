using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlackjackManipulationsCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] cartesValeurs = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
            string[] cartesCouleurs = { "♠", "♥", "♦", "♣" };
            string visuelCartesJoueurL1 = "";
            string visuelCartesJoueurL2 = "";
            string visuelCartesJoueurL3 = "";
            string visuelCartesJoueurL4 = "";
            string visuelCartesJoueurL5 = "";
            string visuelCartesCroupierL1 = "";
            string visuelCartesCroupierL2 = "";
            string visuelCartesCroupierL3 = "";
            string visuelCartesCroupierL4 = "";
            string visuelCartesCroupierL5 = "";
            string visuelCarteL1 = "";
            string visuelCarteL2 = "";
            string visuelCarteL3 = "";
            string visuelCarteL4 = "";
            string visuelCarteL5 = "";
            string visuelCarteCacheeL1 = "  +----+ ";
            string visuelCarteCacheeL2 = "  |    | ";
            string visuelCarteCacheeL3 = "  | ?? | ";
            string visuelCarteCacheeL4 = "  |    | ";
            string visuelCarteCacheeL5 = "  +----+ ";
            string carte = "";
            int pointsTotal = 0;
            int pointsTotalC = 0;
            int pointsTotalJ = 0;
            int points = 0;
            int points1 = 0;
            int points2 = 0;
            int joueurPosX = 0;
            int joueurPosY = 15;
            int croupierPosX = 0;
            int croupierPosY = 3;
            int cardHeight = 10;
            int clearWidth = 100;
            bool bust;
            bool ace = false;
            bool aceChange = false;
            bool blackjack;
            List<InfoCard> deck = new List<InfoCard>();
            InfoCard card;
            InfoCard card1;
            InfoCard card2;
            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.NoName, false, false, false);
            ConsoleKeyInfo key2 = new ConsoleKeyInfo('\0', ConsoleKey.NoName, false, false, false);

            do
            {
                pointsTotal = 0;
                points = 0;
                bust = false;
                Console.Clear();

                Console.WriteLine("BLACKJACK");

                CreerDeck(cartesValeurs, cartesCouleurs, carte, ref deck);
                ShuffleDeck(ref deck);


                PiocherPremiereMainCroupier(ref deck, out card, out points1, out pointsTotal, out ace, ref aceChange, out visuelCartesCroupierL1, out visuelCartesCroupierL2, out visuelCartesCroupierL3, out visuelCartesCroupierL4, out visuelCartesCroupierL5);
                Console.WriteLine(visuelCartesCroupierL1 + visuelCarteCacheeL1);
                Console.WriteLine(visuelCartesCroupierL2 + visuelCarteCacheeL2);
                Console.WriteLine(visuelCartesCroupierL3 + visuelCarteCacheeL3);
                Console.WriteLine(visuelCartesCroupierL4 + visuelCarteCacheeL4); 
                Console.WriteLine(visuelCartesCroupierL5 + visuelCarteCacheeL5);

                pointsTotalC = pointsTotal + points;

                Console.WriteLine(" points totaux = " + pointsTotal + "\n");

                Console.WriteLine("\n \n \n");

                PiocherPremiereMainJoueur(ref deck, out card1, out card2, out points1, out points2, out pointsTotal, out ace, ref aceChange, out visuelCartesJoueurL1, out visuelCartesJoueurL2, out visuelCartesJoueurL3, out visuelCartesJoueurL4, out visuelCartesJoueurL5);
                Console.WriteLine(visuelCartesJoueurL1);
                Console.WriteLine(visuelCartesJoueurL2);
                Console.WriteLine(visuelCartesJoueurL3);
                Console.WriteLine(visuelCartesJoueurL4);
                Console.WriteLine(visuelCartesJoueurL5);

                pointsTotalJ = pointsTotal + points;

                if (pointsTotalJ == 21)
                {
                    blackjack = true;
                }

                Console.WriteLine(" points totaux = " + pointsTotalJ + "\n");

                do
                {

                    Console.WriteLine("\nPress on a key (h to hit, s to stand)");
                    key = Console.ReadKey(true);

                    if (key.KeyChar == 'h')
                    {
                        PiocherCarte(ref deck, pointsTotal, bust, out card, out points, ref ace, ref aceChange, out visuelCarteL1, out visuelCarteL2, out visuelCarteL3, out visuelCarteL4, out visuelCarteL5);

                        pointsTotalJ = pointsTotalJ + points;

                        visuelCartesJoueurL1 = visuelCartesJoueurL1 + visuelCarteL1;
                        visuelCartesJoueurL2 = visuelCartesJoueurL2 + visuelCarteL2;
                        visuelCartesJoueurL3 = visuelCartesJoueurL3 + visuelCarteL3;
                        visuelCartesJoueurL4 = visuelCartesJoueurL4 + visuelCarteL4;
                        visuelCartesJoueurL5 = visuelCartesJoueurL5 + visuelCarteL5;

                        for (int iErase = 0; iErase < cardHeight; iErase++)
                        {
                            Console.SetCursorPosition(joueurPosX, joueurPosY);
                            Console.Write(new string(' ', clearWidth));
                        }

                        for (int iCard = 0; iCard < cardHeight; iCard++)
                        {
                            Console.SetCursorPosition(joueurPosX, joueurPosY);
                            Console.WriteLine(visuelCartesJoueurL1);
                            Console.WriteLine(visuelCartesJoueurL2);
                            Console.WriteLine(visuelCartesJoueurL3);
                            Console.WriteLine(visuelCartesJoueurL4);
                            Console.WriteLine(visuelCartesJoueurL5);
                        }

                        if (ace == true && pointsTotalJ > 21 && aceChange == false)
                        {
                            pointsTotalJ = pointsTotalJ - 10;
                            aceChange = true;
                        }

                        if (pointsTotalJ > 21)
                        {
                            bust = true;
                        }

                        Console.WriteLine("points de la carte = " + points + "\npoints totaux = " + pointsTotalJ + "\n");

                        if (bust)
                        {
                            for (int iErase = 0; iErase < 5; iErase++)
                            {
                                Console.SetCursorPosition(0, 20 + iErase);
                                Console.Write(new string(' ', clearWidth));
                            }

                            for (int iText = 0; iText < 5; iText++)
                            {
                                Console.SetCursorPosition(0, 20);
                                Console.WriteLine("\nyou bust\n");
                            }
                        }
                    }
                    else if (key.KeyChar == 's')
                    {
                        Console.WriteLine("\nyou stood");
                    }
                    else
                    {
                        Console.WriteLine("\ninput error");
                    }

                } while (key.KeyChar != 's' && !bust);

                PiocherCarte(ref deck, pointsTotal, bust, out card, out points, ref ace, ref aceChange, out visuelCarteL1, out visuelCarteL2, out visuelCarteL3, out visuelCarteL4, out visuelCarteL5);

                pointsTotalC = pointsTotalC + points;

                visuelCartesCroupierL1 = visuelCartesCroupierL1 + visuelCarteL1;
                visuelCartesCroupierL2 = visuelCartesCroupierL2 + visuelCarteL2;
                visuelCartesCroupierL3 = visuelCartesCroupierL3 + visuelCarteL3;
                visuelCartesCroupierL4 = visuelCartesCroupierL4 + visuelCarteL4;
                visuelCartesCroupierL5 = visuelCartesCroupierL5 + visuelCarteL5;

                for (int iErase = 0; iErase < 5; iErase++)
                {
                    Console.SetCursorPosition(croupierPosX, croupierPosY);
                    Console.Write(new string(' ', clearWidth));
                }

                for (int iCard = 0; iCard < 5; iCard++)
                {
                    Console.SetCursorPosition(croupierPosX, croupierPosY);
                    Console.WriteLine(visuelCartesCroupierL1);
                    Console.WriteLine(visuelCartesCroupierL2);
                    Console.WriteLine(visuelCartesCroupierL3);
                    Console.WriteLine(visuelCartesCroupierL4);
                    Console.WriteLine(visuelCartesCroupierL5);
                } 

                /*
                Console.SetCursorPosition(8, 3);
                Console.WriteLine(visuelCarteL1);

                Console.SetCursorPosition(8, 4);
                Console.WriteLine(visuelCarteL2);

                Console.SetCursorPosition(8, 5);
                Console.WriteLine(visuelCarteL3);

                Console.SetCursorPosition(8, 6);
                Console.WriteLine(visuelCarteL4);

                Console.SetCursorPosition(8, 7);
                Console.WriteLine(visuelCarteL5);*/

                Console.SetCursorPosition(0, 8);
                Console.Write(new string(' ', clearWidth));
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("points totaux = " + pointsTotalC + "\n");

                if (pointsTotalC < 17)
                {
                    //Console.SetCursorPosition(16, 3);
                    PiocherCarte(ref deck, pointsTotal, bust, out card, out points, ref ace, ref aceChange, out visuelCarteL1, out visuelCarteL2, out visuelCarteL3, out visuelCarteL4, out visuelCarteL5);
                    pointsTotalC = pointsTotalC + points;
                }

                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                //Console.SetCursorPosition(0, Console.CursorTop + 1);

                Console.WriteLine("Do you want to play again ?");
                key2 = Console.ReadKey(true);

            } while (key2.KeyChar == 'y');
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
        static void PiocherPremiereMainCroupier(ref List<InfoCard> deck, out InfoCard card, out int points, out int pointsTotal, out bool ace, ref bool aceChange, out string visuelCartesCroupierL1, out string visuelCartesCroupierL2, out string visuelCartesCroupierL3, out string visuelCartesCroupierL4, out string visuelCartesCroupierL5)
        {
            pointsTotal = 0;
            ace = false;

            Random alea = new Random();
            int placeCarte = alea.Next(deck.Count - 1);
            card = deck[placeCarte];
            deck.RemoveAt(placeCarte);

            if (card.carteValeur == "A")
            {
                ace = true;
            }

            CompterPoints(card, pointsTotal, out points, ref aceChange);

            pointsTotal = pointsTotal + points;

            Console.WriteLine("\n Main du croupier");

            AfficherCartesCroupier(card, out visuelCartesCroupierL1, out visuelCartesCroupierL2, out visuelCartesCroupierL3, out visuelCartesCroupierL4, out visuelCartesCroupierL5);
        }
        static void PiocherPremiereMainJoueur(ref List<InfoCard> deck, out InfoCard card1, out InfoCard card2, out int points1, out int points2, out int pointsTotal, out bool ace, ref bool aceChange, out string visuelCartesJoueurL1, out string visuelCartesJoueurL2, out string visuelCartesJoueurL3, out string visuelCartesJoueurL4, out string visuelCartesJoueurL5)
        {
            pointsTotal = 0;
            ace = false;

            Random alea = new Random();
            int placeCarte = alea.Next(deck.Count - 1);
            card1 = deck[placeCarte];
            deck.RemoveAt(placeCarte);

            if (card1.carteValeur == "A")
            {
                ace = true;
            }

            CompterPoints(card1, pointsTotal, out points1, ref aceChange);

            pointsTotal = pointsTotal + points1;

            alea = new Random();
            placeCarte = alea.Next(deck.Count - 1);
            card2 = deck[placeCarte];
            deck.RemoveAt(placeCarte);

            if (card2.carteValeur == "A")
            {
                ace = true;
            }

            CompterPoints(card2, pointsTotal, out points2, ref aceChange);

            pointsTotal = pointsTotal + points2;

            Console.WriteLine(" Votre main");

            AfficherCartesDebut(card1, card2, out visuelCartesJoueurL1, out visuelCartesJoueurL2, out visuelCartesJoueurL3, out visuelCartesJoueurL4, out visuelCartesJoueurL5);
        }
        static void PiocherCarte(ref List<InfoCard> deck, int pointsTotal, bool burn, out InfoCard card, out int points, ref bool ace, ref bool aceChange, out string visuelCarteL1, out string visuelCarteL2, out string visuelCarteL3, out string visuelCarteL4, out string visuelCarteL5)
        {
            card = default;
            points = 0;
            visuelCarteL1 = "";
            visuelCarteL2 = "";
            visuelCarteL3 = "";
            visuelCarteL4 = "";
            visuelCarteL5 = "";

            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.NoName, false, false, false);

            if (deck.Count > 0)
            {
                Random alea = new Random();
                int placeCarte = alea.Next(deck.Count - 1);
                card = deck[placeCarte];
                deck.RemoveAt(placeCarte);

                if (card.carteValeur == "A")
                {
                    ace = true;
                }

                CompterPoints(card, pointsTotal, out points, ref aceChange);

                AfficherCarte(card, out visuelCarteL1, out visuelCarteL2, out visuelCarteL3, out visuelCarteL4, out visuelCarteL5);

                if (pointsTotal > 21)
                {
                    burn = true;

                    Console.WriteLine("\nyou burned");
                }
            }
            else
            {
                Console.WriteLine("The deck is empty");
            }

        }
        static void CompterPoints(InfoCard card, int pointsTotal, out int points, ref bool aceChange)
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
                    aceChange = true;
                }
            }
            else
            {
                int.TryParse(card.carteValeur, out points);
            }
        }
        static void AfficherCartesDebut(InfoCard card1, InfoCard card2, out string visuelCartesJoueurL1, out string visuelCartesJoueurL2, out string visuelCartesJoueurL3, out string visuelCartesJoueurL4, out string visuelCartesJoueurL5)
        {

            if (card1.carteValeur == "10" && card2.carteValeur != "10")
            {
                visuelCartesJoueurL1 = " +----+   +----+ ";
                visuelCartesJoueurL2 = " |    |   |    | ";
                visuelCartesJoueurL3 = " | " + card1.carteValeur + card1.carteCouleur + "|   | " + card2.carteValeur + card2.carteCouleur + " | ";
                visuelCartesJoueurL4 = " |    |   |    | ";
                visuelCartesJoueurL5 = " +----+   +----+ ";
            }
            else if (card1.carteValeur != "10" && card2.carteValeur == "10")
            {
                visuelCartesJoueurL1 = " +----+   +----+ ";
                visuelCartesJoueurL2 = " |    |   |    | ";
                visuelCartesJoueurL3 = " | " + card1.carteValeur + card1.carteCouleur + " |   | " + card2.carteValeur + card2.carteCouleur + "| ";
                visuelCartesJoueurL4 = " |    |   |    | ";
                visuelCartesJoueurL5 = " +----+   +----+ ";
            }
            else if (card1.carteValeur == "10" && card2.carteValeur == "10")
            {
                visuelCartesJoueurL1 = " +----+   +----+ ";
                visuelCartesJoueurL2 = " |    |   |    | ";
                visuelCartesJoueurL3 = " | " + card1.carteValeur + card1.carteCouleur + "|   | " + card2.carteValeur + card2.carteCouleur + "| ";
                visuelCartesJoueurL4 = " |    |   |    | ";
                visuelCartesJoueurL5 = " +----+   +----+ ";
            }
            else
            {
                visuelCartesJoueurL1 = " +----+   +----+ ";
                visuelCartesJoueurL2 = " |    |   |    | ";
                visuelCartesJoueurL3 = " | " + card1.carteValeur + card1.carteCouleur + " |   | " + card2.carteValeur + card2.carteCouleur + " | ";
                visuelCartesJoueurL4 = " |    |   |    | ";
                visuelCartesJoueurL5 = " +----+   +----+ ";
            }
        }     
        static void AfficherCartesCroupier(InfoCard card, out string visuelCartesCroupierL1, out string visuelCartesCroupierL2, out string visuelCartesCroupierL3, out string visuelCartesCroupierL4, out string visuelCartesCroupierL5)
        {
            if (card.carteValeur == "10")
            {
                visuelCartesCroupierL1 = " +----+ ";
                visuelCartesCroupierL2 = " |    | ";
                visuelCartesCroupierL3 = " | " + card.carteValeur + card.carteCouleur + "| ";
                visuelCartesCroupierL4 = " |    | ";
                visuelCartesCroupierL5 = " +----+ ";
            }
            else
            {
                visuelCartesCroupierL1 = " +----+ ";
                visuelCartesCroupierL2 = " |    | ";
                visuelCartesCroupierL3 = " | " + card.carteValeur + card.carteCouleur + " | ";
                visuelCartesCroupierL4 = " |    | ";
                visuelCartesCroupierL5 = " +----+ ";
            }
        }
        static void AfficherCarte(InfoCard card, out string visuelCarteL1, out string visuelCarteL2, out string visuelCarteL3, out string visuelCarteL4, out string visuelCarteL5)
        {
            //affichage carte

            if (card.carteValeur == "10")
            {
                visuelCarteL1 = "  +----+ ";
                visuelCarteL2 = "  |    | ";
                visuelCarteL3 = "  | " + card.carteValeur + card.carteCouleur + "| ";
                visuelCarteL4 = "  |    | ";
                visuelCarteL5 = "  +----+ ";
            }
            else
            {
                visuelCarteL1 = "  +----+ ";
                visuelCarteL2 = "  |    | ";
                visuelCarteL3 = "  | " + card.carteValeur + card.carteCouleur + " | ";
                visuelCarteL4 = "  |    | ";
                visuelCarteL5 = "  +----+ ";
            }
        }
    }
}