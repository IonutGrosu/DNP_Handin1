using System;
using System.ComponentModel.DataAnnotations;

namespace Models {
public class Person {
    
    public int Id { get; set; }
    [Required, MaxLength(32)]
    public string FirstName { get; set; }
    [Required, MaxLength(32)]
    public string LastName { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    [Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid age")]
    public int Age { get; set; }
    [Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid weight")]
    public float Weight { get; set; }
    [Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid height")]
    public int Height { get; set; }
    public string Sex { get; set; }
}


}