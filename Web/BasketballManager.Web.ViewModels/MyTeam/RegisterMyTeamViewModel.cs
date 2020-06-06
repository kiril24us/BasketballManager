namespace BasketballManager.Web.ViewModels.MyTeam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using AutoMapper;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;

    public class RegisterMyTeamViewModel //: IMapFrom<MyTeam>
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
