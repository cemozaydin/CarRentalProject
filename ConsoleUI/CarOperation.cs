using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleUI
{
    public class CarOperation
    {
        CarManager carManager = new CarManager(new EfCarDal());
        public void ListToCarsByColorId()
        {
            Console.Write("Listelemek istediğiniz Renk ID : ");
            int listColorId = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", "CAR ID", "BRAND NAME", "MODEL NAME", "COLOR NAME", "MODEL YEAR", "BODY TYPE", "FEUL", "GEAR", "DAILY PRICE", "DESCRIPTION"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
            foreach (var car in carManager.GetCarDetailsByColorId(listColorId).Data)
            {
                Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", car.CarId, car.BrandName, car.ModelName, car.ColorName, car.ModelYear, car.BodyTypeName, car.FuelTypeName, car.GearTypeName, car.DailyPrice, car.Description));
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void ListToCarsByBrandId()
        {
            Console.Write("Listelemek istediğiniz Marka ID : ");
            int listBrandId = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", "CAR ID", "BRAND NAME", "MODEL NAME", "COLOR NAME", "MODEL YEAR", "BODY TYPE", "FEUL", "GEAR", "DAILY PRICE", "DESCRIPTION"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
            foreach (var car in carManager.GetCarDetailsByBrandId(listBrandId).Data)
            {
                Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", car.CarId, car.BrandName, car.ModelName, car.ColorName, car.ModelYear, car.BodyTypeName, car.FuelTypeName, car.GearTypeName, car.DailyPrice, car.Description));
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public int DeleteToCar()
        {
            ListToCars();

            int _deleteId, _deleteModelId;
            Console.WriteLine();

            Console.Write("Silmek istediğiniz Kayıt ID : ");
            _deleteId = Convert.ToInt32(Console.ReadLine());

            _deleteModelId = carManager.GetAll().Data.Where(c => c.Id == _deleteId).Select(m => m.CarModelId).First();

            Car deleteCar = new Car { Id = _deleteId };

            carManager.Delete(deleteCar);
            Console.WriteLine();

            return _deleteModelId;
        }

        public void AddToCar(int modelId)
        {            
            int _modelId;
            decimal _dailyPrice;
            string _description;

            _modelId = modelId;           
            Console.Write("Günlük Fiyat : ");
            _dailyPrice = Convert.ToDecimal(Console.ReadLine());           
            Console.Write("Açıklama : ");
            _description = Console.ReadLine();
            Console.WriteLine();


            Car car = new Car()
            {               
                CarModelId= _modelId,
                DailyPrice = _dailyPrice,
                Description = _description
            };

            var result = carManager.Add(car);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(result.Message);
            Console.ResetColor();
            Console.WriteLine();
            //ListToCars(carManager);
        }

        public void ListToCars()
        {
            var result = carManager.GetCarDetails();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", "CAR ID", "BRAND NAME", "MODEL NAME", "COLOR NAME", "MODEL YEAR", "BODY TYPE", "FEUL", "GEAR", "DAILY PRICE", "DESCRIPTION"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var car in result.Data)
            {
                Console.WriteLine(String.Format("| {0,-8}| {1,-15}| {2,-40}| {3,-10}| {4,-15}| {5,-18}| {6,-15}| {7,-15}| {8,-15}| {9,-30}|", car.CarId, car.BrandName, car.ModelName, car.ColorName, car.ModelYear, car.BodyTypeName, car.FuelTypeName, car.GearTypeName, car.DailyPrice, car.Description));
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public int UpdateToCar()
        {
            int _updateCarId; 
            int _modelId;            
            decimal _dailyPrice;
            string _description;

            ListToCars();
            Console.WriteLine();

            Console.Write("Güncellemek istediğiniz Kayıt ID : ");
            _updateCarId = Convert.ToInt32(Console.ReadLine());
          
            Console.Write("Günlük Fiyat : ");
            _dailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Açıklama : ");
            _description = Console.ReadLine();
                       
            Console.WriteLine();

            _modelId = carManager.GetAll().Data.Where(c => c.Id == _updateCarId).Select(m => m.CarModelId).First();

            Car updateCar = new Car
            {
                Id = _updateCarId,
                CarModelId = _modelId,              
                DailyPrice = _dailyPrice,
                Description = _description
            };

            carManager.Update(updateCar);
            
            //_modelId = carManager.GetAll().Data.Where(c => c.Id == _updateCarId).Select(m=>m.CarModelId).First();

            return _modelId;
        }
    }
}
