namespace pa5
{
    public class BookingUtility
    {
        string customerName;
        string customerEmail;
        string status;
        public BookingUtility(){}
        public string GetCustomerName()
        {
            return this.customerName;
        }
        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string GetCustomerEmail()
        {
            return this.customerEmail;
        }
        public void SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }
        public string GetStatus()
        {
            return this.status;
        }
        public void SetStatus(string status)
        {
            this.status = status;
        }
    }
}