using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrigeApi.DataLayer.Models
{
    public sealed class Products
    {
        public int ProductsId { get; set; }
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        public List<Fridge> Fridges { get; set; }
    }
}
