

namespace WebApiShop.Dtos.StudentDto
{
    public class StudentRetrunDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Point { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
