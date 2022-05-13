// Det här programmet skrivs av Adam Daa

/// <summary>
/// Det här programmet består av tre sektioner
/// 1. Ungdom eller pensionär;
/// 2. Upprepa tio gånger;
/// 3. Det tredje ordet;
/// Den börjar med en huvudmeny som användaren ska välja ifrån 
/// baserat på användarens val kommer programmet att starta ett av de tre programmen.
/// </summary>

bool endlessLoop = true;  // Loop variabel
string input; // input sträng variabel

do {
    TheMainMenuTheme();  // Ändrar temat
    Console.WriteLine("----------------------Main Menu----------------------------");
    Console.WriteLine("Type a number to choose one of the alternatives");
    Console.WriteLine("or type '0' to exit the program");
    Console.WriteLine();
    Console.WriteLine("[1]: Ungdom eller pensionär"); // alternativ 1 
    Console.WriteLine("[2]: Upprepa tio gånger");     // alternativ 2 
    Console.WriteLine("[3]: Det tredje ordet");       // alternativ 3 
    Console.WriteLine("[0]: Exit the program");       // alternativ 0 för att stänga ner programmet
    Console.WriteLine();
    Console.Write("Your choice: ");
    input = Console.ReadLine();  // Läser användarens val
    Console.WriteLine();

    switch (input) // Kontrollerar inmatade värdet och reagerar enlight det
    {
        case "0":       // alternativ "0" 
            Console.WriteLine("You chose \'0\', Bye! See you next time!");
            endlessLoop = false;  // ställ in loopvariabeln till false så den stänger ner programmet
            break;
        case "1":       // alternativ "1" 
            YouthOrPensioner(); //Anropar metoden YouthOrPensioner 
            break;
        case "2":       // alternativ "2" 
            RepeatTenTimes(); //Anropar metoden RepeatTenTimes
            break;
        case "3":       // alternativ "3" 
            TheThirdWord(); //Anropar metoden RepeatTenTimes
            break;
        default:
            Console.WriteLine("The input value is not valid!");
            Console.WriteLine();
            break;
    }
    
}while (endlessLoop);  // Kontollerar loopen 


/// <summary>
/// Den här metoden räknar antal personer som ska gå på bio. 
/// räknar beljeters totalkostnad för hela sällskapet enlight sina ålder
/// </summary>
void YouthOrPensioner()
{
    int num = 0;  // för att spara antal personer
    uint age = 0;    // för att spara personers ålder
    double cost = 0;  // för att spara totalkostand
    bool check = false;
    YouthOrPensionerTheme();  // Byter temet och titeln
    Console.WriteLine("This program calculates the number of people who want to go to the cinema,");
    Console.WriteLine("and calculates the total cost of the tickets.");
    Console.WriteLine();
    Console.Write("You need to type the number of people who are willing to attend the cinema: ");
    string input = Console.ReadLine(); // Läser in antal personer
    if(int.TryParse(input, out num))  // Omvandlar inmatade värdet från sträng till int
    {
        for(int i = 1; i <= num; i++)  // Loopar alla pesroner för att räkna kostnaden enlight deras ålder  
        {
            do {
                Console.Write($"You need to enter the age of the person[{i}]: ");
                input = Console.ReadLine(); // läser in ålder
                check = uint.TryParse(input, out age);  // Omvandlar inmatade värdet från sträng till integer
                if (check && age != 0 && age <= 120)   // Kontrollerar ogiltiga värden. 
                {
                    cost += CalculateTheFee(cost, age); // Anropar metoden för att identifiera vilken grupp varje person tillhör
                }
                else // Om ålders värde stämmer inte
                {
                    Console.WriteLine();
                    Console.WriteLine("Please, Enter an age between 1 and 120 years");
                    Console.WriteLine();
                }
            } while (!check || age == 0 || age > 120);   // kontrollerar alla ålders krav. Om de inte stämmer loopar den
        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("The input value is not valid! Please type a number next time");
        Console.WriteLine();
        return;
    }
    Console.WriteLine("-----------------------------------------------");   // Skriver ut sammanfattningen
    Console.WriteLine($"The number of people who will attend the cinema are: {num} people");
    Console.WriteLine($"The total cost is: {cost} kr");
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine();
    Console.WriteLine("Press Enter to get back to the main menu");
    Console.ReadLine();
}

/// <summary>
/// Identifierar personens ålder-grupp och sen
/// retunerar biljetts kostnaden
/// </summary>
/// <param cost>Biljett kostnad</param>
/// <param age> Persons ålder</param>
/// <returns>
/// Om åldren mindre än 5 eller större än 100 så blir kostnaden 0 kr
/// Om åldren större än 5 och mindre 20 så blir kostnaden 80 kr 
/// Om åldren större eller lika med 20 och mindre eller lika med 64 så blir kostnaden 120 kr
/// Om åldren större än 64 och mindre eller lika med 100 så blir kostnaden 90 kr
/// </returns>
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

/// <summary>
/// Användaren anger en godtycklig text
/// Programmet sparar texten som en variabel
/// Programmet skriver, via en for-loop ut denna text tio gånger på rad
/// </summary>
void RepeatTenTimes()
{
    RepeatTenTimesTheme(); // Byter temet
    Console.WriteLine("Please, write something and I will repeat it for you 10 times:");
    string str = Console.ReadLine();  // Läser inmatade strängen
    Console.WriteLine();
    for (int i = 0; i < 10; i++)
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
    Console.WriteLine();
    Console.WriteLine("Press Enter to get back to the main menu");
    Console.ReadLine();
}

/// <summary>
/// Användaren anger en mening med minst 3 ord
/// Programmet delar upp strängen med split-metoden på varje mellanslag
/// Programmet plockar ut den tredje strängen (ordet) ur input
/// Programmet skriver ut den tredje strängen(ordet)
/// </summary>
void TheThirdWord()
{
    TheThirdWordTheme();
    bool check = false;
    String[] strlist;
    Console.WriteLine("Please, write a scentnce that has at least three words" +
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
    Console.WriteLine();
    Console.WriteLine("Press Enter to get back to the main menu");
    Console.ReadLine();

}

/// <summary>
/// Den här metoden förändra bakgrundsfärgen och förgrundsfärgen
/// och ändrar fönsters titeln till anpassade title.
/// </summary>
void TheMainMenuTheme()
{
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Title = "Main Menu";
}

/// <summary>
/// Den här metoden förändra bakgrundsfärgen och förgrundsfärgen
/// och ändrar fönsters titeln till anpassade title för programmet "YouthOrPensioner" 
/// </summary>
void YouthOrPensionerTheme()
{
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Title = "Youth Or Pensioner";
}

/// <summary>
/// Den här metoden förändra bakgrundsfärgen och förgrundsfärgen
/// och ändrar fönsters titeln till anpassade title för programmet "RepeatTenTimes". 
/// </summary>
void RepeatTenTimesTheme()
{
    Console.BackgroundColor = ConsoleColor.Cyan;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Title = "Repeat Ten Times";
}

/// <summary>
/// Den här metoden förändra bakgrundsfärgen och förgrundsfärgen
/// och ändrar fönsters titeln till anpassade title för programmet "TheThirdWord". 
/// </summary>
void TheThirdWordTheme()
{
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Title = "The Third Word";
}