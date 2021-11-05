using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektB_Inlämningsuppgift
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related  //Finished
        protected const int MaxNrOfCards = 52;
        protected int nrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public DeckOfCards()
        {
            CreateFreshDeck();
        }                               // Finished. Uses the "CreateFreshDeck" wich creates a new deck of cards.
        public PlayingCard this[int idx] => cards[idx];                   // Finished. Creates a indexer for "PlayingCard".
        public int Count => nrOfCards;                       // Finished. A Counter

        #endregion

        #region ToString() related      //Finished
        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < cards.Count(); i++)
            {
                sRet += $"{cards[i],-8}";
                if ((i+1) % 13 == 0)
                {
                    sRet = sRet + "\n";
                }
            }
            return sRet;
        }                       // Finished. Creates a string to print.
        #endregion

        #region Shuffle and Sorting     //Finished
        public void Shuffle()
        {
            Random rnd = new Random();
            int nrOfShuffles = rnd.Next(100, 10000);
            for (int i = 0; i < nrOfShuffles; i++)
            {
                int card1 = rnd.Next(0, 52);
                int card2 = rnd.Next(0, 52);

                (cards[card1], cards[card2]) = (cards[card2], cards[card1]);
            }
        }                                   // Finished. A Method that shuffles the Deck of cards.
        public void Sort()
        {
            cards.Sort((x, y) => x.Value.CompareTo(y.Value));
        }                                      // Finished. A method that sorts the Deck of cards.
        #endregion                      

        #region Creating a fresh Deck   //Finished
        public virtual void Clear()
        {
            cards.Clear();
        }                       //Finished. Clears the Deck to empty.

        public void CreateFreshDeck()
        {
            int cardNr = 0;

            for (PlayingCardColor color = PlayingCardColor.Clubs; color <= PlayingCardColor.Spades; color++)
            {
                for (PlayingCardValue value = PlayingCardValue.Two; value <= PlayingCardValue.Ace; value++)
                {
                    cards.Add(new PlayingCard((PlayingCardColor)color, (PlayingCardValue)value));
                    cardNr++;
                }
            }

        }                            //Finished. Creates a new fresh deck of 52 cards wich contains both Value and Color.
        #endregion

        #region Dealing     //Finished
        public PlayingCard RemoveTopCard()
        {
            return cards[nrOfCards-- -1];
        }           // Finished. Removes the card at the top.
        #endregion
    }
}
