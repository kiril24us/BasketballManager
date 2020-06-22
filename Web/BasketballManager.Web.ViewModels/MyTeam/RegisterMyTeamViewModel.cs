namespace BasketballManager.Web.ViewModels.MyTeam
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
    }
}
