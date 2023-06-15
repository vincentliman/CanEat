namespace CanEatAPI.Input
{
    public class CreateCartInput
    {
        public string? customer_name { get; set; }
        public string? food_name { get; set; }
        public int? qty { get; set; }
        public string? notes { get; set; }
    }
}
