using CoffeeMachine.Domain.Entities;
using CoffeeMachine.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoffeeMachine.Application.Test.Infrastructure
{
    public class CoffeeMachineContextFactory
    {
        public static  CoffeeMachineDbContext Create()
        {
            var options = new DbContextOptionsBuilder<CoffeeMachineDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new CoffeeMachineDbContext(options);

            context.Database.EnsureCreated();

            context.DrinkType.AddRange(new[] {
                new DrinkType {  DrinkTypeId = 1, DrinkTypeName="Tea", Description="Fresh And Juicy Tea....." },
                 new DrinkType {  DrinkTypeId = 2, DrinkTypeName="Chocolate Tea", Description="Fresh Chocolate..." },
                  new DrinkType {  DrinkTypeId = 3, DrinkTypeName="Coffee", Description=" Yummy Coffeee with Good Taste" },
            });

           
            context.SaveChanges();

            return context;
        }

        public static void Destroy(CoffeeMachineDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}