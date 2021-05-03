using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class GearTypeOperation
    {
        GearTypeManager gearTypeManager = new GearTypeManager(new EfGearTypeDal());

        public void ListToGearTypes()
        {
            var result = gearTypeManager.GetAll();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-15}| {1,-45}|", "ID", "VİTES TİPİ"));
            Console.WriteLine("-----------------------------------------------------------------");

            Console.ResetColor();
            foreach (var gearType in result.Data)
            {
                Console.WriteLine(String.Format("| {0,-15}| {1,-45}|", gearType.Id, gearType.GearTypeName));
            }
            Console.WriteLine("-----------------------------------------------------------------");

        }

    }
}
