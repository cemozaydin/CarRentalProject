using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public string BodyTypeName { get; set; }
        public string GearTypeName { get; set; }
        public string FuelTypeName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
