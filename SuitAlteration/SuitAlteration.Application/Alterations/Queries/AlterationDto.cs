using AutoMapper;
using EnumsNET;
using SuitAlteration.Application.Common.Mappings;
using SuitAlteration.Domain.Entities;
using SuitAlteration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Queries
{
    public class AlterationDto : IMapFrom<Alteration>
    {
        public int AlterationId { get; set; }
        public int CustomerId { get; set; }
        public int SalesAssociateId { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }

        public List<AlterationPieceTypeDetailsDto> PieceTypeDetails { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Alteration, AlterationDto>()
                .ForMember(d => d.AlterationId, opt => opt.MapFrom(s => (int)s.Id))
                .ForMember(d => d.PieceTypeDetails, opt => opt.MapFrom(s => s.PieceTypeDetails))
                .ForMember(d => d.StatusId, opt => opt.MapFrom(s => (int)s.Status))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => ((AlterationStatus)s.Status).AsString(EnumFormat.Name)));
        }
    }

    public class AlterationPieceTypeDetailsDto : IMapFrom<AlterationPieceTypeDetail>
    {
        public SuitPieceType PieceTypeId { get; set; }
        public string PieceTypeName { get; set; }
        public SuitPieceTypeSide PieceSideId { get; set; }
        public string PieceSideName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AlterationPieceTypeDetail, AlterationPieceTypeDetailsDto>()
                .ForMember(d => d.PieceTypeId, opt => opt.MapFrom(s => (int)s.SuitPieceType))
                .ForMember(d => d.PieceTypeName, opt => opt.MapFrom(s => ((SuitPieceType)s.SuitPieceType).AsString(EnumFormat.Description)))
                .ForMember(d => d.PieceSideId, opt => opt.MapFrom(s => (int)s.SuitPieceTypeSide))
                .ForMember(d => d.PieceSideName, opt => opt.MapFrom(s => ((SuitPieceTypeSide)s.SuitPieceTypeSide).AsString(EnumFormat.Description)));
        }
    }
}
