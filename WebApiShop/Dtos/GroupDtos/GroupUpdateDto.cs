using FluentValidation;

namespace WebApiShop.Dtos.GroupDtos
{
    public class GroupUpdateDto
    {
        public string Name { get; set; }
        public int Limit { get; set; }
        public IFormFile File { get; set; }

    }
    public class GroupUpdateDtoValidator : AbstractValidator<GroupUpdateDto>
    {
        public GroupUpdateDtoValidator()
        {

            RuleFor(g => g.Name)
                    .MaximumLength(10)
                    .WithMessage("the message is too long")
                    .MinimumLength(3)
                    .WithMessage("at least 3 characters");
            RuleFor(g => g.Limit)
                .InclusiveBetween(5, 20)
                .WithMessage("group limit should be between 5 and 20");
            RuleFor(g => g)
                .Custom((g, context) =>
                {
                    if (g.File != null)
                    {
                        if (g.File.Length / 1024 > 500)
                        {
                            context.AddFailure("File", "too large");
                        }
                        if (!g.File.ContentType.Contains("image/"))
                        {
                            context.AddFailure("File", "only image");
                        }
                    }
                   
                });



        }
    }
}
