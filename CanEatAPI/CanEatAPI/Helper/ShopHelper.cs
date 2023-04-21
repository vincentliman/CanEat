using CanEatAPI.Input;
using CanEatAPI.Output;
using CanEatAPI.Models;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CanEatAPI.Helper
{
    public class ShopHelper
    {
        public CanEatDBContext dBContext;

        public ShopHelper(CanEatDBContext dBContext) 
        {
            this.dBContext = dBContext;
        }

        public StatusOutput CreateShop(ShopInput? data)
        {
            var returnValue = new StatusOutput();

            try
            {
                if (data != null)
                {
                    var company = dBContext.MsCompany.Where(x => x.id == data.company_id).FirstOrDefault();

                    if (company == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "company not found";
                        return returnValue;
                    }

                    if (data.id == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "id cannot be empty";
                        return returnValue;
                    }

                    if (data.name == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "name cannot be empty";
                        return returnValue;
                    }

                    if (data.email == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "email cannot be empty";
                        return returnValue;
                    }

                    if (data.password == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "password cannot be empty";
                        return returnValue;
                    }

                    if (data.phone == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "phone cannot be empty";
                        return returnValue;
                    }

                    returnValue.statusCode = 201;
                    returnValue.message = "shop created";
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
