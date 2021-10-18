using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektB_Inlämningsuppgift
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        public void Add(PlayingCard card)
        { }

        public PlayingCard Highest 
        {
            get
            {
                return null;
            }
        }

        public PlayingCard Lowest 
        {
            get
            {
                return null;
            }

        }
    }
}
