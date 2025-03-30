using System.Collections;
using System.ComponentModel.Design;

Console.WriteLine(".......Welcome To Hemansh Coffee Shop.......\n");
string repet = "";
int LatteCoffee = 0, ColdCoffee = 0, HotCoffee = 0;
do
{
    Console.WriteLine("Menu:\n" + "1 - LatteCoffee Rs.100\n2 - ColdCoffee Rs. 80\n3 - HotCoffee Rs.60");
    int order = Convert.ToInt32(Console.ReadLine());
    switch (order)
    {
        case 1:
            Console.WriteLine("How Much");
            LatteCoffee += Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You Have orderd: {LatteCoffee} Lattecoffee");
            break;
        case 2:
            Console.WriteLine("How Much");
            ColdCoffee += Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You Have orderd: {ColdCoffee} ColdCoffee");
            break;
        case 3:
            Console.WriteLine("How Much");
            HotCoffee += Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You Have orderd: {HotCoffee} HotCoffee");
            break;
        default:
            Console.WriteLine("Invalid Order Please Do Correct Order");
            break;

    }
    Console.WriteLine("Do You Want Repet Order?\n Write Yes For Comfirm");
   repet = Console.ReadLine().ToUpper();
} while (repet == "YES" || repet == "Y");


if (LatteCoffee>0 || ColdCoffee>0 || HotCoffee>0)
{
    Console.WriteLine("............Your Bill.............");
    if(LatteCoffee>0)
    {
        Console.WriteLine($"LatteCoffee : {LatteCoffee} *100 = " + $"{LatteCoffee * 100} /-");
       
    }
     if (ColdCoffee > 0)
    {
        Console.WriteLine($"ColdCoffee : {ColdCoffee} *80 = " + $"{ColdCoffee * 80} /-");

    }
    if (HotCoffee > 0)
    {
        Console.WriteLine($"HotCoffee : {HotCoffee} *60 = " + $"{HotCoffee * 60} /-");

    }

    Console.WriteLine($"TOTAL BILL = " +
            $"{(LatteCoffee * 100) + (ColdCoffee * 80) + (HotCoffee * 60)} /-");

    Console.WriteLine("------------- THANK YOU. VISIT AGAIN :) -------------");
}
