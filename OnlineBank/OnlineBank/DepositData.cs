using OnlineBank.Models;

namespace OnlineBank
{
    public static class DepositData
    {
        public static void Initialize(BankContext context)
        {
            if (!context.DepositsInfo.Any())
            {
                context.DepositsInfo.AddRange(
                    new DepositInfo
                    {
                        Name = "Сберегательный+",
                        Percent = 5.4,
                        Info = "Lorem Ipsum is simply dummy text of " +
                        "the printing and typesetting industry. Lorem Ipsum " +
                        "has been the industry's standard dummy text ever since " +
                        "the 1500s, when an unknown printer took a galley of type " +
                        "and scrambled it to make a type specimen book. It has survived "
                    },
                    new DepositInfo
                    {
                        Name = "Счастливая монета",
                        Percent = 6.6,
                        Info = "Это вклад2"
                    },
                    new DepositInfo
                    {
                        Name = "Удобный",
                        Percent = 5.7,
                        Info = "Это вклад3"
                    },
                    new DepositInfo
                    {
                        Name = "Классический",
                        Percent = 4.5,
                        Info = "Это вклад4"

                    }
                ) ;
                context.SaveChanges();

            }
        }
    }
}
