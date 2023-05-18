namespace CanEatAPI.Input
{
    public class UpdateCompanyInput
    {
        public Guid? id { get; set; }
        public string? name { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
    }
}
