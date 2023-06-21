namespace CanEatAPI.Input
{
    public class UpdateTrHeaderInput
    {
        public Guid? tr_id { get; set; }

        public Boolean? paymentStatus { get; set; }
        public Boolean? pickUpStatus { get; set; }

    }
}
