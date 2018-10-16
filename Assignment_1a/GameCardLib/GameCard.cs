using System;
using System.Collections.Generic;
using System.Text;

namespace GameCardLib
{
	public enum Suit { Diamond, Spade, Star, Heart }
	public class GameCard
	{
		public string ImgPath { get; set; }
		public int Value { get; set; }
		public Suit Suit { get; set; }

		public GameCard(int value, Suit suit, string imgPath)
		{
			Value = value;
			Suit = suit;
			ImgPath = ImgPath;
		}
	}
}
