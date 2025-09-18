﻿using QDryClean.Domain.Entities;

namespace QDryClean.Application.Dtos
{
    public class ItemDto
    {
        public string? Colour { get; set; }
        public string? BrandName { get; set; }
        public string? Description { get; set; }
        public ItemType ItemType { get; set; }
        public Order Order { get; set; }
    }
}
