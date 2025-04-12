using System.Linq;
using System.Collections.Generic;

public class Program{
    public const int minRangeNumber = 1;
    public const int maxRangeNumber = 49;
    public const int totalLotteryNumber = 6;

    public static void Main(){

        Console.WriteLine("The Lottery Numbers as below:");

        //Generate the unique number list
        List<int> lotteryNumbersList = new List<int>();
        lotteryNumbersList = GenerateUniqueNumber(totalLotteryNumber, minRangeNumber, maxRangeNumber);

        //Sort the lottery numbers in the list
        lotteryNumbersList.Sort();

        //Start of Result
        Console.Write("{");
        for (int i = 0; i < lotteryNumbersList.Count; i++)
        {
            int number = lotteryNumbersList[i];
            
            //Generate the backgound colour with condition
            SetColourBackground(number);
            Console.Write($"{number}");

            //Rest Colour 
            Console.ResetColor();

            //Sperate the number result in the list
            if (i < lotteryNumbersList.Count - 1)
                Console.Write(", ");
        }

        //End of Result
        Console.WriteLine("}");

        //Rest Colours from Lottery Numbers List
        Console.ResetColor();

        //Generate Bonus Ball drawn
        Console.WriteLine("\n\nThe Bonus Ball is:");
        int bonusBall = GenerateBonusBall(lotteryNumbersList, minRangeNumber, maxRangeNumber);
        SetColourBackground(bonusBall);
        Console.WriteLine($"{bonusBall}");

        //Rest Colours from Bonus Ball
        Console.ResetColor();

        //Exit the Console Application
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public static List<int> GenerateUniqueNumber (int count, int min, int max){
        List<int> resultList = new List<int>();
        Random randNumber = new Random();
        for(int i=0; i < count; i++){
            int selectedNumber = randNumber.Next(min, max);
            //Check if the selected number is already existed in the list
            if(!resultList.Contains(selectedNumber)){
                resultList.Add(selectedNumber);
            }
        }

        return resultList;
    }

    public static void SetColourBackground (int number){
        //Set number colour background with condition
        if(number >= minRangeNumber && number <= 9)
            Console.BackgroundColor = ConsoleColor.Gray;
        else if (number >= 10 && number <= 19)
            Console.BackgroundColor = ConsoleColor.Blue;
        else if (number >= 20 && number <= 29)
            Console.BackgroundColor = ConsoleColor.Magenta;
        else if (number >= 30 && number <= 39)
            Console.BackgroundColor = ConsoleColor.Green;
        else if (number >= 40 && number <= maxRangeNumber)
            Console.BackgroundColor = ConsoleColor.Yellow;
    }

    public static int GenerateBonusBall (List<int> lotteryNumberList, int min, int max){
        int result;
        Random randNumber = new Random();

        //Check the unique bonus ball
        do
        {
            result = randNumber.Next(min, max);
        }
        while (lotteryNumberList.Contains(result));

        return result;

    }
}
