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
    }
}
