using System;

namespace GSMCallHistoryTest
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            try
            {
                GSM phone = new GSM("C1", "Nokia", 49.99, "Me", new Battery("ZXKL0982-34", 400, 14, BatteryType.LiIon),
                new Display(7, 256000));

                Console.WriteLine(phone.ToString());

                phone.AddNewCall(new Call(new DateTime(2013, 2, 11, 15, 43, 44), 359883534342, 435));
                phone.AddNewCall(new Call(DateTime.Now, 359888902112, 43));
                phone.AddNewCall(new Call(new DateTime(2012, 12, 10, 22, 11, 8), 359889921823, 115));

                Console.WriteLine("Calls dialed: ");
                foreach (Call call in phone.CallHistory)
                    Console.WriteLine(call.ToString());

                Console.WriteLine("Total price of the calls: " + phone.CalculateTotalPrice(0.37));

                phone.RemoveCall(phone.FindLongestCall());

                Console.WriteLine("Total price of the calls now: " + phone.CalculateTotalPrice(0.37));

                phone.CallHistory.Clear();

                Console.WriteLine("Printing the list again: \n");
                foreach (Call call in phone.CallHistory)
                    Console.WriteLine(call.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


