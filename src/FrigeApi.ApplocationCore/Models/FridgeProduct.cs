using FrigeApi.ApplocationCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrigeApi.ApplicationCore.Models
{
    public sealed class FridgeProduct 
    {
        public int FridgeId { get; set; }
        public Fridge Fridge { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
