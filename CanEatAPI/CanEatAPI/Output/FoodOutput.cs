namespace CanEatAPI.Output
{
    public class FoodOutput
    {
        public List<Food> payload { get; set; }
        public FoodOutput()
        {
            payload = new List<Food>();
        }
    }

    public class FoodOutput2
    {
        public FoodData payload4 { get; set; }
        public FoodOutput2()
        {
            payload4 = new FoodData();
        }
    }

    public class FoodData
    {
        public string id { get; set; }
        public string name { get; set; }

    }

    public class Food
    {
        public string id { get; set; }
        public string shop_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string photo { get; set; }
        public string description { get; set; }

    }
}
