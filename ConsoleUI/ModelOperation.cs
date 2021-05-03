using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    public class ModelOperation
    {
        int _brandId, _colorId, _modelYear;
        short _bodyTypeId, _fuelTypeId, _gearTypeId;
        string _modelName;

        ModelManager modelManager = new ModelManager(new EfModelDal());
        public void ListToModels()
        {
            var result = modelManager.GetAll();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-15}| {1,-45}|", "ID", "MODEL İSMİ"));
            Console.WriteLine("-----------------------------------------------------------------");

            Console.ResetColor();
            foreach (var model in result.Data)
            {
                Console.WriteLine(String.Format("| {0,-15}| {1,-45}|", model.Id, model.ModelName));
            }
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public int AddToModel()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(">>> Yukarıdaki Tabloları kullanarak YENİ ARAÇ EKLEME işlemini gerçekleştirebilirsiniz <<<");
            Console.ResetColor();

            Console.Write("Marka ID : ");
            _brandId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Model Adı : ");
            _modelName = Console.ReadLine();

            Console.Write("Model Yılı : ");
            _modelYear = Convert.ToInt32(Console.ReadLine());

            Console.Write("Renk ID : ");
            _colorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Kasa Tip ID : ");
            _bodyTypeId = short.Parse(Console.ReadLine());

            Console.Write("Yakıt Tip ID : ");
            _fuelTypeId = Convert.ToInt16(Console.ReadLine());

            Console.Write("Vites Tip ID : ");
            _gearTypeId = short.Parse(Console.ReadLine());

            Model model = new Model
            {
                BrandId = _brandId,
                ModelName = _modelName,
                ModelYear = _modelYear,
                ColorId = _colorId,
                BodyTypeId =_bodyTypeId,
                FuelTypeId = _fuelTypeId,
                GearTypeId = _gearTypeId
            };
           
            modelManager.Add(model);

            var result = modelManager.GetAll().Data.OrderByDescending(c => c.Id).FirstOrDefault();

            return result.Id;
        }

        public void UpdateToModel(int modelId)
        {
            Console.Write("Marka ID : ");
            _brandId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Model Adı : ");
            _modelName = Console.ReadLine();

            Console.Write("Model Yılı : ");
            _modelYear = Convert.ToInt32(Console.ReadLine());

            Console.Write("Renk ID : ");
            _colorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Kasa Tip ID : ");
            _bodyTypeId = short.Parse(Console.ReadLine());

            Console.Write("Yakıt Tip ID : ");
            _fuelTypeId = Convert.ToInt16(Console.ReadLine());

            Console.Write("Vites Tip ID : ");
            _gearTypeId = short.Parse(Console.ReadLine());

            Model updateModel = new Model
            {
                Id = modelId,
                BrandId = _brandId,
                ModelName = _modelName,
                ModelYear = _modelYear,
                ColorId = _colorId,
                BodyTypeId = _bodyTypeId,
                FuelTypeId = _fuelTypeId,
                GearTypeId = _gearTypeId
            };
        
            modelManager.Update(updateModel);            
        }

        public void DeleteToModel(int deleteModelId)
        {   
            Model deleteModel = new Model { Id = deleteModelId };

            modelManager.Delete(deleteModel);
            Console.WriteLine();

        }

    }
}
