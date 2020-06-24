namespace BasketballManager.Web.ViewModels.Teams
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterMyTeamViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string Owner { get; set; }

        [Required]
        public string Coach { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Choose what type of Team is this!")]
        public bool IsManaged { get; set; }
    }
}
