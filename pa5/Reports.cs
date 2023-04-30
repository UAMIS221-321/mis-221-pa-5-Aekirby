namespace pa5
{
    public class Reports
    {
        public static void IndividualReport(BookingUtility[] transactions, listingFunctions[] listings, Trainer[] Trainers, int count)
        {
            string option;
            string report;
            string file;
            StreamReader infile = new StreamReader("transactions.txt");
            string line = infile.ReadLine();
            count = 0;
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
            System.Console.WriteLine("What is the Email address of the customer you would like to see?");
            report = Console.ReadLine();
            for(int i = 0; i < count; i++)
            {
                if(report == transactions[i].GetCustomerEmail())
                {
                    System.Console.WriteLine($"{listings[i].GetListingId()} with {Trainers[i].GettrainerId()}#{Trainers[i].GettrainerName()} on {listings[i].GetDateOfSession()} and the status is {transactions[i].GetStatus()}");
                }
            }
            System.Console.WriteLine("Would you like to save to a file? (y/n)");
            option = Console.ReadLine();
            if(option == "y")
            {
                System.Console.WriteLine("What file would you like to save it to?");
                file = Console.ReadLine();
                StreamWriter outfile = new StreamWriter(@file);
                System.Console.WriteLine("Please enter the customers email address again");
                report = Console.ReadLine();
                for(int i = 0; i < count; i++)
                {
                    if(report == transactions[i].GetCustomerEmail())
                    {
                        outfile.WriteLine($"{listings[i].GetListingId()} with {Trainers[i].GettrainerId()}#{Trainers[i].GettrainerName()} on {listings[i].GetDateOfSession()} and the status is {transactions[i].GetStatus()}");
                    }
                }
                outfile.Close();
            }
        }
        public static void HistoricalCustomerSessions(BookingUtility[] transactions, listingFunctions[] listings, Trainer[] Trainers, int count)
        {
            string option;
            string file;
            StreamReader infile = new StreamReader("transactions.txt");
            string line = infile.ReadLine();
            count = 0;
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
            bool skip = false;
            for(int i = 0; i < count; i++)
            {
                for(int j = i; j < count; j++)
                {
                    if(transactions[i].GetCustomerName().CompareTo(transactions[j].GetCustomerName()) != -1)
                    {
                        if(transactions[i].GetCustomerName().CompareTo(transactions[j].GetCustomerName()) == 0)
                        {
                            if(listings[i].GetDateOfSession().CompareTo(listings[j].GetDateOfSession()) == 1)
                            {
                                skip = false;
                            }
                            else
                            {
                                skip = true;
                            }
                        }
                        if(skip == false)
                        {
                            BookingUtility transactionstemp = new BookingUtility();
                            listingFunctions listingstemp = new listingFunctions();
                            Trainer trainerstemp = new Trainer();
                            listingstemp.SetListingId(listings[i].GetListingId());
                            trainerstemp.SettrainerId(Trainers[i].GettrainerId());
                            trainerstemp.SettrainerName(Trainers[i].GettrainerName());
                            listingstemp.SetDateOfSession(listings[i].GetDateOfSession());
                            transactionstemp.SetCustomerName(transactions[i].GetCustomerName());
                            transactionstemp.SetCustomerEmail(transactions[i].GetCustomerEmail());
                            transactionstemp.SetStatus(transactions[i].GetStatus());

                            listings[i].SetListingId(listings[j].GetListingId());
                            Trainers[i].SettrainerId(Trainers[j].GettrainerId());
                            Trainers[i].SettrainerName(Trainers[j].GettrainerName());
                            listings[i].SetDateOfSession(listings[j].GetDateOfSession());
                            transactions[i].SetCustomerName(transactions[j].GetCustomerName());
                            transactions[i].SetCustomerEmail(transactions[j].GetCustomerEmail());
                            transactions[i].SetStatus(transactions[j].GetStatus());

                            listings[j].SetListingId(listingstemp.GetListingId());
                            Trainers[j].SettrainerId(trainerstemp.GettrainerId());
                            Trainers[j].SettrainerName(trainerstemp.GettrainerName());
                            listings[j].SetDateOfSession(listingstemp.GetDateOfSession());
                            transactions[j].SetCustomerName(transactionstemp.GetCustomerName());
                            transactions[j].SetCustomerEmail(transactionstemp.GetCustomerEmail());
                            transactions[j].SetStatus(transactionstemp.GetStatus());
                        }
                        skip = false;
                    }
                }
                System.Console.WriteLine($"{listings[i].GetListingId()}  {transactions[i].GetCustomerName()} with {Trainers[i].GettrainerId()}#{Trainers[i].GettrainerName()} on {listings[i].GetDateOfSession()} and the status is {transactions[i].GetStatus()}");
            }
            System.Console.WriteLine("Would you like to save to a file? (y/n)");
            option = Console.ReadLine();
            if(option == "y")
            {
                System.Console.WriteLine("What file would you like to save it to?");
                file = Console.ReadLine();
                StreamWriter outfile = new StreamWriter(@file);
                for(int i = 0; i < count; i++)
                {
                    outfile.WriteLine($"{listings[i].GetListingId()}  {transactions[i].GetCustomerName()} with {Trainers[i].GettrainerId()}#{Trainers[i].GettrainerName()} on {listings[i].GetDateOfSession()} and the status is {transactions[i].GetStatus()}");
                }
                outfile.Close();
            }
        }
        public static void RevenueReport(listingFunctions[] listings, int count)
        {
            string option;
            string file;
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
            int[] monthlyPrices = new int[12]{0,0,0,0,0,0,0,0,0,0,0,0};
            for(int i = 0; i < count; i++)
            {
                char[] date = listings[i].GetDateOfSession().ToCharArray();
                int month = (int)char.GetNumericValue(date[0]) * 10 + (int)char.GetNumericValue(date[1]);
                monthlyPrices[month - 1] += listings[i].GetCostOfSession();
            }
            for(int i = 0; i < 12; i++)
            {
                System.Console.WriteLine("Revenue for month " + (i + 1) + " is $" + monthlyPrices[i]);
            }
            int yearCounter = 0;
            string[] years = new string[50];
            int[] yearstotalPrice = new int[50];
            bool isFound = false;
            for(int i = 0; i < count; i++)
            {
                char[] date = listings[i].GetDateOfSession().ToCharArray();
                int year = (int)char.GetNumericValue(date[6]) * 10 + (int)char.GetNumericValue(date[7]);
                for(int j = 0; j < yearCounter; j++)
                {
                    if(years[j] == year.ToString())
                    {
                        yearstotalPrice[j] += listings[i].GetCostOfSession();
                        isFound = true;
                    }
                }
                if(isFound == false)
                {
                    yearstotalPrice[yearCounter] += listings[i].GetCostOfSession();
                    years[yearCounter] = year.ToString();
                    yearCounter++;
                }
                isFound = false;
            }
            for(int i = 0; i < yearCounter; i++)
            {
                System.Console.WriteLine("Revenue for year " + years[i] + " is $" + yearstotalPrice[i]);
            }
            System.Console.WriteLine("Would you like to save to a file? (y/n)");
            option = Console.ReadLine();
            if(option == "y")
            {
                System.Console.WriteLine("What file would you like to save it to?");
                file = Console.ReadLine();
                StreamWriter outfile = new StreamWriter(@file);
                for(int i = 0; i < 12; i++)
                {
                    outfile.WriteLine("Revenue for month " + (i + 1) + " is $" + monthlyPrices[i]);
                }
                for(int i = 0; i < yearCounter; i++)
                {
                    outfile.WriteLine("Revenue for year " + years[i] + " is $" + yearstotalPrice[i]);
                }
                outfile.Close();
            }
        }
    }
}