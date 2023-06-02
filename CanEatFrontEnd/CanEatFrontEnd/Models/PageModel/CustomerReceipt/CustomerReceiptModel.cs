namespace CanEatFrontEnd.Models.PageModel.CustomerReceipt
{
    public class CustomerReceiptModel
    {
        public TrHeader currTrans { get; set; }

        public CustomerReceiptModel() {
            currTrans = new TrHeader();
        }
    }
}
