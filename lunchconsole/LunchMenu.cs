using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LunchMenu
{
    private List<MenuLine> _menus;

    public List<MenuLine> Menus
    {
        get { return _menus; }
        set { _menus = value; }
    }

    public LunchMenu()
    {
        Menus = new List<MenuLine>();
    }

    public LunchMenu(string filename)
    {
        try { 
            var menuData = File.ReadAllLines(filename)
                       .Skip(1)
                       .Select(x => x.Split(';'))
                       .Select(x => new MenuLine
                       {
                           WeekDay = x[0],
                           Menu = x[1],
                           Price = double.Parse(x[2])
                       });
            Menus = menuData.ToList();
        }
        catch(Exception e)
        {
            Menus = new List<MenuLine>();
        }
    }

    public string FindMenu(string weekDay)
    {
        var result = Menus.FirstOrDefault(m => m.WeekDay == weekDay);
        if (result == null)
        {
            return "no lunch served";
        }

        return result.Menu;
    }

}

