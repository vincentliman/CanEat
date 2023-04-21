using CanEatAPI.Output;


namespace CanEatAPI.Helper
{
    public class CompanyHelper
    {
        public CanEatDBContext dBContext;

        public CompanyHelper(CanEatDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Company> GetAllCompanies()
        {
            var returnValue = new List<Company>();

            try
            {
                var companies = dBContext.MsCompany.ToList();

                returnValue = companies.Select(company => new Company()
                {
                    id = company.id,
                    name = company.name,
                    address = company.address,
                    phone = company.phone,
                }).ToList();
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
