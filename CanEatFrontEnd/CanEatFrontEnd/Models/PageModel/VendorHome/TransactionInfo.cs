namespace CanEatFrontEnd.Models.PageModel.VendorHomeModel
{
    public class TransactionInfo
    {
        public TrHeader? header { get; set; }
        public List<TrDetail> detail { get; set; }
        public Customer? customer { get; set; }

        public TransactionInfo() { 
            header = new TrHeader();
            detail = new List<TrDetail>();
            customer = new Customer();
        }
    }
}
