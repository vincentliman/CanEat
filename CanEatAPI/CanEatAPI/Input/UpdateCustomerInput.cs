﻿namespace CanEatAPI.Input
{
    public class UpdateCustomerInput
    {
        public Guid? id { get; set; }
        public string? company_id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? phone { get; set; }
    }
}
