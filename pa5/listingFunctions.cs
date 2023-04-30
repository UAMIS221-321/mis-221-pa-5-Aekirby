namespace pa5
{
    public class listingFunctions
    {
        string listingId;
        string TrainerName;
        string dateOfSession;
        string timeOfSession;
        int costOfSession;
        string sessionTaken;
        public listingFunctions(){}
        public string GetListingId()
        {
            return this.listingId;
        }
        public void SetListingId(string listingId)
        {
            this.listingId = listingId;
        }
        public string GetTrainerName()
        {
            return this.TrainerName;
        }
        public void SetTrainerName(string TrainerName)
        {
            this.TrainerName = TrainerName;
        }
        public string GetDateOfSession()
        {
            return this.dateOfSession;
        }
        public void SetDateOfSession(string dateOfSession)
        {
            this.dateOfSession = dateOfSession;
        }
        public string GetTimeOfSession()
        {
            return this.timeOfSession;
        }
        public void SetTimeOfSession(string timeOfSession)
        {
            this.timeOfSession = timeOfSession;
        }
        public int GetCostOfSession()
        {
            return this.costOfSession;
        }
        public void SetCostOfSession(int costOfSession)
        {
            this.costOfSession = costOfSession;
        }
        public string GetSessionTaken()
        {
            return this.sessionTaken;
        }
        public void SetSessionTaken(string sessionTaken)
        {
            this.sessionTaken = sessionTaken;
        }
    }
}