

namespace FinalProject.Application.DTOs
{
    public abstract class BaseDto
    {
      
        public int Id { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
