using Karlo_FirstProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karlo_FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcertsManagementsService concertsManagementsService = new ConcertsManagementsService();



            Console.WriteLine("Concert halls: GCH - get all concert halls, ACH - add concert hall, DCH - delete concert hall");

            Console.WriteLine("Concerts: GC - get concerts, AC - add concert, DC - delete concert, CD - search by concert date");

            Console.WriteLine("Tickets: GT - get tickets, AT - add ticket, DT - delete ticket");

            Console.WriteLine("Drinks: GD - get drinks, AD - add drinks, DD - delete drinks");

            Console.WriteLine("To exit an app: E");

            while (true)
            {
                string command = Console.ReadLine();


                if (command == "GCH")
                {
                    string concertHalls = concertsManagementsService.GetAllConcertHalls();
                    if (concertHalls == "")
                        Console.WriteLine("There is no concert halls in DB. Input ACH to add new concert hall in db");
                    else
                        Console.Write(concertHalls);
                };

                if (command == "ACH")
                {
                    Console.WriteLine("Add hall name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Add capacity: ");
                    string capacity = Console.ReadLine();

                    string result = concertsManagementsService.AddConcertHall(name, Convert.ToInt32(capacity));
                    if (result == "")
                        Console.WriteLine("Concert hall is added");
                    else
                        Console.WriteLine(result);
                }

                if (command == "DCH")
                {
                    Console.WriteLine("Name of hall you want to delete:");
                    string name = Console.ReadLine();
                    bool result = concertsManagementsService.DeleteConcertHall(name);

                    if (result == true)
                        Console.WriteLine($"Concert hall '{name}' is deleted");
                    else
                        Console.WriteLine($"Sn error occured. Concert hall '{name}' is not deleted");

                }

                if (command == "GT")
                {
                    string tickets = concertsManagementsService.GetAllTickets();
                    if (tickets == "")
                        Console.WriteLine("There is no tickets in DB");
                    else
                        Console.Write(tickets);
                }


                if (command == "AT")
                {
                    Console.WriteLine("Name of the concert");
                    string name = Console.ReadLine();
                    string result = concertsManagementsService.AddSoldTicket(name);

                    if (result == string.Empty)
                        Console.WriteLine("Ticket is added");
                    else
                        Console.WriteLine(result);
                }
                if (command == "AC")
                {
                    Console.WriteLine("Name of the concert");
                    string name = Console.ReadLine();
                    Console.WriteLine("Name of the performer");
                    string performername = Console.ReadLine();
                    Console.WriteLine("Name of the hall");
                    string hallname = Console.ReadLine();
                    Console.WriteLine("Input date in format DD/MM/YYYY");
                    string starttime = Console.ReadLine();

                   string result = concertsManagementsService.AddConcert(name, performername, hallname, starttime);
                    if (result == string.Empty)
                        Console.WriteLine($"{name} is added");
                    else Console.WriteLine(result);
                }
                if (command == "GC")
                {
                    string concerts = concertsManagementsService.GetAllConcerts();
                    if (concerts == "")
                        Console.WriteLine("There is no concerts in DB. Input AC to add new concert in DB");
                    else
                        Console.Write(concerts);
                }
                if (command == "DC")
                {
                    Console.WriteLine("Name of concert you want to delete:");
                    string name = Console.ReadLine();
                    string performer = Console.ReadLine();
                    string concertHallName = Console.ReadLine();
                    bool result = concertsManagementsService.DeleteConcert(name, performer, concertHallName);

                    if (result == true)
                        Console.WriteLine($"Concert '{name}' is deleted");
                    else
                        Console.WriteLine($"An error occured. Concert '{name}' is not deleted");

                }
                if (command == "CD")
                {
                    Console.WriteLine("Input date in format DD/MM/YYYY");
                    string inputDate = Console.ReadLine();
                    string concerts = concertsManagementsService.GetConcertsAtDate(inputDate);
                    if (concerts == string.Empty)
                        Console.WriteLine("There are no concerts on this date");
                    else 
                        Console.WriteLine($"Concerts on {inputDate}:\n{concerts}");

                }
                if (command == "AD")
                {
                    Console.WriteLine("Name of concert");
                    string name = Console.ReadLine();
                    string result = concertsManagementsService.AddSoldDrink(name);

                    if (result == string.Empty)
                        Console.WriteLine("Drink is added");
                    else
                        Console.WriteLine(result);
                }
                if (command == "GD")
                {
                    string drinks = concertsManagementsService.GetAllDrinks();
                    if (drinks == "")
                        Console.WriteLine("There is no drinks in DB");
                    else
                        Console.Write(drinks);
                }
                if (command == "DT")
                {
                    Console.WriteLine("Name of the concert");
                    string name = Console.ReadLine();
                    Console.WriteLine("Ticket number");
                    int ticketNo = Convert.ToInt32(Console.ReadLine());
                    bool result = concertsManagementsService.DeleteTicket(name, ticketNo);

                    if (result == true)
                        Console.WriteLine($"Ticket '{ticketNo}' is deleted");
                    else 
                        Console.WriteLine($"An error occured. Ticket '{ticketNo}' is not deleted");
                }
                        



                    


                if (command == "E")
                    break;
            }



            Console.ReadKey(true);

        }
    }
}
