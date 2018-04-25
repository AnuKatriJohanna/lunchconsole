public class MenuLine
{
    private string _weekDay;

    public string WeekDay
    {
        get { return _weekDay; }
        set { _weekDay = value; }
    }
    private string _menu;

    public string Menu
    {
        get { return _menu; }
        set { _menu = value; }
    }

    private double _price;

    public double Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public MenuLine()
    {
        WeekDay = "Monday";
        Menu = "Mac and cheese";
        Price = 10;
    }

    public MenuLine(string weekDay, string menu, double price)
    {
        WeekDay = weekDay;
        Menu = menu;
        Price = price;
    }

}

