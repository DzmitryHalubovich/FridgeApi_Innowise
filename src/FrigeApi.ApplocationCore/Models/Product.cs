using FrigeApi.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FrigeApi.ApplocationCore.Models
{
    public sealed class Product : BaseModel
    {
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        [JsonIgnore]
        public List<Fridge> Fridges { get; set; }
        [JsonIgnore]
        public List<FridgeProduct> FridgeProducts { get; set; }
    }
}
