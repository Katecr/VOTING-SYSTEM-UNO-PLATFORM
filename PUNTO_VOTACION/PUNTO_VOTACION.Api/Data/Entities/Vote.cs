using System.ComponentModel.DataAnnotations;


namespace PUNTO_VOTACION.Api.Data.Entities
{
    public class Vote
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Question { get; set; }

        [Required]
        [MaxLength(200)]
        public string Answer { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public User User { get; set; }
    }
}
