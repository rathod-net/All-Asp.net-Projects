using System.ComponentModel.DataAnnotations.Schema;

namespace StateDistrictCityMasterApi.Model
{
    [Table("City")]
    public class City
    {
        public int CityId { get; set; } 
        public string CityName { get; set; }
        public int DistrictId{ get; set; }
    }
}
