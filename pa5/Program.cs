using pa5;

string[] trainerId = new string[100]; 
string[] trainerName = new string[100];
string[] trainerMailing = new string[100];
string[] trainerEmail = new string[100];
int count = 0;
Trainer[] Trainers = new Trainer[100];
string[] listingId = new string[100];
string[] TrainerName = new string[100];
string[] dateOfSession = new string[100];
string[] timeOfSession = new string[100];
int[] costOfSession = new int[100];
string [] sessionTaken = new string[100];
listingFunctions[] listings = new listingFunctions[100];
BookingUtility[] transactions = new BookingUtility[100];
string[] SetCustomerName = new string[100];
string[] SetCustomerEmail = new string[100];
string[] SetStatus = new string[100];
int choice = 0;

while(choice != 9)
{
    count = 0;
    Console.WriteLine("Welcome to Train like a Champion, Press 1 for trainer info, press 2 for listing info, press 3 for Bookings, press 4 for reports. Press 9 to exit.");
    choice = Convert.ToInt32(Console.ReadLine());
    if(choice == 1)
    {
        Console.WriteLine("Press 1 to add a trainer, press 2 to remove a trainer, press 3 to edit a trainer");
            choice = Convert.ToInt32(Console.ReadLine());
            StreamReader infile = new StreamReader("Trainers.txt");
            string line = infile.ReadLine();

            while (line != null)
            {
                string[] temp = line.Split("#");
                if(temp.Length < 3)
                    break;
                trainerId[count] = temp[0];
                trainerName[count] = temp[1];
                trainerMailing[count] = temp[2];
                trainerEmail[count] = temp[3];
                count ++;
                line = infile.ReadLine();
            }
            infile.Close();
        if(choice == 1)
        {
            TrainerUtility.addTrainer(trainerId, trainerName, trainerMailing, trainerEmail, count);
        }

        if(choice == 2)
        {
            TrainerUtility.removeTrainer(Trainers, count);
        }

        if(choice == 3)
        {
            TrainerUtility.editTrainer(Trainers, count);
        }
    }
     else if(choice == 2)
    {
        Console.WriteLine("Press 1 to add a listing, press 2 to remove a listing, press 3 to edit a listing");
        choice = Convert.ToInt32(Console.ReadLine());
        StreamReader infile = new StreamReader("Listings.txt");
        string line = infile.ReadLine();

        while (line != null)
        {
            string[] temp = line.Split("#");
            if(temp.Length < 3)
                break;
            listingId[count] = temp[0];
            TrainerName[count] = temp[1];
            dateOfSession[count] = temp[2];
            timeOfSession[count] = temp[3];
            costOfSession[count] = int.Parse(temp[4]);
            sessionTaken[count] = temp[5];
            count ++;
            line = infile.ReadLine();
        }
        infile.Close();
        if(choice == 1)
        {
            ListingFunctionsUtility.addListing(listingId, TrainerName, dateOfSession, timeOfSession, costOfSession, sessionTaken, count);
        }

        if(choice == 2)
        {
            ListingFunctionsUtility.removeListing(listings, count);
        }

        if(choice == 3)
        {
            ListingFunctionsUtility.editListing(listings, count);
        }
    }
    else if(choice == 3)
    {
        Console.WriteLine("Press 1 to view availible sessions or press 2 to book a session, 3 to edit a session");
        choice = Convert.ToInt32(Console.ReadLine());
        if(choice == 1)
        {
            Booking.VeiwBookings(listings, count);
        }
        if(choice == 2)
        {
            Booking.BookOne(listings, Trainers, count);
        }
        if(choice == 3)
        {
            Booking.EditBooking(count);
        }
    }
    else if(choice == 4)
    {
        System.Console.WriteLine("Press 1 for individual report, press 2 for historical customer sessions, press 3 for historical revenue report");
        choice = Convert.ToInt32(Console.ReadLine());
        if(choice == 1)
        {
            Reports.IndividualReport(transactions, listings, Trainers, count);
        }
        if(choice == 2)
        {
            Reports.HistoricalCustomerSessions(transactions, listings, Trainers, count);
        }
        if(choice == 3)
        {
            Reports.RevenueReport(listings, count);
        }
    }
}