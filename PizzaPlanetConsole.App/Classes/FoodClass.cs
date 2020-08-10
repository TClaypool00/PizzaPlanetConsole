using Microsoft.EntityFrameworkCore;
using PizzaPlanetConsole2.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPlanetConsole.App.Classes
{
    public class FoodClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static List<int> OrderList { get; set; } = new List<int>();

        public static List<decimal> PriceList { get; set; } = new List<decimal>();

        public static void Order(Stores store, Users user)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine($"Welcome to Pizza Planet on {store.Street} in {store.City}, {store.State}");

                    var groups = ctx.FoodGroup
                        .ToList();

                    foreach (var item in groups)
                    {
                        Console.WriteLine($"{item.FoodGroupId}. {item.FoodGroups}");
                    }

                    Console.WriteLine("0. Exit");

                    var foodList = UserPicksGroup();
                    int order = GeneralClass.DisplayList(foodList);
                    decimal price = GetPrice(order);

                    PriceList.Add(price);
                    OrderList.Add(order);
                    Console.Write("Would like to add anotehr item? (y/n)");
                    string contenue = Console.ReadLine();

                    if (contenue.ToLower() == "y")
                        Order(store, user);
                    else
                    {
                        break;
                    }
                }

                decimal total = GetTotalPrice();
                string items = GeneralClass.ListToString(OrderList);
                OrderClass.AddToOrder(items, user, store, total);
                Console.WriteLine("Your order has been placed!");
                Navigation.MainMenu(user);

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Not a valid number.");
                GeneralClass.PressEnter();
                Navigation.MainMenu(user);
            }
        }

        public static List<Foods> UserPicksGroup()
        {
            int input = GeneralClass.UserPicks();
            Navigation.Exit(input);

            var foods = ctx.Foods
                .Include(g => g.FoodGroup)
                .Where(a => a.FoodGroup.FoodGroupId == input)
                .ToList();

            return foods;
        }

        public static decimal GetPrice(int id)
        {
            var food = ctx.Foods
                .FirstOrDefault(f => f.FoodId == id);

            return food.Price;
        }

        public static decimal GetTotalPrice()
        {
            return PriceList.Sum(x => Convert.ToDecimal(x));
        }

        public static List<int> CoventStringToList(string orders)
        {
            return orders.Split(" ").Select(int.Parse).ToList();
        }

        
    }
}
