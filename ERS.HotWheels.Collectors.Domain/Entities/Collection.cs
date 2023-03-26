using ERS.HotWheels.Collectors.Domain.Entities.Base;

namespace ERS.HotWheels.Collectors.Domain.Entities
{
    public class Collection : EntityBase
    {
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TotalToyCar { get; set; }

        public ICollection<ToyCar>? ToyCars { get; set; }

        public Collection() { }

        public Collection(
            string name, 
            DateTime releaseDate, 
            DateTime endDate
        )
        {
            Name = name;
            ReleaseDate = releaseDate;
            EndDate = endDate;
        }
    }
}
