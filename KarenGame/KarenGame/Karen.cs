using System;
using System.Collections.Generic;

class KarenAdventure
{
    static int patience = 10;
    static int xp = 0;
    static List<string> inventory = new List<string>();

    static void Main()
    {
        Console.Title = "Karen Adventure";

        Console.WriteLine("Velkommen til KarenVille!");
        Console.WriteLine("Du er en modig sjæl, der står over for de mest udfordrende Karens i verden.");
        Console.WriteLine("Vælg dit Karen Eventyr");
        Console.WriteLine("Du starter med 10 tålmodighedspoint. Brug dem fornuftigt!\n");
        Console.WriteLine("Du har " + patience + " tålmodighed.\n");

        Quest1();
        if (IsGameOver()) return;

        Quest2();
        if (IsGameOver()) return;

        Quest3();
        if (IsGameOver()) return;

        FinalQuest();
    }


    
     

    static void Quest1()
    {
        Console.WriteLine("Quest 1: Coupon Kaos");
        Console.WriteLine("En Karen skriger: 'DENNE KUPON GÆLDER STADIG!'");
        Console.WriteLine("1: Forklar roligt at kuponen er udløbet.");
        Console.WriteLine("2: Forklare at kuponen er ugyldig.");
        Console.WriteLine("3: Tilkald chefen.");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.WriteLine("Karen sukker højt, men accepterer det. +1 XP");
            xp += 1;

        }
        else if (choice == "2")
        {
            Console.WriteLine("Det eskalerer! Tålmodighed -3.");
            patience -= 3;
        }
        else if (choice == "3")
        {
            Console.WriteLine("Chefen kommer. Du får hendes kupon. (+ item)");
            inventory.Add("Ugyldig kupon");
        }

        ShowStats();
    }

    static void Quest2()
    {
        Console.WriteLine("Quest 2: Parkering Forbudt");
        Console.WriteLine("En Karen har blokeret 3 handicappladser med sin SUV.");
        Console.WriteLine("1: Tag et billede og meld det anonymt.");
        Console.WriteLine("2: Konfronter hende direkte.");
        Console.WriteLine("3: Ignorer det.");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.WriteLine("Godt tænkt! +2 XP. Du får 'Foto-bevis'.");
            xp += 2;
            inventory.Add("Foto-bevis");
        }
        else if (choice == "2")
        {
            Console.WriteLine("Hun råber dig ned. Tålmodighed -2.");
            patience -= 2;
        }
        else if (choice == "3")
        {
            Console.WriteLine("Intet sker... men du føler dig passiv.");
        }

        ShowStats();
    }

    static void Quest3()
    {
        Console.WriteLine("Quest 3: Retshuset");
        Console.WriteLine("Supreme Karen: 'Alle huse skal være BEIGE!'");
        Console.WriteLine("1: Brug dit Foto-bevis som bevis og argumentér.");
        Console.WriteLine("2: Råb af hende.");
        Console.WriteLine("3: Giv op og nyd beige.");

        string choice = Console.ReadLine();

        if (choice == "1" && inventory.Contains("Foto-bevis"))
        {
            Console.WriteLine("Publikum jubler! +3 XP");
            xp += 3;
        }
        else if (choice == "2")
        {
            Console.WriteLine("Du bliver smidt ud. Tålmodighed -3.");
            patience -= 3;
        }
        else if (choice == "3")
        {
            Console.WriteLine("Supreme Karen jubler. Du mister lidt XP.");
            xp -= 1;
        }


        ShowStats();
    }

    static void FinalQuest()
    {
        Console.WriteLine("Final Quest: Debatten om Skæbnen");
        Console.WriteLine("Supreme Karen: 'Jeg ER chefen! Jeg bestemmer ALT!'");
        Console.WriteLine("1: Brug beviser og argumentér med ro.");
        Console.WriteLine("2: Råb højere end hende.");
        Console.WriteLine("3: Giv hende en kop kaffe og spørg om hun er okay.");

        string choice = Console.ReadLine();

        if (choice == "1" && xp >= 5)
        {
            Console.WriteLine("\n Du vinder debatten og stopper Supreme Karen. Verden er fri!");
            WinScreen();
        }
        else if (choice == "2")
        {
            Console.WriteLine("Hun anklager dig offentligt. Du mister al tålmodighed.");
            patience = 0;
            CheckGameOver();
        }
        else if (choice == "3")
        {
            Console.WriteLine("Hun tøver... og begynder at græde. Du vinder på empati.");
            Console.WriteLine("Du opnåede den SANDHEDSBASEREDE SLUTNING");
        }
        else
        {
            Console.WriteLine("Hun ignorerer dig. Verden bliver beige...");
        }

        ShowStats();
    }

    static void ShowStats()
    {
        Console.WriteLine($"\n Tålmodighed: {patience} | ⭐ XP: {xp}");
        Console.WriteLine(" Inventar: " + string.Join(", ", inventory));
    }

    static bool IsGameOver()
    {
        if (patience <= 0)
        {
            Console.WriteLine("\n Du mistede al din tålmodighed. Karen vandt.");
            Console.WriteLine("GAME OVER");
            return true;
        }
        return false;
    }

    static void CheckGameOver()
    {
        if (patience <= 0)
        {
            Console.WriteLine("\n Din tålmodighed slap op. GAME OVER.");
        }
    }

    static void WinScreen()
    {
        Console.WriteLine("\n Tak fordi du spillede KarenVille!");
        Console.WriteLine("Tryk Enter for at afslutte...");
        Console.ReadLine();
    }
}
