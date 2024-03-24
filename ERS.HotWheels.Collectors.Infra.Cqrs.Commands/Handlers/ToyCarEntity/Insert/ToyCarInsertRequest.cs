using MediatR;

namespace ERS.HotWheels.Collectors.Infra.Cqrs.Commands.Handlers.ToyCarEntity.Insert
{
    public class ToyCarInsertRequest : IRequest<Guid>
    {
        public string? Name { get; set; }
        public DateTime ReleaseYear { get; set; }
        public Guid BrandId { get; set; }
        public int? CollectionIndex { get; set; }
        public string? Tampography { get; set; }
        public Guid? WheelTypeId { get; set; }
        public Guid CollectionId { get; set; }
    }
}
