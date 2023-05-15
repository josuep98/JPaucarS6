namespace JPaucarS6.Clases
{
    public class VehicleResponse
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        public string BrandModel
        {
            get
            {
                return Brand + " - " + Model;
            }
        }

    }
}
