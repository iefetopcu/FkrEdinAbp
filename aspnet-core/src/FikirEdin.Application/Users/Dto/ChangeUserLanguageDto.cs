using System.ComponentModel.DataAnnotations;

namespace FikirEdin.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}