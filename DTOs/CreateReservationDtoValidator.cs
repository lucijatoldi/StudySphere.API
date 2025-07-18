using FluentValidation;

namespace StudySphere.API.DTOs
{
    public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
    {
        public CreateReservationDtoValidator()
        {
            // Pravilo 1: Početno vrijeme je obavezno
            RuleFor(x => x.StartTime).NotEmpty();

            // Pravilo 2: Krajnje vrijeme je obavezno
            RuleFor(x => x.EndTime).NotEmpty();

            // Pravilo 3: Krajnje vrijeme mora biti nakon početnog vremena
            RuleFor(x => x.EndTime).GreaterThan(x => x.StartTime)
                .WithMessage("End time must be after start time.");

            // Pravilo 4: Rezervacija ne smije biti u prošlosti (provjeravamo samo početno vrijeme)
            RuleFor(x => x.StartTime).GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Reservation cannot be in the past.");

            // Pravilo 5: ID sobe mora biti veći od 0
            RuleFor(x => x.StudyRoomId).GreaterThan(0);

            // Pravilo 6: ID korisnika mora biti veći od 0
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}