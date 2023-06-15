namespace CanEatAPI.Input
{
    public class UpdateTrDetailInput
    {
        public Guid? tr_id { get; set; }
        public string? food_name { get; set;}
        public int? qty { get; set;}
        public string? notes { get; set; }
    }
}
