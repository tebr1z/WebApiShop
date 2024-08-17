using System.ComponentModel.DataAnnotations;

namespace WebApiShop.Dtos.GroupDtos
{
    public class GroupCreateDto
    {
        [MaxLength(10)]
        public string Name { get; set; }
        public int Limit { get; set; }
    }
}
    