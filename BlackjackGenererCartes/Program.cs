namespace BlackjackGenererCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cartesValeurs = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] cartesCouleurs = { "♠", "♥", "♦", "♣" };
            string carte;
            string infoUser;

            Console.WriteLine("hi");

            do
            {
                for (int iCouleurs = 0; iCouleurs < cartesCouleurs.Length; iCouleurs++)
                {
                    for (int iValeurs = 0; iValeurs < cartesValeurs.Length; iValeurs++)
                    {
                        if (iValeurs == 8)
                        //iValeurs est égal a 8 car le numéro 10 se trouve en huitième position et requiert un changement par rapport aux autres cartes
                        {
                            carte = " +--------------+ \n |              | \n |              | \n |              | \n |              | \n |              | \n |     " + cartesValeurs[iValeurs] + cartesCouleurs[iCouleurs] + "      | \n |              | \n |              | \n |              | \n |              | \n |              | \n +--------------+ \n";
                        }
                        else
                        {
                            carte = " +--------------+ \n |              | \n |              | \n |              | \n |              | \n |              | \n |      " + cartesValeurs[iValeurs] + cartesCouleurs[iCouleurs] + "      | \n |              | \n |              | \n |              | \n |              | \n |              | \n +--------------+ \n";
                        }Console.WriteLine(carte);                    
                    }                   
                }
                infoUser = Console.ReadLine();

            } while (infoUser == "y");

        }

    }
}