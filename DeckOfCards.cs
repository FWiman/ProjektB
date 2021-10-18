using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektB_Inlämningsuppgift
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public DeckOfCards()
        {
            CreateFreshDeck();
        }
        public PlayingCard this[int idx]
        {
            get
            {
                return cards[idx];
            }

        }
        public int Count
        {
            get
            {
                int count = 0;
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i] != null)
                    {
                        count++;
                    }
                }
                return count;
            }

        }
        #endregion

        #region ToString() related
        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < cards.Count(); i++)
            {
                if (cards[i] != null)
                {
                    sRet += cards[i].ToString() + "\n";
                }
            }
            return sRet;
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {
            var rnd = new Random();
            int card1;
            int card2;
            PlayingCard card;

            for (int i = 0; i < 500; i++)
            {
                card1 = rnd.Next(0, 52);
                card2 = rnd.Next(0, 52);
                card = cards[card1];
                cards[card1] = cards[card2];
                cards[card2] = card;
            }
        }
        public void Sort()
        {



        }
        #endregion

        #region Creating a fresh Deck
        public void Clear()
        {



        }
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

        }                                                   // BORDE VARA KLAR!?
        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard()                                  // SKITDÅLIG??
        {
            bool notTopCard = false;
            int noCards = 52;

            while (!notTopCard)
            {
                noCards--;
                if (cards[noCards] != null)
                {
                    notTopCard = true;
                }

            }
            PlayingCard card = cards[noCards];
            cards[noCards] = null;

            return card;
        }
        #endregion
    }
}
