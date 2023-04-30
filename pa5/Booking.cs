namespace pa5
{
    public class Booking
    {
        // view availible listings
        public static void VeiwBookings(listingFunctions[] listings, int count)
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

            for(int i = 0; i < count; i++)
            {
                if(listings[i].GetSessionTaken() != "taken")
                {
                    Console.WriteLine($"{listings[i].GetListingId()} with {listings[i].GetTrainerName()} on {listings[i].GetDateOfSession()} at {listings[i].GetTimeOfSession()} for {listings[i].GetCostOfSession()}");
                }
            }
        }

        // book a session
        public static void BookOne(listingFunctions[] listings, Trainer[] Trainers, int count)
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
            StreamReader insfile = new StreamReader("Trainers.txt");
            string line2 = insfile.ReadLine();
            count = 0;
            while (line2 != null)
            {
                string[] temp = line2.Split("#");
                if(temp.Length < 3)
                    break;
                Trainers[count] = new Trainer();
                Trainers[count].SettrainerId(temp[0]);
                Trainers[count].SettrainerName(temp[1]);
                Trainers[count].SettrainerMailing(temp[2]);
                Trainers[count].SettrainerEmail(temp[3]);
                count ++;
                line2 = insfile.ReadLine();
            }
            insfile.Close();
            string answer;
            System.Console.WriteLine("What is the name of the trainer for the session you would like to book?");
            answer = Console.ReadLine();
            for(int i = 0; i < count; i++)
            {
                if(answer == listings[i].GetTrainerName())
                {
                    StreamWriter inFile = new StreamWriter("transactions.txt", true);
                    inFile.Write($"{listings[i].GetListingId()}#{Trainers[i].GettrainerId()}#{Trainers[i].GettrainerName()}#{listings[i].GetDateOfSession()}#");
                    Console.WriteLine("What is your name?");
                    inFile.Write(Console.ReadLine() + "#");
                    Console.WriteLine("What is your Email?");
                    inFile.Write(Console.ReadLine() + "#");
                    inFile.Write("Booked#");
                    inFile.WriteLine();
                    inFile.Close();
                }
            }
        }
        public static void EditBooking(int count)
        {
            string answer2;
            StreamReader infile = new StreamReader("transactions.txt");
            string line = infile.ReadLine();
            count = 0;
            listingFunctions[] listings = new listingFunctions[100];
            Trainer[] Trainers = new Trainer[100];
            BookingUtility[] transactions = new BookingUtility[100];
            while (line != null)
            {
                string[] temp = line.Split("#");
                if(temp.Length < 3)
                    break;
                listings[count] = new listingFunctions();
                Trainers[count] = new Trainer();
                transactions[count] = new BookingUtility();
                listings[count].SetListingId(temp[0]);
                Trainers[count].SettrainerId(temp[1]);
                Trainers[count].SettrainerName(temp[2]);
                listings[count].SetDateOfSession(temp[3]);
                transactions[count].SetCustomerName(temp[4]);
                transactions[count].SetCustomerEmail(temp[5]);
                transactions[count].SetStatus(temp[6]);
                count ++;
                line = infile.ReadLine();
            }
            infile.Close();
            System.Console.WriteLine("What is the name of the customer you would like to edit?");
            answer2 = Console.ReadLine();
            StreamWriter inFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < count; i++)
            {
                if(answer2 == transactions[i].GetCustomerName())
                {
                    inFile.Write($"{listings[i].GetListingId()}#{Trainers[i].GettrainerId()}#{Trainers[i].GettrainerName()}#{listings[i].GetDateOfSession()}#{transactions[i].GetCustomerName()}#{transactions[i].GetCustomerEmail()}#");
                    System.Console.WriteLine("What is the new status of the transaction");
                    inFile.Write(Console.ReadLine() + "#");
                    inFile.WriteLine();
                }
                else
                {
                    inFile.Write($"{listings[i].GetListingId()}#{Trainers[i].GettrainerId()}#{Trainers[i].GettrainerName()}#{listings[i].GetDateOfSession()}#{transactions[i].GetCustomerName()}#{transactions[i].GetCustomerEmail()}#");
                    inFile.Write($"{transactions[i].GetStatus()}#");
                    inFile.WriteLine();
                }
            }
            inFile.Close();
        }
    }
}