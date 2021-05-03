using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BodyType:IEntity
    {
        public short Id { get; set; }
        public string BodyTypeName { get; set; }
    }
}
