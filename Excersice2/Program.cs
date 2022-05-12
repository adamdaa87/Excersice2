// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, this is the main menu:");
Console.WriteLine();

bool endlessLoop = true;

do {
    Console.WriteLine("----------------------Main Menu----------------------------");
    Console.WriteLine("Type a number to choose one of the alternatives");
    Console.WriteLine("or type '0' to exit the program");
    Console.WriteLine();
    Console.WriteLine("Menyval [1]: Ungdom eller pensionär");
    Console.WriteLine("Menyval [2]: Upprepa tio gånger");
    Console.WriteLine("Menyval [3]: Det tredje ordet");
    Console.WriteLine("Menyval [0]: Exit the program");
    Console.WriteLine();
    string input = Console.ReadLine();
    
    switch (input)
    {
        case "0":
            Console.WriteLine("You chose \"0\", Bye! See you next time!");
            endlessLoop = false;    
            break;
        case "1":
            Console.WriteLine("You chose \"1\", Ungdom eller pensionär!");
            Console.WriteLine();
            YouthOrPensioner();
            break;
        case "2":
            Console.WriteLine("You chose \"2\", Upprepa tio gånger!");
            Console.WriteLine();
            RepeatTenTimes();
            break;
        case "3":
            Console.WriteLine("You chose \"3\", Det tredje ordet!");
            Console.WriteLine();
            TheThirdWord();
            break;
        default:
            Console.WriteLine("The input value is not valid!");
            Console.WriteLine();
            break;
    }
    
}while (endlessLoop);

//-----------------------------------------------
void YouthOrPensioner()
{
    int num = 0;
    uint age = 0;
    double cost = 0;
    bool check = false;
    Console.Write("You need to type the number of people who" +
        " are willing to attend the cinema: ");
    string input = Console.ReadLine();
    if(int.TryParse(input, out num))
    {
        for(int i = 1; i <= num; i++)
        {
            do {
                Console.Write($"You need to enter the age of the person[{i}]: ");
                input = Console.ReadLine();
                check = uint.TryParse(input, out age);
                if (check && age != 0 && age <= 120)
                {
                    cost += CalculateTheFee(cost, age);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please, Enter an age between 1 and 120!");
                    Console.WriteLine();
                }
            } while (!check || age == 0 || age > 120);
        }
    }
    else
    {
        Console.WriteLine("The input value is not valid! Please type a number next time");
        return;
    }
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine($"The number of people who will atted the cinema are: {num} people");
    Console.WriteLine($"The total cost is: {cost} kr");
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine();
}
//-----------------------------------------------
double CalculateTheFee(double cost, uint age)
{
    Console.WriteLine();
    if (age >= 5 && age < 20)
    {
        Console.WriteLine("Ungdomspris: 80kr");
        Console.WriteLine();
        return cost = 80;
    }
    else if(20 <= age && age <= 64)
    {
        Console.WriteLine("Standardpris: 120kr");
        Console.WriteLine();
        return cost = 120;
    }
    else if(age > 64 && age <= 100)
    {
        Console.WriteLine("Pensionärspris: 90kr");
        Console.WriteLine();
        return cost = 90;
    }
    else
    {
        Console.WriteLine("Barn under fem och pensionärer över 100 går gratis!");
        Console.WriteLine();
        return cost = 0;
    }
    
}

//-----------------------------------------------
void RepeatTenTimes()
{
    Console.WriteLine("Please, write somthing and I will repeat it for you 10 times:");
    string str = Console.ReadLine();
    for(int i = 0; i < 10; i++)
    {
        if(i < 9)
        {
            Console.Write($"{i+1}. {str}, ");
        }
        else
        {
            Console.Write($"{i+1}. {str}.");
            Console.WriteLine();
        }
        
    }
}

//-----------------------------------------------
void TheThirdWord()
{
    bool check = false;
    String[] strlist;
    Console.WriteLine("Please, write a scentnce has at least three words" +
        " and I will pick up every third word and print it/them out for you:");
    Console.WriteLine();
    do {
        string str = Console.ReadLine();
        strlist = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if(strlist.Length < 3)
        {
            Console.WriteLine("Please enter a sentence that has at list 3 words!");
            Console.WriteLine();
            check = true;
        }
        else
        {
            check = false;
        }
         
    } while (check);
    
    Console.WriteLine();
    for (int i = 2; i <= strlist.Length; i+=3)
    {
        Console.WriteLine($"String[{i+1}] =  {strlist[i]}");
    }

}
