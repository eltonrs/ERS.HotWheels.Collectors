using ERS.HotWheels.Collectors.Domain.Entities.Base;

namespace ERS.HotWheels.Collectors.Domain.Entities
{
    public class Collection : EntityBase
    {
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TotalToyCar { get; set; }

        public virtual ICollection<ToyCar>? ToyCars { get; set; }

        public Collection()
        {
            Name = "Default Name";
        }

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
