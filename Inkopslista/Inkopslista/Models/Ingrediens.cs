using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inkopslista.Models
{
    public class Ingredient
    {
        public virtual Guid Id { get; set; }
        public virtual String Name { get; set; }
    }
}