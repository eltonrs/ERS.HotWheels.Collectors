using ERS.HotWheels.Collectors.Domain.Entities.Base;

namespace ERS.HotWheels.Collectors.Domain.Entities
{
    public class WheelType : EntityBase
    {
        public string LetterCode { get; set; }
        public string DescriptionType { get; set; }
        public string? Notes { get; set; }
    }
}
