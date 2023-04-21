namespace CanEatAPI.Output
{
    public class CompanyOutput
    {
        public List<Company> payload {  get; set; }
        public CompanyOutput()
        {
            payload = new List<Company>();
        }
    }

    public class Company 
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}
