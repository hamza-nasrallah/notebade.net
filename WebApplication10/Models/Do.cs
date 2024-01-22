using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Do
    {
        [Key]
        public int id { get; set; }
        [Required (ErrorMessage ="the name is reqierd") ]
        public string Name { get; set; }=string.Empty;

        [DataType(DataType.Date) ]
        public DateTime date { get; set; }


        [DataType(DataType.MultilineText)]
        public string Desc{ get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }
}
