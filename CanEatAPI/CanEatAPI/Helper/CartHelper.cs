using CanEatAPI.Input;
using CanEatAPI.Models;
using CanEatAPI.Output;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace CanEatAPI.Helper
{
    public class CartHelper
    {
        public CanEatDBContext dBContext;

        public CartHelper(CanEatDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<CartOut> GetAllCart()
        {
            var returnValue = new List<CartOut>();

            try
            {
                var foods = dBContext.MsFood.ToList();
                var customers = dBContext.MsCustomer.ToList();
                var carts = dBContext.MsCart.ToList();


                returnValue = carts.Select(cart => new CartOut()
                {
                    customer_id = cart.customer_id.ToString(),
                    food_id = cart.food_id.ToString(),
                    qty = cart.qty,
                    notes = cart.notes,
                }).ToList();
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public StatusOutput UpdateCart(UpdateCartInput data)
        {
            var returnValue = new StatusOutput();

            try
            {
                //var customer = dBContext.MsCustomer.Where(x => x.id == data.customer_id).FirstOrDefault();
                
                var cart = dBContext.MsCart.Where(x => x.customer_id == data.customer_id).FirstOrDefault();
                var food = dBContext.MsFood.Where(x => x.id.ToString().Equals(data.food_id)).FirstOrDefault();

                if (cart == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "cart not found";
                    return returnValue;
                }

                //if (food == null)
                //{
                //    returnValue.statusCode = 404;
                //    returnValue.message = "food not found";
                //    return returnValue;
                //}


                if (data.qty != null)
                {
                    cart.qty = (int)data.qty;
                }

                if (data.notes != null)
                {
                    cart.notes = data.notes;
                }


                dBContext.MsCart.Update(cart);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "cart updated";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public StatusOutput DeleteCart(string id)
        {
            var returnValue = new StatusOutput();

            try
            {
                Guid customerId = Guid.Parse(id);
                var customer = dBContext.MsCart.Where(x => customerId == x.customer_id).FirstOrDefault();
                if (customer == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "customer not found";
                    return returnValue;
                }

                dBContext.MsCart.Remove(customer);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "cart deleted";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public StatusOutput CreateCart(CreateCartInput? data)
        {
            var returnValue = new StatusOutput();

            try
            {
                if (data != null)
                {
                    
                    var food = dBContext.MsFood.Where(x => x.id.ToString().Equals(data.food_id)).FirstOrDefault();
                    var customer = dBContext.MsCustomer.Where(x =>x.id.ToString().Equals(data.customer_id)).FirstOrDefault();


                    if (food == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "food not found";
                        return returnValue;
                    }

                    if (customer == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "customer not found";
                        return returnValue;
                    }


                    if (data.qty == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "quantity cannot be empty";
                        return returnValue;
                    }

                    


                    var cart = new MsCart
                    {
                        customer_id = customer.id,
                        food_id = Guid.Parse(data.food_id),
                        qty =  data.qty.Value,
                        notes =  data.notes,

                    };

                    dBContext.MsCart.Add(cart);
                    dBContext.SaveChanges();

                    returnValue.statusCode = 201;
                    returnValue.message = "transactrion created";
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
