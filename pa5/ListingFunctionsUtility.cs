namespace pa5
{
    public class ListingFunctionsUtility
    {
        // add listing
        public static void addListing(string[] listingId, string[] TrainerName, string[] dateOfSession, string[] timeOfSession, int[] costOfSession, string[] sessionTaken, int count)
        {
            StreamWriter inFile = new StreamWriter("Listings.txt");
            for(int i = 0; i < count; i++)
            {
                inFile.WriteLine($"{listingId[i]}#{TrainerName[i]}#{dateOfSession[i]}#{timeOfSession[i]}#{costOfSession[i]}#{sessionTaken[i]}#");
            }
            inFile.Write(Guid.NewGuid().ToString() + "#");
            Console.WriteLine("What is the trainers name?");
            inFile.Write(Console.ReadLine() + "#");
            Console.WriteLine("What is the Date of the session? (mm-dd-yy)");
            inFile.Write(Console.ReadLine() + "#");
            Console.WriteLine("What is the time of the session?");
            inFile.Write(Console.ReadLine() + "#");
            Console.WriteLine("What is the cost of the session?");
            inFile.Write(Console.ReadLine() + "#");
            Console.WriteLine("Is the session taken? Please write taken if so, free if not");
            inFile.Write(Console.ReadLine() + "#");
            inFile.Close();
        }

        // remove listing
        public static void removeListing(listingFunctions[] listings, int count)
        {
            StreamReader infile = new StreamReader("Listings.txt");
            string line = infile.ReadLine();
            count = 0;
            while (line != null)
            {
                string[] temp = line.Split("#");
                if(temp.Length < 3)
                    break;
                listings[count] = new listingFunctions();
                listings[count].SetListingId(temp[0]);
                listings[count].SetTrainerName(temp[1]);
                listings[count].SetDateOfSession(temp[2]);
                listings[count].SetTimeOfSession(temp[3]);
                listings[count].SetCostOfSession(int.Parse(temp[4]));
                listings[count].SetSessionTaken(temp[5]);
                count ++;
                line = infile.ReadLine();
            }
            infile.Close();

            string remove2;
            Console.WriteLine("What is the name of the trainer on the listing you would like to remove?");
            remove2 = Console.ReadLine();
            StreamWriter inFile = new StreamWriter("Listings.txt");
            for(int i = 0; i < count; i++)
            {
                if(remove2 != listings[i].GetTrainerName())
                {
                    inFile.WriteLine($"{listings[i].GetListingId()}#{listings[i].GetTrainerName()}#{listings[i].GetDateOfSession()}#{listings[i].GetTimeOfSession()}#{listings[i].GetCostOfSession()}#{listings[i].GetSessionTaken()}#");
                }
            }
            inFile.Close();
        }

        // edit listing
        public static void editListing(listingFunctions[] listings, int count)
        {
            StreamReader infile = new StreamReader("Listings.txt");
            string line = infile.ReadLine();
            while (line != null)
            {
                count = 0;
                string[] temp = line.Split("#");
                if(temp.Length < 3)
                    break;
                listings[count] = new listingFunctions();
                listings[count].SetListingId(temp[0]);
                listings[count].SetTrainerName(temp[1]);
                listings[count].SetDateOfSession(temp[2]);
                listings[count].SetTimeOfSession(temp[3]);
                listings[count].SetCostOfSession(int.Parse(temp[4]));
                listings[count].SetSessionTaken(temp[5]);
                count ++;
                line = infile.ReadLine();
            }
            infile.Close();
            string edit2;
            Console.WriteLine("What is the name of the trainer for the listing you would like to edit?");
            edit2 = Console.ReadLine();
            StreamWriter inFile = new StreamWriter("Listings.txt");
            bool flag = false;
            for(int i = 0; i < count; i++)
            {
                if(edit2 == listings[i].GetTrainerName())
                {
                    flag = true;
                    Console.WriteLine("What is the trainers name?");
                    inFile.Write(Console.ReadLine() + "#");
                    Console.WriteLine("What is the Date of the session?");
                    inFile.Write(Console.ReadLine() + "#");
                    Console.WriteLine("What is the time of the session?");
                    inFile.Write(Console.ReadLine() + "#");
                    Console.WriteLine("What is the cost of the session?");
                    inFile.Write(Console.ReadLine() + "#");
                    Console.WriteLine("Is the session taken? Please write taken if so, free if not");
                    inFile.Write(Console.ReadLine() + "#");
                }
                else
                {
                    inFile.WriteLine($"{listings[i].GetListingId()}#{listings[i].GetTrainerName()}#{listings[i].GetDateOfSession()}#{listings[i].GetTimeOfSession()}#{listings[i].GetCostOfSession()}#{listings[i].GetSessionTaken()}#");
                }
            }
            if(flag == false)
            {
                Console.WriteLine("Trainer not found");
            }
            inFile.Close();
        }
    }
}