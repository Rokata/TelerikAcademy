using System;

class Declarations
{
    static void Main()
    {
        // Choosing appropriate types (ex. 1) 
        sbyte a = -115;
        int b = 4825932;
        ushort c = 52130;
        byte d = 97;
        short e = -10000;

        // Hexademical declaration of 254 (ex. 4)
        int hex = 0xFE;

        // Character variable with hexaedmical representation (ex. 5)
        char ch = '\x48';

        // Gender bool (ex. 6)
        bool isFemale = false;

        // Strings and object (ex. 7)
        string str1 = "Hello";
        string str2 = "World";
        object helloWorld = str1 + " " + str2;
        string str3 = (string)helloWorld;

        // String with quatations (ex. 8)
        string firstWay = "The \"use\" of quotations causes difficulties.";
        string secondWay = @"The ""use"" of quotations causes difficulties.";

        // Employees info in marketing firm (ex. 10)
        string firstName;
        string lastName;
        byte age;
        char gender;
        int IDNumber;
        int uniqueEmpNumber;

        // Exchanging values (ex. 11)
        int first = 5, second = 10;
        int temp = first;
        first = second;
        second = temp;

        // Bank account information variables (ex. 14)
        string FirstName, MiddleName, LastName, BankName;
        string IBAN;
        string BIC_Code;
        float Balance;
        long CreditCardOne, CreditCardTwo, CreditCardThree;
    }
}
