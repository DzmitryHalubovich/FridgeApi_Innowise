using FrigeApi.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrigeApi.ApplocationCore.Models
{
    //[Table("fridge")]
    public sealed class Fridge : BaseModel
    {
        //[Column("name")]
        public string Name { get; set; }
        //[Column("owner_name")]
        public string? OwnerName { get; set; }

        //[Column("model_id")]
        public int FridgeModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }

        public List<Product>? Products { get; set; }

        public List<FridgeProduct> FridgeProducts { get; set; }
    }
}
