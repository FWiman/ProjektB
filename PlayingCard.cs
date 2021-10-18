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

	}
	public enum PlayingCardValue
	{
		Two = 2, Three, Four,
		Five, Six, Seven, Eight,
		Nine, Ten, Knight,
		Queen, King, Ace
	}
	public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
	{
		Random rnd = new Random();
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		public PlayingCard()
		{
			Color = (PlayingCardColor)rnd.Next(0, 4);
			Value = (PlayingCardValue)rnd.Next(2, 15);
		}
		public PlayingCard(PlayingCardColor color, PlayingCardValue value)
		{
			Color = color;
			Value = value;
		}


		#region IComparable Implementation
		//Need only to compare value in the project
		public int CompareTo(PlayingCard card1)
		{
			return 0;
		}
		#endregion

		#region ToString() related
		string ShortDescription
		{
			//Use switch statment or switch expression
			//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
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
				return $"{c} {Value.ToString()}";
			}
		}

		public override string ToString() => ShortDescription;
		#endregion
	}
}


