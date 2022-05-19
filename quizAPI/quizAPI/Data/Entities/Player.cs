using System.ComponentModel.DataAnnotations;

namespace quizAPI.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public int? Score { get; set; }
        public int? ElapsedTime { get; set; }
    }
}
