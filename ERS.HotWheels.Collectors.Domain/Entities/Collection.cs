using ERS.HotWheels.Collectors.Domain.Entities.Base;

namespace ERS.HotWheels.Collectors.Domain.Entities
{
    public class Collection : EntityBase
    {
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TotalToyCar { get; set; }
    }
}
