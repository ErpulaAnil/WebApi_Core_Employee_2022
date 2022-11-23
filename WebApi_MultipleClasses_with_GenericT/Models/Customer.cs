using System.ComponentModel.DataAnnotations;

namespace WebApi_MultipleClasses_with_GenericT.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }

        public string CustomerName { get; set; }

        public string CustAddress { get; set; }

        public string CustPhNo { get; set; }    
    }
}
