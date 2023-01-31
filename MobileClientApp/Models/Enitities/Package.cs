using MobileClientApp.Models.Base;

namespace MobileClientApp.Models.Enitities
{
    public class Package : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

    }
}
