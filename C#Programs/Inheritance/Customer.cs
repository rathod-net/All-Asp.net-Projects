public class Customer
{

    public int TicketAmmount;
    public int hallNumber;


    public void ShowTiming()
    {
        Console.WriteLine("*** All Todays Shows ***");
    }

    public bool IsShowAvileble()
    {
        return true;
    }

    public int GetTicketAmmount()
    {
        return TicketAmmount;
    }

}

   
