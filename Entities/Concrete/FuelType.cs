using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FuelType : IEntity
    {
        public short Id { get; set; }
        public string FuelTypeName { get; set; }
    }
}
