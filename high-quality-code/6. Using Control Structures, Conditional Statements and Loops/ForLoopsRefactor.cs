bool isExpectedValue = false;

for (int i = 0; i < 100; i++) 
{
   Console.WriteLine(array[i]);
	
   if (i % 10 == 0 && array[i] == expectedValue)
   {
	 isExpectedValue = true;
   	 break;
   }
}
// More code here
if (isExpectedValue)
{
    Console.WriteLine("Value Found");
}
