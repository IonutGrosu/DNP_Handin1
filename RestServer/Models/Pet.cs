using System.ComponentModel.DataAnnotations;

namespace Models {
public class Pet {
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(32)]
    public string Species { get; set; }
    [Required, MaxLength(32)]
    public string Name { get; set; }
    public int Age { get; set; }
}
}