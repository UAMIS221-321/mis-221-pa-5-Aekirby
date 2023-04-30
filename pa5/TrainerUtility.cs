namespace pa5
{
    public class TrainerUtility
    {
        // Adds trainers
        public static void addTrainer(string[] trainerId, string[] trainerName, string[] trainerMailing, string[] trainerEmail, int count)
        {
            StreamWriter inFile = new StreamWriter("Trainers.txt", true);
            inFile.Write(Guid.NewGuid().ToString() + "#");
            Console.WriteLine("What is the trainers name?");
            inFile.Write(Console.ReadLine() + "#");
            Console.WriteLine("What is the tainers mailing address?");
            inFile.Write(Console.ReadLine() + "#");
            Console.WriteLine("What is the trainers Email?");
            inFile.Write(Console.ReadLine() + "#");
            inFile.WriteLine();
            inFile.Close();
        }

        // Removes trianers
        public static void removeTrainer(Trainer[] Trainers, int count)
        {
            StreamReader infile = new StreamReader("Trainers.txt");
            string line = infile.ReadLine();
            count = 0;
            while (line != null)
            {
                string[] temp = line.Split("#");
                if(temp.Length < 3)
                    break;
                Trainers[count] = new Trainer();
                Trainers[count].SettrainerId(temp[0]);
                Trainers[count].SettrainerName(temp[1]);
                Trainers[count].SettrainerMailing(temp[2]);
                Trainers[count].SettrainerEmail(temp[3]);
                count ++;
                line = infile.ReadLine();
            }
            infile.Close();

            string remove;
            Console.WriteLine("What is the name of the trainer you would like to remove?");
            remove = Console.ReadLine();
            StreamWriter inFile = new StreamWriter("Trainers.txt");
            for(int i = 0; i < count; i++)
            {
                if(remove != Trainers[i].GettrainerName())
                {
                    inFile.WriteLine($"{Trainers[i].GettrainerId()}#{Trainers[i].GettrainerName()}#{Trainers[i].GettrainerMailing()}#{Trainers[i].GettrainerEmail}#");
                }
            }
            inFile.Close();
        }

        // edits trainers
        public static void editTrainer(Trainer[] Trainers,int count)
        {
            count = 0;
            StreamReader infile = new StreamReader("Trainers.txt");
            string line = infile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split("#");
                if(temp.Length < 3)
                    break;
                Trainers[count] = new Trainer();
                Trainers[count].SettrainerId(temp[0]);
                Trainers[count].SettrainerName(temp[1]);
                Trainers[count].SettrainerMailing(temp[2]);
                Trainers[count].SettrainerEmail(temp[3]);
                count ++;
                line = infile.ReadLine();
            }
            infile.Close();
            string edit;
            Console.WriteLine("What is the name of the trainer you would like to edit?");
            edit = Console.ReadLine();
            StreamWriter inFile = new StreamWriter("Trainers.txt");
            bool flag = false;
            for(int i = 0; i < count; i++)
            {
                if(edit == Trainers[i].GettrainerName())
                {
                    flag = true;
                    inFile.Write(Trainers[i].GettrainerId() + "#");
                    Console.WriteLine("What is the trainers name?");
                    inFile.Write(Console.ReadLine() + "#");
                    Console.WriteLine("What is the trainers mailing address?");
                    inFile.Write(Console.ReadLine() + "#");
                    Console.WriteLine("What is the trainers Email?");
                    inFile.Write(Console.ReadLine() + "#");
                    inFile.WriteLine();
                }
                else
                {
                    inFile.WriteLine($"{Trainers[i].GettrainerId()}#{Trainers[i].GettrainerName()}#{Trainers[i].GettrainerMailing()}#{Trainers[i].GettrainerEmail}#");
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