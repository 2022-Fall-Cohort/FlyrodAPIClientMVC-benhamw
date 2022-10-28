using System.Xml.Linq;

namespace FlyrodAPIClientMVC.Models
{
    public class Flyrod
    {
        public int? Id { get; set; }
        public string? Model { get; set; }
        public double LengthFeet { get; set; }
        public int Sections { get; set; }
        public string? LineWeight { get; set; }
        public int YearMade { get; set; }
        public string? Type { get; set; }
        public string? Construction { get; set; }
        public string? RodImage { get; set; }
        public int MakerId { get; set; }
        public virtual Maker? Maker { get; set; }

        public Flyrod(int? id, string model, double lengthfeet, int sections, string? lineweight, int yearmade, string? type, string? construction, string? rodimage, int makerid)
        {
            Id = id;
            Model = model;
            LengthFeet = lengthfeet;
            Sections = sections;
            LineWeight = lineweight;
            YearMade = yearmade;
            Type = type;
            Construction = construction;
            RodImage = rodimage;
            MakerId = makerid;
        }

        public Flyrod()
        {
            return;
        }
    }
}
