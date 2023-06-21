using System.ComponentModel.DataAnnotations;

namespace CanEatFrontEnd.Models.DBModel
{
    public class MsCartModel
    {   
        public string customer_id { get; set; }
        public string food_id { get; set; }
        public int qty { get; set; }
        public string notes { get; set; }

    }
}
