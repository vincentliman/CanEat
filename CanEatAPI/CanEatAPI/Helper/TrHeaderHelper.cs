using CanEatAPI.Input;
using CanEatAPI.Output;
using CanEatAPI.Models;
using static System.Runtime.CompilerServices.RuntimeHelpers;



namespace CanEatAPI.Helper
{
    public class TrHeaderHelper
    {
        public CanEatDBContext dBContext;
        public TrHeaderHelper(CanEatDBContext dBContext)
        {
            this.dBContext = dBContext;
        }


        public List<TrHead> GetAllTransactions()
        {
            var returnValue = new List<TrHead>();

            try
            {
                var transactions = dBContext.TrHeader.ToList();

                returnValue = transactions.Select(transaction => new TrHead()
                {
                    tr_id = transaction.tr_id.ToString(),
                    shop_id = transaction.shop_id.ToString(),
                    customer_id = transaction.customer_id.ToString(),
                    date = transaction.date,
                    pickUpDateTime = transaction.pickUpDateTime,
                    paymentStatus = transaction.paymentStatus,
                    pickUpStatus = transaction.pickUpStatus
                }).ToList();
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public StatusOutput UpdateTrHeader(UpdateTrHeaderInput data)
        {
            var returnValue = new StatusOutput();

            try
            {
                var trheader = dBContext.TrHeader.Where(x => x.tr_id == data.tr_id).FirstOrDefault();

                if (trheader == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "transaction not found";
                    return returnValue;
                }

                if (data.paymentStatus != null)
                {
                    trheader.paymentStatus = (Boolean)data.paymentStatus.Value;
                }

                if (data.pickUpStatus != null)
                {
                    trheader.pickUpStatus = (Boolean)data.pickUpStatus.Value;
                }

                dBContext.TrHeader.Update(trheader);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "transaction updated";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public StatusOutput DeleteTrHeader(string id)
        {
            var returnValue = new StatusOutput();

            try
            {
                Guid trheaderId = Guid.Parse(id);
                var trheader = dBContext.TrHeader.Where(x => trheaderId == x.tr_id).FirstOrDefault();
                if (trheader == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "trheader not found";
                    return returnValue;
                }

                dBContext.TrHeader.Remove(trheader);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "trheader deleted";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public StatusOutput CreateTrHeader(CreateTrHeaderInput? data)
        {
            var returnValue = new StatusOutput();

            try
            {
                if (data != null)
                {
                    var shop = dBContext.MsShop.Where(x => x.id.ToString().Equals(data.shop_id)).FirstOrDefault();
                    var customer = dBContext.MsCustomer.Where(x => x.id.ToString().Equals(data.customer_id)).FirstOrDefault();


                    if (shop == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "shop not found";
                        return returnValue;
                    }

                    if (customer == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "customer not found";
                        return returnValue;
                    }

                    //if (data.id == null)
                    //{
                    //    returnValue.statusCode = 204;
                    //    returnValue.message = "id cannot be empty";
                    //    return returnValue;
                    //}

                    //if (data.date == DateTime.MinValue)
                    //{
                    //    returnValue.statusCode = 204;
                    //    returnValue.message = "date cannot be empty";
                    //    return returnValue;
                    //}

                    if (data.pickUpDateTime == DateTime.MinValue)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "pick up date cannot be empty";
                        return returnValue;
                    }

                    //if (data.paymentStatus == null)
                    //{
                    //    returnValue.statusCode = 204;
                    //    returnValue.message = "payment status cannot be empty";
                    //    return returnValue;
                    //}

                    //if (data.pickUpStatus == null)
                    //{
                    //    returnValue.statusCode = 204;
                    //    returnValue.message = "pick up status cannot be empty";
                    //    return returnValue;
                    //}


                    var trheader = new TrHeader
                    {
                        tr_id = Guid.NewGuid(),
                        shop_id = shop.id,
                        customer_id = customer.id,
                        date = DateTime.Now,
                        pickUpDateTime = data.pickUpDateTime,
                        paymentStatus = false,
                        pickUpStatus=  false,
                    };

                    dBContext.TrHeader.Add(trheader);
                    dBContext.SaveChanges();

                    returnValue.statusCode = 201;
                    returnValue.message = trheader.tr_id.ToString();
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
