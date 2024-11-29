internal class Program
{
    private static void Main(string[] args)
    {
        string wahlen = "yes";
        int user = 0;
        int comp = 0;
        int rund = 1;
        Program program = new Program();
        program.LoadScores(out user, out comp);
        Console.WriteLine("Do you want to delete old score? Yes/No");
        Console.WriteLine($"You {user} - me {comp}");
        string scoreDelete = Console.ReadLine();
        scoreDelete = scoreDelete.ToLower();
        while (scoreDelete != "yes" && scoreDelete != "no")
        {
            Console.WriteLine("Yes or No");
            scoreDelete = scoreDelete.ToLower();
            scoreDelete = Console.ReadLine();
        }
        switch (scoreDelete)
        {
            case "yes":
                Console.WriteLine("Let's start again!");
                user = 0;
                comp = 0;
                break;
            case "no":
                Console.WriteLine("Let's continue our game!");
                break;
        }

        while (wahlen == "yes")
        {
            Random random = new Random();
            int i = random.Next(1, 4);
            Console.WriteLine($"Round {rund}:");
            Console.WriteLine("Choose your weapon: Schere, Stein, Papier");
            string spieler = Console.ReadLine();
            spieler = spieler.ToLower();
            while (spieler != "schere" && spieler != "stein" && spieler != "papier")
            {
                Console.WriteLine("Schere, Stein, Papier");
                spieler = Console.ReadLine();
                spieler = spieler.ToLower();
            }
            string bot = "";
            switch (i)
            {
                case 1:
                    bot = "Schere"; 
                    break;
                case 2:
                    bot = "Stein";
                    break;
                case 3:
                    bot = "Papier";
                    break;
            }
            Console.WriteLine(bot);
            if (
                (spieler == "schere" && bot == "Papier") ||
                (spieler == "stein" && bot == "Schere") ||
                (spieler == "papier" && bot == "Stein")
                )
            {
                Console.WriteLine("You win");
                user++;
            }
            else if (
                (spieler == "schere" && bot == "Schere") ||
                (spieler == "stein" && bot == "Stein") ||
                (spieler == "papier" && bot == "Papier")
                )
            {
                Console.WriteLine("Draw");
            }
            else
            {
                Console.WriteLine("You lose");
                comp++; 
            }

            //if (f == "schere")
            //{
            //    switch (i)
            //    {
            //        case 1:
            //            Console.WriteLine("Schere");
            //            Console.WriteLine("Draw");
            //            break;
            //        case 2:
            //            Console.WriteLine("Stein");
            //            Console.WriteLine("You lose");
            //            comp++;
            //            break;
            //        case 3:
            //            Console.WriteLine("Papier");
            //            Console.WriteLine("You win");
            //            user++;
            //            break;
            //    }

            //}
            //else if (f == "stein")
            //{
            //    switch (i)
            //    {
            //        case 1:
            //            Console.WriteLine("Schere");
            //            Console.WriteLine("You win");
            //            user++;
            //            break;
            //        case 2:
            //            Console.WriteLine("Stein");
            //            Console.WriteLine("Draw");
            //            break;
            //        case 3:
            //            Console.WriteLine("Papier");
            //            Console.WriteLine("You lose");
            //            comp++;
            //            break;
            //    }

            //}
            //else
            //{
            //    switch (i)
            //    {
            //        case 1:
            //            Console.WriteLine("Schere");
            //            Console.WriteLine("You lose");
            //            comp++;
            //            break;
            //        case 2:
            //            Console.WriteLine("Stein");
            //            Console.WriteLine("You win");
            //            user++;
            //            break;
            //        case 3:
            //            Console.WriteLine("Papier");
            //            Console.WriteLine("Draw");
            //            break;
            //    }

            //}
            Console.WriteLine($"Score: You - {user}, me - {comp}");
            Console.WriteLine("Do you want to continue? yes/no");
            wahlen = Console.ReadLine();
            wahlen = wahlen.ToLower();
            while (wahlen != "yes" && wahlen != "no")
            {
                Console.WriteLine("yes/no");
                wahlen = Console.ReadLine();
                wahlen = wahlen.ToLower();
            }
            rund++;
            Console.Clear();
        }
        program.SaveScores(user, comp);
    }
    void SaveScores(int user, int comp)
    {
        string filePath = "scores.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(user);
            writer.WriteLine(comp);
        }
    }

    void LoadScores(out int user, out int comp)
    {
        string filePath = "scores.txt";
        user = 0;
        comp = 0;

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line1 = reader.ReadLine();
                string line2 = reader.ReadLine();

                if (int.TryParse(line1, out int u) && int.TryParse(line2, out int c))
                {
                    user = u;
                    comp = c;
                }
            }
        }
    }


}
