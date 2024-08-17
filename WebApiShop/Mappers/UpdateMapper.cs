using WebApiShop.DLL.Entites;
using WebApiShop.Dtos.GroupDtos;

namespace WebApiShop.Mappers
{
    public class UpdateMapper
    {
        public static Group UpdateToGroup(GroupUpdateDto dto) => new Group
        {
            Name = dto.Name,
            Limit = dto.Limit,
        };
    }
}
