using FrigeApi.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FrigeApi.ApplocationCore.Models
{
    public sealed class Fridge : BaseModel
    {
        [Required(ErrorMessage ="Name is required!")]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? OwnerName { get; set; }
        [Required()]
        public int FridgeModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }
        [JsonIgnore]
        public List<Product>? Products { get; set; }
        [JsonIgnore]
        public List<FridgeProduct> FridgeProducts { get; set; }
    }
}
