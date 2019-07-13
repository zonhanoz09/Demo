using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo.Models.Classes
{
    [Table("DemoTable")]
    public class DemoTable : BaseEntity
    {
        [Key]
        [Column("StepID")]
        public int StepID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("StepName")]
        public string StepName { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("Description")]
        public string Description { get; set; }

        [Required]
        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}