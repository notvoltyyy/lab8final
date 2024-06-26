﻿using System;
using System.Collections.Generic;
using System.IO;

public class Composter
{
    static private int lastId = 0;

    private int id;
    protected string code;
    public List<Ticket> tickets = new List<Ticket>(1);
    //public Ticket ticket;

    public DateTime currentDateTime;
    public DateTime startDateTime;
    public DateTime lastDateTime;
    public int processedTicketCount;
    public List<int> processedTicketId = new List<int>();
    public int workedHours;
    private int Id
    {
        get { return id; }
        set { if (value > 0) { id = value; } }
    }
    protected string Code
    {
        get { return code; }
        set { code = value; }
    }

    static Composter()
    {
        lastId = 0;
    }
    public Composter()
    {
        id = MakeID();
        processedTicketCount = 0;
        workedHours = 0;
        //tickets.Add(new Ticket());
        code = "default";

    }

    public Composter(int Id, string Code, /*int ProcessedTicketCount,*/ int WorkedHours/*, int TicketCount*/) //redo
    {
        this.code = Code;
        this.id = Id;
        //this.processedTicketCount = ProcessedTicketCount;
        this.workedHours = WorkedHours;
    }

    public static int MakeID()
    {
        return ++lastId;
    }

    public static string GetTicketType(Ticket ticket)
    {
        if (ticket.Type == 1)
        {
            return "Single use ticket";
        }
        else if (ticket.Type == 2)
        {
            return "Multi use ticket";
        }
        else
        {
            return "Invalid ticket type";
        }
    }
    public void Check(Ticket ticket)
    {
        if (ticket.Id > 10000 && ticket.Id < 10100)
        {
            Console.WriteLine("Ticket is genuine.");
        }
        else
        {
            Console.WriteLine("Ticket is not genuine.");
        }
    }

    public void Validate()
    {
        Console.WriteLine("Hours worked: " + workedHours);
    }
    public void Validate(Ticket ticket)
    {
        Check(ticket);

        if (ticket.AvailableUses == 0)
        {
            Console.WriteLine("You have no available rides left.");
        }
        else if (ticket.AvailableUses >= 1)
        {
            ticket.AvailableUses--;
            ticket.IsValid = true;
            processedTicketCount++;
            processedTicketId.Add(ticket.Id);
            //ticket.code = this.code;
            Console.WriteLine("Your " + GetTicketType(ticket) + "has been validated, uses left: " + ticket.AvailableUses);
        }
    }

    public void Input()
    {
        Console.WriteLine("Input composter id: ");
        int.TryParse(Console.ReadLine(), out id);
        Console.WriteLine("Input code: ");
        code = Console.ReadLine();
        Console.WriteLine("Enter the number of tickets: ");
        int.TryParse(Console.ReadLine(), out int size);
        if (size > 0)
        {
            for (int i = 0; i < size; i++)
            {
                tickets[i].Buy();
            }
        }
    }

    public Composter LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Cannot find the file.");
            return null;
        }
        try
        {
            string[] strings = File.ReadAllLines(fileName);

            Composter newComposter = new Composter();
            newComposter.id = int.Parse(strings[0]);
            newComposter.code = strings[1];
            newComposter.processedTicketCount = int.Parse(strings[2]);

            //int i;
            //for(i = 0; i < newComposter.processedTicketCount; i++)
            //{
            //    newComposter.processedTicketId.Add(Convert.ToInt32(strings[3+i]));
            //}
            newComposter.workedHours = int.Parse(strings[3]);

            tickets[0].Id = int.Parse(strings[4]);
            //tickets[0].code = strings[5];
            tickets[0].Price = int.Parse(strings[5]);
            tickets[0].Type = int.Parse(strings[6]);
            tickets[0].AvailableUses = int.Parse(strings[7]);
            //bool.TryParse(strings[8], out tickets[0].IsValid);

            return newComposter;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading from file: {e.Message}");
            return null;
        }


    }

    public void SaveToFile(string fileName)
    {
        try
        {

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(id);
                writer.WriteLine(code);
                //writer.WriteLine(currentDateTime.ToShortDateString());
                //writer.WriteLine(startDateTime);
                //writer.WriteLine(lastDateTime);
                writer.WriteLine(processedTicketCount);

                //foreach(int num in processedTicketId)
                //{
                //    writer.WriteLine(num);
                //}

                writer.WriteLine(workedHours);

                //foreach (Ticket ticket in tickets)
                //{
                writer.WriteLine(tickets[0].Id);
                //writer.WriteLine(tickets[0].code);
                writer.WriteLine(tickets[0].Price);
                writer.WriteLine(tickets[0].Type);
                writer.WriteLine(tickets[0].AvailableUses);
                //writer.WriteLine(tickets[0].IsValid.ToString());
                //}

            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading from file: {e.Message}");
        }
    }

    public void BuyTicket()
    {
        Ticket newTicket = new Ticket();
        newTicket.Buy();
        tickets.Add(newTicket);
    }

    public override string ToString()
    {
        return "Id: " + id + ", code: " + code + ", processed ticket count: " + processedTicketCount + ", worked hours: " + workedHours;
    }
}