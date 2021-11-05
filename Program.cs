using System;

namespace ProjektB_Inlämningsuppgift
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creates a new deck of cards that contains 52 cards with 14 different cards in each color
            DeckOfCards myDeck = new DeckOfCards();

            // Prints a newly created deck of cards
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            //Prints the sorted deck of cards based on value
            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine($"{myDeck}");

            //Prints a deck that has been shuffled 500 times
            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();


            // The cardgame starts here

            Console.WriteLine($"\nLet's get some cards and play a game of Highcard between two players! :D");


            //Asks player how many cards and how many rounds the game plays out
            int nrRounds = 0;
            bool PlayGame = TryReadNrOfCards(out int nrOfCards) &&
                            TryReadNrOfRounds(out nrRounds);

            // If the user chooses an incorrect nr of cards and rounds the game starts over untill it gets the correct "format"
            if (!PlayGame) return;


            // This is where the two players gets their hands and plays the nr of rounds with the nr of cards the user chooses
            int round = 0;
            Console.Clear();
            while (round < nrRounds)
            {
                Console.WriteLine($"------------------");
                Console.WriteLine($"\nPlaying round nr {round + 1}\n");

                Deal(myDeck, nrOfCards, player1, player2);

                Console.WriteLine($"Player one hand contains:\t{player1}\n");
                Console.WriteLine($"Player one highest card is:\t{player1.Highest}\nand lowest card is:\t\t{player1.Lowest}\n");
                Console.WriteLine($"Player two hand contains:\t{player2}\n");
                Console.WriteLine($"Player two highest card is:\t{player2.Highest}\nand lowest card is:\t\t{player2.Lowest}\n");

                DetermineWinner(player1, player2);
                player1.Clear();
                player2.Clear();
                round++;
            }
        }

        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            string sInput;
            do
            {
                Console.WriteLine("How many cards would u like to play with? (1-5)");
                sInput = Console.ReadLine();

                if (int.TryParse(sInput, out NrOfCards) && NrOfCards >= 1 && NrOfCards <= 5)
                {
                    return true;
                }
                else if (sInput != "Q" && sInput != "q")
                {
                    Console.WriteLine($"{sInput} Wrong input, Try again!");
                }
            }
            while (sInput != "Q" && sInput != "q");
            return false;
        }                                  // Finished

        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {
            NrOfRounds = 0;
            string sInput;
            do
            {
                Console.WriteLine("How many rounds should we play (1-5 or Q to quit)?");
                sInput = Console.ReadLine();
                if (int.TryParse(sInput, out NrOfRounds) && NrOfRounds >= 1 && NrOfRounds <= 5)
                {
                    return true;
                }
                else if (sInput != "Q" && sInput != "q")
                {
                    Console.WriteLine("Wrong input, please try again.");
                }
            }
            while ((sInput != "Q" && sInput != "q"));
            return false;

        }                                   // Finished

        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                player1.Add(myDeck.RemoveTopCard());
                player2.Add(myDeck.RemoveTopCard());
            }
        }   //Finished. Deals cards to 2 different hands and also removes the card at the top of the deck at the same time.

        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {
            string WinningCard = player1.Highest.CompareTo(player2.Highest)
                  switch
            {
                1 => $"\nPlayer1 wins with highest card\t\t{player1.Highest}!",
                0 => $"It's a tie! Both players have {player1.Highest} as their highest card",
                -1 => $"\nPlayer2 wins with highest card\t\t{player2.Highest}!",
                _ => throw new NotImplementedException()

            }; Console.WriteLine($"{WinningCard}");
        }
    }
}
