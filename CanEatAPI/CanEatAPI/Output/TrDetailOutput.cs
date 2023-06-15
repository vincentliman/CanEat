namespace CanEatAPI.Output
{
    public class TrDetailOutput
    {
        public List<TrDetailOut> payload { get; set; }
        public TrDetailOutput()
        {
            payload = new List<TrDetailOut>();
        }
    }

    public class TrDetailOut
    {
        public string tr_id { get; set; }
        public string food_id { get; set; }
        public int qty { get; set; }
        public string notes { get; set; }
    }
}
