using System;
using System.Text;

class GSM
{
    private string model;
    private string manufacturer;
    private double price;
    private string owner;
    private Battery battery;
    private Display display;
    public static GSM iPhone4S;

    public static GSM IPhone4S
    {
        get
        {
            return iPhone4S;
        }
        set
        {
            if (value == null) throw new ArgumentException("This property should not be null!");
            iPhone4S = value;
        }
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid model name!");
            this.model = value;
        }
    }

    public string Manufacturer
    {
        get
        {
            return this.manufacturer;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid manufacturer name!");
            this.manufacturer = value;
        }
    }

    public double Price
    {
        get
        {
            return this.price;
        }
        set
        {
            this.price = value;
        }
    }

    public string Owner
    {
        get
        {
            return this.owner;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid owner name!");
            this.owner = value;
        }
    }

    public Battery Battery
    {
        get
        {
            return this.battery;
        }
        set
        {
            if (value == null) throw new ArgumentException("Battery information should not be set to null!");
            this.battery = value;
        }
    }

    public Display Display
    {
        get
        {
            return this.display;
        }
        set
        {
            if (value == null) throw new ArgumentException("Display information should not be set to null!");
            this.display = value;
        }
    }

    public GSM(string model, string manufacturer, double price, string owner, Battery battery, Display display)
    {
        this.model = model;
        this.manufacturer = manufacturer;
        this.price = price;
        this.owner = owner;
        this.battery = battery;
        this.display = display;
    }

    public GSM(string model, string manufacturer, double price)
    {
        this.model = model;
        this.manufacturer = manufacturer;
        this.price = price;
        this.owner = null;
        this.battery = null;
        this.display = null;
    }

    public GSM(string model, string manufacturer, double price, string owner)
    {
        this.model = model;
        this.manufacturer = manufacturer;
        this.price = price;
        this.owner = owner;
        this.battery = null;
        this.display = null;
    }

    public override string ToString()
    {
        return string.Format("Model: {0}\nManufacturer: {1}\nPrice: {2}\nOwner: {3}\n\n--- Battery info --- \n{4}\n" +
            "--- Display info ---\n{5}\n"
            , model, manufacturer, price, owner, battery.ToString(), display.ToString());
    }
}
