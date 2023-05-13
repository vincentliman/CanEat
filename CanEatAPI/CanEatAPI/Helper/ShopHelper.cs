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


        public StatusOutput DeleteShop(string id)
        {
            var returnValue = new StatusOutput();

            try
            {
                var shop = dBContext.MsShop.Where(x => x.id == id).FirstOrDefault();
                if (shop == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "shop not found";
                    return returnValue;
                }

                dBContext.MsShop.Remove(shop);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "shop deleted";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Shop> GetAllShops()
        {
            var returnValue = new List<Shop>();

            try
            {
                var shops = dBContext.MsShop.ToList();
                var company = dBContext.MsCompany.ToList();

                returnValue = shops.Select(shop => new Shop()
                {
                    id = shop.id,
                    //company_id = company.id,
                    name = shop.name,
                    email = shop.email,
                    password = shop.password,
                    phone = shop.phone,
                    
                }).ToList();
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public StatusOutput UpdateShop(ShopInput data)
        {
            var returnValue = new StatusOutput();

            try
            {
                var shop = dBContext.MsShop.Where(x => x.id == data.id).FirstOrDefault();
                var company = dBContext.MsCompany.Where(x => x.id == data.company_id).FirstOrDefault();

                if (shop == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "shop not found";
                    return returnValue;
                }

                if (company == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "company not found";
                    return returnValue;
                }

                if (data.name != null)
                {
                    shop.name = data.name;
                }

                if (data.email != null)
                {
                    shop.email = data.email;
                }

                if (data.password != null)
                {
                    shop.password = data.password;
                }

                if (data.phone != null)
                {
                    shop.phone = data.phone;
                }


                dBContext.MsShop.Update(shop);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "shop updated";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

                    var shop = new MsShop
                    {
                        id = data.id,
                        company_id = company.id,
                        name = data.name,
                        email= data.email,
                        password = data.password,
                        phone = data.phone,
                    };

                    dBContext.MsShop.Add(shop);
                    dBContext.SaveChanges();

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



        public ShopData? LoginShop(string email, string password)
        {
            var returnValue = new ShopData();
            try
            {
                var shopData = dBContext.MsShop.Where(x => x.email == email).FirstOrDefault();
                //var shopData = dBContext.MsShop.Where(x => x.password == password).FirstOrDefault();
                if (shopData != null)
                {
                    var pass = dBContext.MsShop.Where(x => x.password == password).FirstOrDefault();
                    if (pass != null)
                    {
                        returnValue.id = shopData.id;
                        returnValue.company_id = shopData.company_id;
                        returnValue.name = shopData.name;
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
