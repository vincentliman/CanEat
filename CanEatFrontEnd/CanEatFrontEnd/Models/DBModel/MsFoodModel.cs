using System.ComponentModel.DataAnnotations;

namespace CanEatFrontEnd.Models.DBModel
{
    public class MsFoodModel
    {
        [Key]
        public Guid id { get; set; }
        public Guid shop_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string photo { get; set; }
        public string description { get; set; }


    }
}
