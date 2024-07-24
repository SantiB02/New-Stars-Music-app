namespace Merchanmusic.Data.Entities
{
    public class Admin : User
    {
        public DateTime? JoinedOn { get; set; } = DateTime.Now;
    }
}
