using PizzaPlanetConsole.DataAccess.DataModels;
using System;

namespace PizzaPlanetConsole.App.Classes
{
    public class InventoryClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void AddInventory(Users user)
        {
            try
            {
                while (true)
                {
                    var inventory = new Inventory();

                    Console.Write("Enter Store Id: ");
                    inventory.StoreId = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Enter Food Id: ");
                    inventory.FoodId = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Enter quanity: ");
                    inventory.Quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    ctx.Inventory.Add(inventory);
                    ctx.SaveChanges();
                    Console.WriteLine("Inventory added!");

                    Console.Write("Would you like to add another? (y/n)");
                    string again = Console.ReadLine();

                    if (again.ToLower() != "y")
                        break;
                }
                Navigation.PlaceOrder(user);
            }
            catch (Exception)
            {
                Console.Write("Something went wrong.");
                GeneralClass.PressEnter();
                Navigation.PlaceOrder(user);
            }
        }
    }
}
