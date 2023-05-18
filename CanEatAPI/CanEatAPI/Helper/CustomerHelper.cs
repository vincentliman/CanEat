using CanEatAPI.Input;
using CanEatAPI.Models;
using CanEatAPI.Output;

namespace CanEatAPI.Helper
{
    public class CustomerHelper
    {
        public CanEatDBContext dBContext;

        public CustomerHelper(CanEatDBContext dBContext)
        {
            this.dBContext = dBContext;
        }



        public List<Customer> GetAllCustomers()
        {
            var returnValue = new List<Customer>();

            try
            {
                var customers = dBContext.MsCustomer.ToList();

                returnValue = customers.Select(customer => new Customer()
                {
                    id = customer.id.ToString(),
                    company_id = customer.company_id.ToString(),
                    name = customer.name,
                    email = customer.email,
                    password = customer.password,
                    phone = customer.phone,
                }).ToList();
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public StatusOutput CreateCustomer(CreateCustomerInput? data)
        {
            var returnValue = new StatusOutput();

            try
            {
                if (data != null)
                {
                    var company = dBContext.MsCompany.Where(x => x.name.Equals(data.company_name)).FirstOrDefault();
                    var existing = dBContext.MsCustomer.Where(x=>x.email == data.email).FirstOrDefault();

                    if(existing != null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "email udah ada";
                        return returnValue;
                    }

                   if (company == null)
                   {
                        returnValue.statusCode = 404;
                        returnValue.message = "company cannot be empty";
                        return returnValue;
                   }

                    //if (data.id == null)
                    //{
                    //    returnValue.statusCode = 204;
                    //    returnValue.message = "id cannot be empty";
                    //    return returnValue;
                    //}

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


                    var customer = new MsCustomer
                    {
                        id = Guid.NewGuid(),
                        company_id = company.id,
                        name = data.name,
                        email = data.email,
                        password = data.password,
                        phone = data.phone,
                    };

                    dBContext.MsCustomer.Add(customer);
                    dBContext.SaveChanges();

                    returnValue.statusCode = 201;
                    returnValue.message = "registered!";
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

        public CustomerData? LoginCustomer(string email, string password)
        {
            var returnValue = new CustomerData();
            try
            {
                var customerData = dBContext.MsCustomer.Where(x => x.email == email).FirstOrDefault();
                //var shopData = dBContext.MsShop.Where(x => x.password == password).FirstOrDefault();
                if (customerData != null)
                {
                    var pass = dBContext.MsCustomer.Where(x => x.password == password).FirstOrDefault();
                    if (pass != null)
                    {
                        //returnValue.id = customerData.id;
                        //returnValue.company_id = customerData.company_id;
                        returnValue.name = customerData.name;
                        returnValue.email = customerData.email;
                        return returnValue;

                    }
                    else
                    {
                        return null;
                    }



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






    }
}
