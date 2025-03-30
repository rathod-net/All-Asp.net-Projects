public class GoldCustomer : Customer
{
    

    public GoldCustomer()
    {
        TicketAmmount = 350;
        hallNumber = 0;
    }
    
    public void PrintTicket()
    {
        Console.WriteLine("Gold Ticket Printed");
    }
    

}