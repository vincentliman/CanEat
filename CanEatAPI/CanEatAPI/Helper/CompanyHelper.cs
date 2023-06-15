using CanEatAPI.Input;
using CanEatAPI.Models;
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

        public StatusOutput DeleteCompany(string id)
        {
            var returnValue = new StatusOutput();

            try
            {
                Guid companyId = Guid.Parse(id);
                var company = dBContext.MsCompany.ToList().FirstOrDefault(x => companyId == x.id);
                if (company == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "company not found";
                    return returnValue;
                }

                dBContext.MsCompany.Remove(company);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "company deleted";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Company> GetAllCompanies()
        {
            var returnValue = new List<Company>();

            try
            {
                var companies = dBContext.MsCompany.ToList();

                returnValue = companies.Select(company => new Company()
                {
                    id = company.id.ToString(),
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


        public StatusOutput UpdateCompany(UpdateCompanyInput data)
        {
            var returnValue = new StatusOutput();

            try
            {
                var company = dBContext.MsCompany.Where(x => x.id == data.id).FirstOrDefault();

                if (company == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "company not found";
                    return returnValue;
                }

                if (data.name != null)
                {
                    company.name = data.name;
                }

                if (data.address != null)
                {
                    company.address = data.address;
                }

                if (data.phone != null)
                {
                    company.phone = data.phone;
                }


                dBContext.MsCompany.Update(company);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "company updated";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CompanyDataById? GetCompanyData(string id)
        {
            var returnValue = new CompanyDataById();
            try
            {
                Guid companyId = Guid.Parse(id);
                var companyData = dBContext.MsCompany.ToList().FirstOrDefault(x => companyId == x.id);
                if (companyData != null)
                {
                    //var companyData = dBContext.MsCompany.Where(x => x.id == customerData.company_id).FirstOrDefault();
                    //var religionData = dBContext.MsReligion.Where(x => x.id == studentData.religionId).FirstOrDefault();

                    //returnValue.student = student;
                    returnValue.name = companyData.name;
                    returnValue.address = companyData.address;
                    returnValue.phone = companyData.phone;


                    return returnValue;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public StatusOutput CreateCompany(CreateCompanyInput? data)
        {
            var returnValue = new StatusOutput();

            try
            {
                if (data != null)
                {

/*                    if (data.id == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "id cannot be empty";
                        return returnValue;
                    }*/

                    if (data.name == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "name cannot be empty";
                        return returnValue;
                    }

                    if (data.address == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "address cannot be empty";
                        return returnValue;
                    }

                    if (data.phone == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "phone cannot be empty";
                        return returnValue;
                    }


                    var company = new MsCompany
                    {
                        id = Guid.NewGuid(),
                        name = data.name,
                        address = data.address,
                        phone = data.phone,
                    };

                    dBContext.MsCompany.Add(company);
                    dBContext.SaveChanges();

                    returnValue.statusCode = 201;
                    returnValue.message = "company created";
                    return returnValue;
                }
                else
                {
                    returnValue.statusCode = 204;
                    returnValue.message = "data cannot be empty";
                    return returnValue;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
