namespace CanEatAPI.Input
{
    public class UpdateShopInput
    {
        public Guid? id { get; set; }
        public string? company_name { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? phone { get; set; }
        public Boolean? status { get; set; }
    }
}
