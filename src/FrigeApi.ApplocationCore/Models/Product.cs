using FrigeApi.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrigeApi.ApplocationCore.Models
{
    //[Table("products")]
    public sealed class Product : BaseModel
    {
        //[Column("name")]
        public string Name { get; set; }
       //[Column("default_quantity")]
        public int? DefaultQuantity { get; set; }
        public List<Fridge> Fridges { get; set; }

        public List<FridgeProduct> FridgeProducts { get; set; }
    }
}
