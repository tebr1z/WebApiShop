using WebApiShop.DLL.Entites;

namespace WebApiShop.Dtos.GroupDtos
{
    public class GroupReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<StudentInGroupReturnDto> Students { get; set; }
    }
    public class StudentInGroupReturnDto
    {
        public string Name{ get; set; }
        public double Point { get; set; }
    }
}
