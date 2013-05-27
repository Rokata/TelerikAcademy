using System;

class CompanyInformationRead
{
    static void Main()
    {
        Console.Write("Company name: ");
        string company = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Phone number: ");
        string phone = Console.ReadLine();

        Console.Write("Website: ");
        string website = Console.ReadLine();

        Console.Write("Manager's first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Manager's last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Manager's phone number: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine("\nCompany name: {0} \nAddress: {1} \nCompany phone number: {2} \nWebsite: {3} \n" +
        "Manager first name: {4}\nManager last name: {5}\nManager phone: {6}", company, address, phone, website,
        managerFirstName, managerLastName, managerPhone);
    }
}
