using System;
using System.Collections.Generic;

class MainClass {

  public static void Main (string[] args) {

		// Title screen/ hit enter to play
		TitleScreen();

		// hit button to deal the cards

		string[] face = { "Clubs", "Spades", "Dimonds", "Hearts" };
		string[] value = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

		List<string> deck = new List<string>();

		for (var i = 0; i < value.Length; i++)
		{
			for (var j = 0; j < face.Length; j++)
			{
				string card = value[i] + " " + face[j];

				deck.Add(card);
			}
		}

		Game(deck);

		Console.WriteLine("Sorry you busted");


		// deal two cards to the player

		//deal two cards to the computer

		// ask player to hit or stay

		// if hit deal another card
			// else if comp cards >16 draw another card

		// compare player and compute cards and tell who is the winner


    Console.ReadLine();
  }

	private static void TitleScreen()
	{
		Console.WriteLine();
		Console.WriteLine("CONSOLE 21");
		Console.WriteLine();
		Console.WriteLine("Hit any key to play...");
		Console.ReadLine();
		Console.Clear();
	}

	private static void Game(List<string> deck)
	{
		bool overTwentyOne = false;
		do
		{
			Console.Write("Hit enter to deal: ");
			Console.ReadLine();
			Console.WriteLine();

			Console.WriteLine("---DEALERS HAND--- ");
			int dealerCardTotal = DealCards(deck, 2);
			Console.WriteLine($"Total: { dealerCardTotal }");

			Console.WriteLine("---PLAYERS HAND---");
			int myCardTotal = DealCards(deck, 2);
			Console.WriteLine($"Total: { myCardTotal }");

			myCardTotal = PlayerOptions(deck, myCardTotal);

			Console.WriteLine($"Total: { myCardTotal }");

			if (myCardTotal > 21)
			{
				overTwentyOne = true;
			}
		} while (overTwentyOne == false);


	}

	private static int DealCards(List<string> deck, int howManyCards)
	{
		int total = 0; 

		for (var i = 0; i < howManyCards; i++)
		{
			Random rnd = new Random();
			int index = rnd.Next(deck.Count);

			total += ChangeToInt(deck[index]);
			
			Console.WriteLine(deck[index]);
		}
		return total;
	}

	private static int ChangeToInt(string value)
	{
		int number;
		string firstChar = value.Substring(0, 1);

		if (firstChar == "A")
		{
			number = 1;
			return number;
		}
		else if (firstChar == "J")
		{
			number = 10;
			return number;
		}
		else if (firstChar == "Q")
		{
			number = 10;
			return number;
		}
		else if (firstChar == "K")
		{
			number = 10;
			return number;
		}
		else{
			number = Convert.ToInt32(firstChar);
			return number;
		}
	}

	private static int PlayerOptions(List<string> deck, int currentTotal)
	{
		int output;

		do
		{
			
			Console.WriteLine();
			Console.WriteLine("1 for Hit");
			Console.WriteLine("2 for Stay");
			Console.WriteLine();
			Console.Write("What would you like to do: ");
			output = Convert.ToInt32(Console.ReadLine());

			if (output == 1)
			{
				currentTotal += DealCards(deck, 1);
				Console.WriteLine($"Total: { currentTotal }");

			}
		} while (output == 1);

		return currentTotal;
	}
}