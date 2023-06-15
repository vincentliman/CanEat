using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanEatAPI.Models
{
    public class TrDetail
    {
        [Key]
        public Guid tr_id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid food_id { get; set; }
        public int qty { get; set;}
        public string notes { get; set;}
    
    }
}
