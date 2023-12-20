using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DAL.Entities
{
    internal class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string TaskTitle { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(80)]
        public string AdditionalDescription { get; set; }

        [Required]
        public DateTime TaskStartTime { get; set; }

        [Required]
        [DisplayName("Finish time")]
        public DateTime TaskEndTime { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
