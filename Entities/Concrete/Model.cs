using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
        public int ColorId { get; set; }
        public short BodyTypeId { get; set; }
        public short FuelTypeId { get; set; }
        public short GearTypeId { get; set; }
    }
}
