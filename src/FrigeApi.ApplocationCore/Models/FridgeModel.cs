using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrigeApi.ApplocationCore.Models
{
    //[Table("fridge_model")]
    public sealed class FridgeModel : BaseModel
    {
        //[Column("name")]
        public string Name { get; set; }
        //[Column("year")]
        public int? Year { get; set; }
    }
}
