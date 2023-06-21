using CanEatAPI.Input;
using CanEatAPI.Models;
using CanEatAPI.Output;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CanEatAPI.Helper
{
    public class TrDetailHelper
    {
        public CanEatDBContext dBContext;

        public TrDetailHelper(CanEatDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public StatusOutput CreateTrDetail(CreateTrDetailInput? data)
        {
            var returnValue = new StatusOutput();

            try
            {
                if (data != null)
                {
                    var food = dBContext.MsFood.Where(x => x.id.ToString().Equals(data.food_id)).FirstOrDefault();
                    //var customer = dBContext.MsCustomer.Where(x => x.name.Equals(data.customer_name)).FirstOrDefault();
                    var trheader = dBContext.TrHeader.Where(x => x.tr_id == data.tr_id).FirstOrDefault();


                    if (food == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "food not found";
                        return returnValue;
                    }

                    if (trheader == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "transaction id not found";
                        return returnValue;
                    }

                    if (data.tr_id == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "transaction id cannot be empty";
                        return returnValue;
                    }

                    if (data.qty == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "quantity cannot be empty";
                        return returnValue;
                    }



                    var trdetail = new TrDetail
                    {
                        tr_id = trheader.tr_id,
                        food_id = food.id,
                        qty = data.qty.Value,
                        notes = data.notes,

                    };

                    dBContext.TrDetail.Add(trdetail);
                    dBContext.SaveChanges();

                    returnValue.statusCode = 201;
                    returnValue.message = "transaction detail created";
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

        public StatusOutput UpdateTrDetail(UpdateTrDetailInput data)
        {
            var returnValue = new StatusOutput();

            try
            {
                var trdetail = dBContext.TrDetail.Where(x => x.tr_id == data.tr_id).FirstOrDefault();
                var food = dBContext.MsFood.Where(x => x.name.Equals(data.food_name)).FirstOrDefault();

                if (trdetail == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "transaction not found";
                    return returnValue;
                }

                if (food == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "food not found";
                    return returnValue;
                }

                if (data.qty != null)
                {
                    trdetail.qty = data.qty.Value;
                }

                if (data.food_name != null)
                {
                    trdetail.food_id = food.id;
                }

                if (data.notes != null)
                {
                    trdetail.notes = data.notes;
                }

                dBContext.TrDetail.Update(trdetail);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "transaction detail updated";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public StatusOutput DeleteTrDetail(string id)
        {
            var returnValue = new StatusOutput();

            try
            {
                Guid trdetailId = Guid.Parse(id);
                var trdetail = dBContext.TrDetail.Where(x => trdetailId == x.tr_id).FirstOrDefault();
                if (trdetail == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "trdetail not found";
                    return returnValue;
                }

                dBContext.TrDetail.Remove(trdetail);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "trdetail deleted";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TrDetailOut> GetAllTrDetail()
        {
            var returnValue = new List<TrDetailOut>();

            try
            {
                var foods = dBContext.MsFood.ToList();
                var transactions = dBContext.TrHeader.ToList();
                var transactionDetails = dBContext.TrDetail.ToList();


                returnValue = transactionDetails.Select(transactiondetail => new TrDetailOut()
                {
                    tr_id = transactiondetail.tr_id.ToString(),
                    food_id = transactiondetail.food_id.ToString(),
                    qty = transactiondetail.qty,
                    notes = transactiondetail.notes,
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
