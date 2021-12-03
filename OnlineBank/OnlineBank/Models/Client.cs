﻿namespace OnlineBank.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Deposit1> Deposits { get; set ;} = new();
    }  
}
