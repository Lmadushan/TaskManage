using AutoMapper;

namespace TaskManage.Common.AutoMapperProfile
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            #region Project Type ------------------------------------------------------------------
            //CreateMap<ProjectType, BaseDropDownVM<Guid>>()
            //    .ForMember(dest => dest.Value, src => src.MapFrom(s => s.Type));

            //CreateMap<ProjectType, ProjectTypeVM>();
            #endregion Project Type ---------------------------------------------------------------
        }
    }
}
