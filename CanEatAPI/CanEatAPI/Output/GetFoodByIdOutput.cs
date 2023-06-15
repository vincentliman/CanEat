namespace CanEatAPI.Output
{
    public class GetFoodByIdOutput
    {
        public FoodDataById? payload { get; set; }
        public GetFoodByIdOutput()
        {
            payload = new FoodDataById();
        }
    }

    public class FoodDataById
    {
        public string name { get; set; }
        public int price { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
    }
}
