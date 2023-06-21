using CanEatAPI.Input;
using CanEatAPI.Output;
using CanEatAPI.Models;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.ComponentModel.Design;

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
				Guid shopId = Guid.Parse(id);
				var shop = dBContext.MsShop.ToList().FirstOrDefault(x => shopId == x.id);
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
				//var company = dBContext.MsCompany.ToList();

				returnValue = shops.Select(shop => new Shop()
				{
					id = shop.id.ToString(),
					company_id = shop.company_id.ToString(),
					name = shop.name,
					email = shop.email,
					password = shop.password,
					phone = shop.phone,
					status = shop.status,

				}).ToList();
				return returnValue;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public StatusOutput UpdateShop(UpdateShopInput data)
		{
			var returnValue = new StatusOutput();

			try
			{
				var shop = dBContext.MsShop.Where(x => x.id == data.id).FirstOrDefault();
				var company = dBContext.MsCompany.Where(x => x.name.Equals(data.company_name)).FirstOrDefault();

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

				if (data.status != null)
				{
					shop.status = data.status.Value;
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

		public StatusOutput UpdateShopStatus(UpdateShopStatusInput data)
		{
			var returnValue = new StatusOutput();

			try
			{
				var shop = dBContext.MsShop.Where(x => x.name.Equals(data.name)).FirstOrDefault();
				var company = dBContext.MsCompany.Where(x => x.name.Equals(data.company_name)).FirstOrDefault();

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

				if (data.status == false)
				{
					shop.status = (bool)data.status;
				}


				dBContext.MsShop.Update(shop);
				dBContext.SaveChanges();

				returnValue.statusCode = 200;
				returnValue.message = "shop status updated";
				return returnValue;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public ShopDataById? GetShopData(string id)
		{
			var returnValue = new ShopDataById();
			try
			{
				Guid shopId = Guid.Parse(id);
				var shopData = dBContext.MsShop.ToList().FirstOrDefault(x => shopId == x.id);
				if (shopData != null)
				{
					//var companyData = dBContext.MsCompany.Where(x => x.id == customerData.company_id).FirstOrDefault();
					//var religionData = dBContext.MsReligion.Where(x => x.id == studentData.religionId).FirstOrDefault();

					//returnValue.student = student;
					returnValue.name = shopData.name;
					returnValue.email = shopData.email;
					returnValue.phone = shopData.phone;
					returnValue.status = shopData.status;


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






		public StatusOutput CreateShop(CreateShopInput? data)
		{
			var returnValue = new StatusOutput();

			try
			{
				if (data != null)
				{
					var company = dBContext.MsCompany.Where(x => x.name.Equals(data.company_name)).FirstOrDefault();

					if (company == null)
					{
						returnValue.statusCode = 404;
						returnValue.message = "company not found";
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

					var shop = new MsShop
					{
						id = Guid.NewGuid(),
						company_id = company.id,
						name = data.name,
						email = data.email,
						password = data.password,
						phone = data.phone,
						status = false,
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
						returnValue.id = shopData.id.ToString();
						returnValue.company_id = shopData.company_id.ToString();
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
