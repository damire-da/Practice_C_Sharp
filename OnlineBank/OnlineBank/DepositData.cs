using OnlineBank.Models;

namespace OnlineBank
{
    public static class DepositData
    {
        public static void Initialize(BankContext context)
        {
            if (!context.Deposits.Any())
            {
                context.Deposits.AddRange(
                    new Deposit
                    {
                        Name = "Сберегательный+",
                        Percent = 5.4
                    },
                    new Deposit
                    {
                        Name = "Счастливая монета",
                        Percent = 6.6
                    },
                    new Deposit
                    {
                        Name = "Удобный",
                        Percent = 5.7
                    },
                    new Deposit
                    {
                        Name = "Классический",
                        Percent = 4.5
                    }
                ) ;
                context.SaveChanges();

            }
        }
    }
}
