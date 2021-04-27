using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
public class Interest {
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(32)]
    public string Type { get; set; }
    [Required, MaxLength(128)]
    public string Description { get; set; }

}
}