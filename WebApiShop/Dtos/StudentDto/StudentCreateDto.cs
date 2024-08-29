using FluentValidation;
using WebApiShop.DLL.Entites;

namespace WebApiShop.Dtos.StudentDto
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public double Point { get; set; }
        public int GroupId { get; set; }
    }
    public class StudentUpdateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentUpdateDtoValidator() 
        {
            RuleFor(s => s.Name)
                    .NotEmpty()
                    .MaximumLength(20)
                    .MinimumLength(2);
            RuleFor(s => s.Point)
                .NotEmpty()
                .InclusiveBetween(0, 100);
            RuleFor(s => s.GroupId).NotEmpty();
        }
    }
}
