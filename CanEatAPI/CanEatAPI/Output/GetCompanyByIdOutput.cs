namespace CanEatAPI.Output
{
    public class GetCompanyByIdOutput
    {
        public CompanyDataById? payload { get; set; }
        public GetCompanyByIdOutput()
        {
            payload = new CompanyDataById();
        }
    }

    public class CompanyDataById
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}
