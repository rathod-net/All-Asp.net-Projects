using System.ComponentModel.DataAnnotations.Schema;

namespace StateDistrictCityMasterApi.Model
{
    [Table("District")]
    public class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int StateId { get; set; }
    }
}
