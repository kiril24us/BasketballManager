namespace BasketballManager.Data.Models
{
    public class OpponentTeam
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MyTeamId { get; set; }

        public virtual MyTeam MyTeam { get; set; }
        
    }
}
