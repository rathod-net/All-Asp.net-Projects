
SilverCustomer S1 = new SilverCustomer();
S1.ShowTiming();
bool Status = S1.IsShowAvileble();
Console.WriteLine($" Is Show Avilabel{Status}");
int amc = S1.GetTicketAmmount();
Console.WriteLine($"Ticket Ammount = {amc}");
S1.PrintTicket();

GoldCustomer G1= new GoldCustomer();
G1.ShowTiming();
Status = G1.IsShowAvileble();
Console.WriteLine($" Is Show Avilabel{Status}");
amc = G1.GetTicketAmmount();
Console.WriteLine($"Ticket Ammount = {amc}");
G1.PrintTicket();



Console.ReadLine();