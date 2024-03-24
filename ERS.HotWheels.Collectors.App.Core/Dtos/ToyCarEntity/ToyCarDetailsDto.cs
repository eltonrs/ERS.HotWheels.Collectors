namespace ERS.HotWheels.Collectors.App.Core.Dtos.ToyCarEntity
{
    public class ToyCarDetailsDto
    {
        public string? Name { get; set; }
        public DateTime ReleaseYear { get; set; }
        public Guid BrandId { get; set; }
        public int? CollectionIndex { get; set; }
        public string? Tampography { get; set; }
        public Guid? WheelTypeId { get; set; }
        public string? WheelTypeDescriptionType { get; set; }
        public Guid CollectionId { get; set; }
        public string? Collectionname { get; set; }
    }
}
