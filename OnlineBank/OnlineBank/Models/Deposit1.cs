namespace OnlineBank.Models
{
    public class Deposit1
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Percent { get; set; }
        public string Info
        {
            get; set;
        }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
