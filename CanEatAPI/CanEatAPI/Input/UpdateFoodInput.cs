namespace CanEatAPI.Input
{
    public class UpdateFoodInput
    {
        public Guid? id { get; set; }
        public string? shop_id { get; set; }
        public string? name { get; set; }
        public int? price { get; set; }
        public string? photo { get; set; }
        public string? description { get; set; }
    }
}
