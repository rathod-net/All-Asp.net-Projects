using System.ComponentModel.DataAnnotations.Schema;

namespace StateDistrictCityClient.Models.Entities;
public class District
{
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    public int StateId { get; set; }
}
