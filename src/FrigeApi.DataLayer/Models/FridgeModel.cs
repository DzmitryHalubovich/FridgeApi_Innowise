using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrigeApi.DataLayer.Models
{
    public sealed class FridgeModel
    {
        public int FridgeModelId { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
    }
}
