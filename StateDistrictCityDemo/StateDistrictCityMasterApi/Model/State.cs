using System.ComponentModel.DataAnnotations.Schema;

namespace StateDistrictCityMasterApi.Model
{
    [Table("State")]
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}
