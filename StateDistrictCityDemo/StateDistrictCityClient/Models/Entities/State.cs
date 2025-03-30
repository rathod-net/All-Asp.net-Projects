using System.ComponentModel.DataAnnotations.Schema;


namespace StateDistrictCityClient.Models.Entities;

public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }

