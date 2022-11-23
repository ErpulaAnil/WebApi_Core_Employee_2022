using System.ComponentModel.DataAnnotations;

namespace WebApi_MultipleClasses_with_GenericT.Models
{
    public class Student
    {
        [Key]
        public int SId { get; set; }

        public string StudentRollNo { get; set; }

        public string StudentName { get; set; }

        public string StudentMarks { get; set; }
    }
}
