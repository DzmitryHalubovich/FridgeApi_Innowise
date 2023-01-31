using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrigeApi.DataLayer.Models
{
    public sealed class Fridge
    {
        public int FriedgeId { get; set; }
        public string Name { get; set; }
        public string? OwnerName { get; set; }

        public FridgeModel FridgeModel { get; set; }

        public int FridgeModelId { get; set; }

        public List<Products> Products { get; set; }
    }
}
