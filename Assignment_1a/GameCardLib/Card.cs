using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib
{
	public enum Suit { Diamonds, Spades, Clubs, Hearts }
	public class Card
	{
		public string ImgPath { get; set; }
		public int Value { get; set; }
		public Suit Suit { get; set; }

		public bool Visible { get; set; }

		public Card(int value, Suit suit, string imgPath)
		{
			Value = value;
			Suit = suit;
			ImgPath = CreateImagePath(value, suit);
		}

		private string CreateImagePath(int value, Suit suit)
		{

			string folderLocation = "\\Resources\\Cards\\";
			string cardValue = CardStrings.GetStringValue(value);

			folderLocation += cardValue + suit.ToString() + ".png";

			return folderLocation;
		}
	}

	public static class CardStrings
	{
		private static Dictionary<int, string> IntToStringDic = new Dictionary<int, string> {
			{ 1, "Ace" },
			{ 2, "Two" },
			{ 3, "Three" },
			{ 4, "Four" },
			{ 5, "Five" },
			{ 6, "Six" },
			{ 7, "Seven" },
			{ 8, "Eight" },
			{ 9, "Nine" },
			{ 10, "Ten" },
			{ 11, "Jack" },
			{ 12, "Queen" },
			{ 13, "King" },
			{ 14, "Ace" },
		};

		public static string GetStringValue(int value)
		{
			return IntToStringDic[value];
		}
	}
}
