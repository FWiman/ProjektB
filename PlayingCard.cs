using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektB_Inlämningsuppgift
{

    public enum PlayingCardColor
    {
        Clubs = 0,
        Diamonds,
        Hearts,
        Spades

    }               //Finished. Creates an Enum wich contains the different colors of a PlayingCard.
    public enum PlayingCardValue
    {
        Two = 2, Three, Four,
        Five, Six, Seven, Eight,
        Nine, Ten, Knight,
        Queen, King, Ace
    }               //Finished. Creates an Enum wich contains the different values of a PlayingCard.
    public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
    {
        public PlayingCardColor Color { get; init; }            //Finished. A property wich holds the color.
        public PlayingCardValue Value { get; init; }            //Finished. A property wich holds the value.

        public bool Equals(PlayingCard card) => (this.Color, this.Value) == (card.Color, card.Value);        // Implementation of IEquatable<T> interface
        public override int GetHashCode() => (Color, Value).GetHashCode();                                  //Needed to implement as part of IEquatable
        public override bool Equals(object obj) => Equals(obj as PlayingCard);                              //Needed to implement as part of IEquatable
        public static bool operator == (PlayingCard card1, PlayingCard card2) => card1.Equals(card2);       //Overloading
        public static bool operator != (PlayingCard card1, PlayingCard card2) => !card1.Equals(card2);      //Overloading

        public PlayingCard()                          //Finished. A Constructor with no parameters wich creates a card with random color and value.
        {
            Random rnd = new Random();
            Color = (PlayingCardColor)rnd.Next(0, 4);
            Value = (PlayingCardValue)rnd.Next(2, 15);
        }
        public PlayingCard(PlayingCardColor color, PlayingCardValue value)  //Finished. A Constructor with 2 parameters that creates a card with specific color/value
        {
            Color = color;
            Value = value;
        }


        #region IComparable Implementation  //Finished
        public int CompareTo(PlayingCard card1)
        {
            return this.Value.CompareTo(card1.Value);
        }              //Finished. Compares values between 2 objects.
        #endregion

        #region ToString() related      //Finished.
        string ShortDescription
        {
            get
            {
                char c = Color switch
                {
                    PlayingCardColor.Clubs => '\u2663',
                    PlayingCardColor.Spades => '\u2660',
                    PlayingCardColor.Hearts => '\u2665',
                    PlayingCardColor.Diamonds => '\u2666',
                    _ => throw new NotImplementedException()
                };
                return $"|{c}{Value.ToString()}";
            }
        }                                       //Finished. A property wich contains a switch expression with the unicode for each color

        public override string ToString() => ShortDescription;                  //Finished. A method wich prints the short description.
        #endregion
    }                  
}


