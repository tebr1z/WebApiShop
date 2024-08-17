using WebApiShop.DLL.Entites;
using WebApiShop.Dtos.GroupDtos;

namespace WebApiShop.Mappers
{
    public class GroupMapper
    {
        public static Group GroupCreateDtoToGroup(GroupCreateDto dto) => new Group
        {
            Name = dto.Name,
            Limit = dto.Limit,
        };
        public static GroupReturnDto GroupToReturnDto(Group group) => new GroupReturnDto
        {
            Id = group.Id,
            Name = group.Name,
            Limit = group.Limit,
            CreatedDate =group.CreatedDate,
            UpdateDate =group.UpdateDate,
          Students = group.Students.Select(s=>new StudentInGroupReturnDto
          {
              Name=s.Name,
              Point = s.Point,


          }).ToList(),
        };
    }
}
