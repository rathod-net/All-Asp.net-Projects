namespace StateDistrictCityClient.Models.Entities
{
    public class LocationViewModel
    {
        public int SelectedStateId { get; set; }
        public int SelectedDistrictId { get; set; }
        public int SelectedCityId { get; set; }

        public List<State> states { get; set; } = new List<State>();
        public List<District> districts { get; set; } = new List<District>();
        public List<City> cities { get; set; } = new List<City>();
    }
}
