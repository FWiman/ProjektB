using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektB_Inlämningsuppgift
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        List<PlayingCard> hand = new List<PlayingCard>();
        public void Add(PlayingCard card)
        {
            hand.Add(card);  
        }           //Finished. A method that adds a card and sorts the hand.

        public override void Clear()
        {
            hand.Clear();
        }               //Finished. Method that clears handofdeck


        public PlayingCard Highest
        {
            get
            {
                hand.Sort();
                PlayingCard highestcard = hand[hand.Count - 1];
                return highestcard;
            }
        }                   //Finished. A property wich gets the highest card in the deck.

        public PlayingCard Lowest
        {
            get
            {
                hand.Sort();
                PlayingCard lowestcard = hand[0];
                return lowestcard;
            }

        }                   //Finished. A property wich gets the lowest card in the deck.

        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < hand.Count; i++)
            {
                sRet += $"{hand[i]}";
            }
            return sRet;
        }           //Finished. A string to print when printing hand
    }
}
