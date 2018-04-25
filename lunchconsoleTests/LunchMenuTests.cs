
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lunchconsole.Tests
{
    [TestFixture]
    public class LunchMenuTests
    {

        [Test]
        public void FindMenu_ShouldReturnNothing()
        {
            //setup
            var lunch = SetupSimpleMenu();
            var expected = "no lunch served";
            var actual = lunch.FindMenu("Tuesday");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMenu_ShouldReturnMeatballs()
        {
            //setup
            var lunch = SetupTwoMenus();
            var expected = "Meatballs";
            var actual = lunch.FindMenu("Tuesday");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LunchMenu_ShouldReadAndSaveMenuFile()
        {
            string menuFile = "C:/Omat/Koodaukset/Kraftvaerk/lunchconsole/lunches_test.csv";
            var lunch = new LunchMenu(menuFile);

            var expected = new MenuLine("Monday", "Spaghetti", 14.99);
            var actual = lunch.Menus.First();
            Assert.AreEqual(1, lunch.Menus.Count);

            Assert.AreEqual(expected.WeekDay, actual.WeekDay);
           

        }

        private LunchMenu SetupSimpleMenu()
        {
            var lunch = new LunchMenu
            {
                Menus = new List<MenuLine>() { new MenuLine("fooday", "spaghetti", 10.0) }
            };
            return lunch;
        }

        private LunchMenu SetupTwoMenus()
        {
            var lunch = new LunchMenu
            {
                Menus = new List<MenuLine>() { new MenuLine("fooday", "spaghetti", 10.0),
                    new MenuLine("Tuesday", "Meatballs", 10.0) }
            };
            return lunch;
        }
    }

    [TestFixture]
    public class MenuLineTests
    {
        [Test]
        public void MenuLine_ShouldCreateDefault()
        {
            var menuline = new MenuLine();
            string expWeekDay = "Monday";
            var actWeekDay = menuline.WeekDay;
            double expPrice = 10;
            var actPrice = menuline.Price;
            string expMenu = "Mac and cheese";
            var actMenu = menuline.Menu;

            Assert.AreEqual(expWeekDay, actWeekDay);
            Assert.AreEqual(expPrice, actPrice);
            Assert.AreEqual(expMenu, actMenu);
            
        }
    }
    
}