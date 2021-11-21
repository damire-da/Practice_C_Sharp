namespace OnlineBank.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Deposit[] Deposit { get; set; } //вместо массива использовать список
    }  
}
