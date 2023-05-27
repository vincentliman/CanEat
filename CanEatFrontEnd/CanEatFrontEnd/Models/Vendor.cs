namespace CanEatFrontEnd.Models
{
    public class Vendor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Company Company { get; set; }
        public Boolean Status { get; set; }

        public Vendor() { 
            Company = new Company();
        }
    }
}
