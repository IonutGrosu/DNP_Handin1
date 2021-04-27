using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models {
public class Family {
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(64)]
    public string StreetName { get; set; }
    [Required, Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid House Number")]
    public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();     
    }
}


}