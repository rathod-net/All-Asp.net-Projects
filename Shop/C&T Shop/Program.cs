Console.WriteLine("***** Welcome to Kapbhar Chaha *****");
string repeat = "";
int cuttingQuantity = 0, fullCupQuantity = 0, coffeeQuantity = 0;
do
{
    Console.WriteLine("What would you like to have today?");
    Console.WriteLine($"Menu: \n" +
        $"1 - CUTTING 7 Rs\n2 - FULL CUP 10 Rs\n3 - COFFEE 20 Rs");

    int order = Convert.ToInt32(Console.ReadLine());

    //Console.WriteLine("How much?");
    //int quantity = Convert.ToInt32(Console.ReadLine());

    switch (order)
    {
        case 1:
            Console.WriteLine("How much?");
            cuttingQuantity += Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You ordered : {cuttingQuantity} CUTTING CHAHA");
            break;
        case 2:
            Console.WriteLine("How much?");
            fullCupQuantity += Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You ordered : {fullCupQuantity} FULL CHAHA");
            break;
        case 3:
            Console.WriteLine("How much?");
            coffeeQuantity += Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You ordered : {coffeeQuantity} COFFEE");
            break;
        default:
            Console.WriteLine("INVALID ORDER");
            Console.WriteLine("Please Do correct order?");
            break;
    }

    Console.WriteLine("Do you want to repeat any order?");
    repeat = Console.ReadLine().ToUpper();
} while (repeat == "Y" || repeat == "YES");

if (cuttingQuantity > 0 || fullCupQuantity > 0 || coffeeQuantity > 0)
{
    Console.WriteLine("----------- BILL RECEIPT ----------------");

    if (cuttingQuantity > 0)
    {
        Console.WriteLine($"CUTTING TEA : {cuttingQuantity} * 7 = " +
            $"{cuttingQuantity * 7} /-");
    }
    if (fullCupQuantity > 0)
    {
        Console.WriteLine($"FULL CUP TEA : {fullCupQuantity} * 10 = " +
            $"{fullCupQuantity * 10} /-");
    }
    if (coffeeQuantity > 0)
    {
        Console.WriteLine($"COFFEE : {coffeeQuantity} * 20 = " +
            $"{coffeeQuantity * 20} /-");
    }

    Console.WriteLine($"TOTAL BILL = " +
            $"{(cuttingQuantity * 7) + (fullCupQuantity * 10) + (coffeeQuantity * 20)} /-");

    Console.WriteLine("------------- THANK YOU. VISIT AGAIN :) -------------");
}

Console.ReadLine();