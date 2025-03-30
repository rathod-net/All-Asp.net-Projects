public class SilverCustomer : Customer
{

    public SilverCustomer()
    {
        TicketAmmount = 200;
        hallNumber = 1;
    }
  
    public void PrintTicket()
    {
        Console.WriteLine("Sliver Ticket Printed");
    }
    
}