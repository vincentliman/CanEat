using CanEatAPI.Input;
using CanEatAPI.Output;
using CanEatAPI.Models;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CanEatAPI.Helper
{
    public class FoodHelper
    {
        public CanEatDBContext dBContext;

        public FoodHelper(CanEatDBContext dBContext)
        {
            this.dBContext = dBContext;
        }


        public StatusOutput UpdateFood(FoodInput data)
        {
            var returnValue = new StatusOutput();

            try
            {
                var shop = dBContext.MsShop.Where(x => x.id == data.shop_id).FirstOrDefault();
                var food = dBContext.MsFood.Where(x => x.id == data.id).FirstOrDefault();

                if (shop == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "shop not found";
                    return returnValue;
                }

                if (food == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "food not found";
                    return returnValue;
                }

                if (data.name != null)
                {
                    food.name = data.name;
                }

                if (data.price != null)
                {
                    food.price = (int)data.price;
                }

                if (data.description != null)
                {
                    food.description = data.description;
                }

                if (data.photo != null)
                {
                    food.photo = data.photo;
                }


                dBContext.MsFood.Update(food);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "food updated";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public StatusOutput DeleteFood(string id)
        {
            var returnValue = new StatusOutput();

            try
            {
                var food = dBContext.MsFood.Where(x => x.id == id).FirstOrDefault();
                if (food == null)
                {
                    returnValue.statusCode = 404;
                    returnValue.message = "food not found";
                    return returnValue;
                }

                dBContext.MsFood.Remove(food);
                dBContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "food deleted";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<Food> GetAllFoods()
        {
            var returnValue = new List<Food>();

            try
            {
                var foods = dBContext.MsFood.ToList();

                returnValue = foods.Select(food => new Food()
                {
                    id = food.id,
                    //shop_id = shop.id,
                    name = food.name,
                    price = food.price,
                    photo = food.photo,
                    description = food.description,
                }).ToList();
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public StatusOutput CreateFood(FoodInput? data)
        {
            var returnValue = new StatusOutput();

            try
            {
                if (data != null)
                {
                    var shop = dBContext.MsShop.Where(x => x.id == data.shop_id).FirstOrDefault();
                    

                    if (shop == null)
                    {
                        returnValue.statusCode = 404;
                        returnValue.message = "shop not found";
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

                    if (data.price == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "price cannot be empty";
                        return returnValue;
                    }

                    if (data.photo == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "photo cannot be empty";
                        return returnValue;
                    }

                    if (data.description == null)
                    {
                        returnValue.statusCode = 204;
                        returnValue.message = "desc cannot be empty";
                        return returnValue;
                    }


                    var food = new MsFood
                    {
                        id = data.id,
                        shop_id = shop.id,
                        name = data.name,
                        price = (int)data.price,
                        description = data.description,
                        photo = data.photo,
                    };

                    dBContext.MsFood.Add(food);
                    dBContext.SaveChanges();

                    returnValue.statusCode = 201;
                    returnValue.message = "food created";
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





        public FoodData? GetFood(string id)
        {
            var returnValue = new FoodData();
            try
            {
                var foodData = dBContext.MsFood.Where(x => x.id == id).FirstOrDefault();
                //var shopData = dBContext.MsShop.Where(x => x.password == password).FirstOrDefault();
                if (foodData != null)
                {
                        returnValue.id = foodData.id;
                        returnValue.name =  foodData.name;
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



    }
}
