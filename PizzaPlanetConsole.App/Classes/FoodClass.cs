using Microsoft.EntityFrameworkCore;
using PizzaPlanetConsole.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPlanetConsole.App.Classes
{
    public class FoodClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void Order(Store store, Users user)
        {
            try
            {
                var cart = ShoppingCartClass.AddCart(user, store);

                while (true)
                {
                    Console.WriteLine($"Welcome to Pizza Planet on {store.Street} in {store.City}, {store.State}");

                    var groups = ctx.FoodGroup
                        .ToList();

                    Display.DisplayList(groups);

                    GeneralClass.WriteExit();

                    var foodList = UserPicksGroup();
                    int order = Display.DisplayList(foodList);

                    CartItemClass.AddItem(cart, order);

                    Console.Write("Would like to add another item? (y/n)");
                    string continued = Console.ReadLine();

                    if (continued.ToLower() == "n")
                        break;
                }

                decimal total = OrderClass.CalcTotal(cart.CartId);

                OrderClass.UserPays(total);
                OrderClass.AddOrder(total, cart.CartId);
                
                GeneralClass.PressEnter();
                Navigation.MainMenu(user);

            }
            catch (NullReferenceException)
            {
                Console.Write("Not a valid number.");
                GeneralClass.PressEnter();
                Navigation.PlaceOrder(user);
            }
        }

        public static List<Foods> UserPicksGroup()
        {
            int input = GeneralClass.UserPicks();
            GeneralClass.Exit(input);

            var foods = ctx.Foods
                .Include(g => g.FoodGroup)
                .Where(a => a.FoodGroup.FoodGroupId == input)
                .ToList();

            return foods;
        }

        public static void AddFood(Users user)
        {
            try
            {
                while (true)
                {
                    var newFood = new Foods();

                    Console.Write("Enter Food Group Id: ");
                    newFood.FoodGroupId = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Enter Food title: ");
                    newFood.FoodTitle = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Enter price: ");
                    newFood.Price = decimal.Parse(Console.ReadLine());

                    ctx.Foods.Add(newFood);
                    ctx.SaveChanges();
                    Console.WriteLine("Food added!");

                    Console.WriteLine("Add another food? (y/n)");
                    string again = Console.ReadLine();

                    if (again.ToLower() != "y")
                        break;
                }
                Navigation.MainMenu(user);
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