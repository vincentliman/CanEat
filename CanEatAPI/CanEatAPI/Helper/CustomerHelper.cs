using CanEatAPI.Input;
using CanEatAPI.Models;
using CanEatAPI.Output;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

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
                var companies = dBContext.MsCompany.ToList();

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

        public StatusOutput UpdateCustomer(UpdateCustomerInput data)
        {
            var returnValue = new StatusOutput();

            try
            {
                var customer = dBContext.MsCustomer.Where(x => x.id == data.id).FirstOrDefault();
                var company = dBContext.MsCompany.Where(x => x.name.Equals(data.company_name)).FirstOrDefault();

                if (customer == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "customer not found";
                    return returnValue;
                }

                if (company == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "company not found";
                    return returnValue;
                }

                if (data.company_name != null)
                {
                    customer.company_id = company.id;
                }

                if (data.name != null)
                {
                    customer.name = data.name;
                }

                if (data.email != null)
                {
                    customer.email = data.email;
                }

                if (data.password != null)
                {
                    customer.password = data.password;
                }

                if (data.phone != null)
                {
                    customer.phone = data.phone;
                }


                dBContext.MsCustomer.Update(customer);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "customer updated";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public StatusOutput DeleteCustomer(string id)
        {
            var returnValue = new StatusOutput();

            try
            {
                Guid customerId = Guid.Parse(id);
                var customer = dBContext.MsCustomer.Where(x => customerId == x.id).FirstOrDefault();
                if (customer == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "food not found";
                    return returnValue;
                }

                dBContext.MsCustomer.Remove(customer);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "customer deleted";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CustomerDataById? GetCustomerData(string id)
        {
            var returnValue = new CustomerDataById();
            try
            {
                Guid customerId = Guid.Parse(id);
                var customerData = dBContext.MsCustomer.ToList().FirstOrDefault(x=>customerId == x.id);
                if (customerData != null)
                {
                    //var companyData = dBContext.MsCompany.Where(x => x.id == customerData.company_id).FirstOrDefault();
                    //var religionData = dBContext.MsReligion.Where(x => x.id == studentData.religionId).FirstOrDefault();

                    //returnValue.student = student;
                    returnValue.name = customerData.name;
                    returnValue.email = customerData.email;
                    returnValue.phone = customerData.phone;


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
                        returnValue.id = customerData.id.ToString();
                        returnValue.company_id = customerData.company_id.ToString();
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
