namespace BasketballManager.Web.ViewModels.Games
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    using BasketballManager.Web.ViewModels.MyTeam;

    public class RegisterGameViewModel
    {
        public int MyTeamId { get; set; }

        public int OpponentId { get; set; }

        [Required]
        [Range(0, 1000)]
        public int MyPoints { get; set; }

        [Required]
        [Range(0, 1000)]
        public int OpponentPoints { get; set; }

        public DateTime DateNow { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public IEnumerable<MyTeamViewModel> Teams { get; set; }

        public IEnumerable<MyTeamViewModel> Opponents { get; set; }
    }
}
