﻿namespace CanEatAPI.Input
{
    public class UpdateCartInput
    {
        public Guid? customer_id { get; set; }
        public string? food_name { get; set; }
        public int? qty { get; set; }
        public string? notes { get; set; }
    }
}