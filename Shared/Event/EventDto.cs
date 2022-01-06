

using FluentValidation;
using HoefsmidEnjo.Shared.Users;
using System;

namespace HoefsmidEnjo.Shared.Event
{
    public abstract class EventDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Location { get; set; }
            public DateTime Time { get; set; }
            public UserDto.Detail Client { get; set; }
        }

        public class Create
        {
            public string Title { get; set; }
            public string Location { get; set; }
            public DateTime Time { get; set; }
            public UserDto.Detail Client { get; set; }

            public class Validator : AbstractValidator<Create>
            {
                public Validator()
                {
                    RuleFor(x => x.Title).NotNull().NotEmpty().MinimumLength(4).WithName("Titel");
                    RuleFor(x => x.Location).NotNull().NotEmpty().MinimumLength(4).WithMessage("Locatie");
                    RuleFor(x => x.Time).NotNull().NotEmpty().Must(x => x > DateTime.Now).WithMessage("Tijd");
                    RuleFor(x => x.Client).NotNull().WithName("Klant");

                }
            }
        }
    }
}
