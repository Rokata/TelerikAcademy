using System;

class GSMTest
{
    static void Main()
    {
        try
        {
            GSM[] phones = new GSM[3];

            GSM.iPhone4S = new GSM("4S", "iPhone", 999.99, "Batman", new Battery("ZHDS384", 200, 8, BatteryType.LiIon),
               new Display(11, 160000000));

            phones[0] = new GSM("E51", "Nokia", 100.00, "John Johnson", new Battery("A1396", 300, 10, BatteryType.LiIon),
                new Display(10, 256000));
            phones[1] = new GSM("Windows Phone 8X", "HTC", 700.00);

            phones[1].Owner = "Jack";
            phones[1].Battery = new Battery("S38FS2", 250, 15, BatteryType.LiIon);
            phones[1].Display = new Display(8, 1600000);

            phones[2] = new GSM("i8750 Ativ S", "Samsung", 999.00, "Ivan Ivanov", new Battery("X38U32", 290, 11, BatteryType.NiMH),
                new Display(7, 200000));

            foreach (GSM phone in phones)
                Console.WriteLine(phone.ToString() + "\n********************");
            Console.WriteLine(GSM.iPhone4S.ToString());
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
