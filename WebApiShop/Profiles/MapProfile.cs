using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApiShop.DLL.Entites;
using WebApiShop.Dtos.GroupDtos;
using WebApiShop.Dtos.StudentDto;
using WebApiShop.Extension;


namespace WebApiShop.Profiles
{
    public class MapProfile:Profile
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MapProfile(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            
            var uriBuilder = new UriBuilder
                (
                _httpContextAccessor.HttpContext.Request.Scheme,
                _httpContextAccessor.HttpContext.Request.Host.Host,
             (int)   _httpContextAccessor.HttpContext.Request.Host.Port
                );
            var url = uriBuilder.Uri.AbsoluteUri;
            CreateMap<Student, StudentInGroupReturnDto>();
            CreateMap<Group, GroupReturnDto>()
                .ForMember(d => d.Image, map => map.MapFrom(s => url+"uploads/images/" + s.Image));
            CreateMap<GroupCreateDto, Group>()
                .ForMember(g => g.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "uploads/images")));

            CreateMap<StudentCreateDto, Student>().ReverseMap();
            CreateMap<Student, StudentRetrunDto>();
                

        }
    }
}
