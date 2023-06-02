namespace CanEatFrontEnd.Models.PageModel.VendorDishEdit
{
	public class VendorDishEditModel
	{
		public Food currFood { get; set; }
		public VendorDishEditModel() {
			currFood = new Food();
		}
	}
}
