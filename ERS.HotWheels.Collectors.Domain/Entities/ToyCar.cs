﻿using ERS.HotWheels.Collectors.Domain.Entities.Base;

namespace ERS.HotWheels.Collectors.Domain.Entities
{
    public class ToyCar : EntityBase
    {
        public string Name { get; set; }
        public DateTime ReleaseYear { get; set; }
        public Guid BrandId { get; set; }
        public Guid CollectionId { get; set; }
        public int? CollectionIndex { get; set; }
        public string? Tampography { get; set; }
        public Guid WheelTypeId { get; set; }

        // Images
    }
}