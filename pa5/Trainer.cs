namespace pa5
{
    public class Trainer
    {
        string trainerId;
        string trainerName;
        string trainerMailing;
        string trainerEmail;
        public Trainer(){}
        public string GettrainerId()
        {
            return this.trainerId;
        }
        public void SettrainerId(string trainerId)
        {
            this.trainerId = trainerId;
        }
        public string GettrainerName()
        {
            return this.trainerName;
        }
        public void SettrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public string GettrainerMailing()
        {
            return this.trainerMailing;
        }
        public void SettrainerMailing(string trainerMailing)
        {
            this.trainerMailing = trainerMailing;
        }
        public string GettrainerEmail()
        {
            return this.trainerEmail;
        }
        public void SettrainerEmail(string trainerEmail)
        {
            this.trainerEmail = trainerEmail;
        }
    }
}