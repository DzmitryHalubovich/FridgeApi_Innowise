using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrigeApi.ApplocationCore.Models
{
    public sealed class FridgeModel : BaseModel
    {
        public string Name { get; set; }
        public int? Year { get; set; }
    }
}
