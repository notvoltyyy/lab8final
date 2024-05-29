using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ticket  //make private fields, check constructors
{
    protected string code = "default";

    public int id;
    public int price; //{ get { return price; } set { if (value > 0) { price = value; } } }
    public int type; //{ get { return type; } set { if (value == 1 || value == 2) { type = value; } } }        //1 - single use, 2 - multi use, maybe use bool
    public int availableUses; //{ get { return availableUses; } set { if (value >= 0) { availableUses = value; } } }
    public bool isValid;

    protected string Code
    {
        get { return code; }
        set { code = value; }
    }
    public Ticket()
    {
        Random rng = new Random();
        price = 10;
        type = 1;
        isValid = false;
        availableUses = 1;
        id = 10000 + rng.Next(1, 100);
    }

    public Ticket(int type)
    {

        isValid = false;

        if (type == 1)
        {
            availableUses = 1;
            price = 10;
        }
        else if (type == 2)
        {
            availableUses = 5;
            price = 50;

        }
        else
        {
            Console.WriteLine("Invalid ticket type."); //not sure if it is suitable 
        }
        this.type = type;
        isValid = false;
        Random rng = new Random();
        id = 10000 + rng.Next(1, 100);
    }
    public Ticket(int price, int type, bool isValid, int availbleUses)
    {

        this.price = price;
        this.type = type;
        this.isValid = isValid;
        this.availableUses = availbleUses;

    }

    public void Buy()
    {
        Console.WriteLine("Input type (1 - Single Use (10 Uah), 2 - Multiuse(5 uses, 50 uah): ");
        type = Convert.ToInt32(Console.ReadLine());
    }

    public void Input()
    {
        Console.WriteLine("Input id: ");
        id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input price: ");
        price = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input type(1/2): ");
        type = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input available uses: ");
        availableUses = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input validation state");
        isValid = Convert.ToBoolean(Console.ReadLine()); //?
        Console.WriteLine("Input code: ");
        code = Console.ReadLine();
    }

    public override string ToString()
    {
        return "Id: " + id + ", type: " + type + ", price: " + price + ", available uses: " + availableUses + ", is valid: " + isValid.ToString();
    }
}