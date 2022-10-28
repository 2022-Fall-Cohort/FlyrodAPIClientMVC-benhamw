namespace FlyrodAPIClientMVC.Models
{
    public class Maker
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int YearFounded { get; set; }
        public string? Type { get; set; }
        public virtual List<Flyrod>? flyrods { get; set; }

        public Maker(int? id, string name, int yearfounded, string? type)
        {
            Id = id;
            Name = name;
            YearFounded = yearfounded;
            Type = type;
        }

        public Maker()
        {
            return;
        }
    }
}
