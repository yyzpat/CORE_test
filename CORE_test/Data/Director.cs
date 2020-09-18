using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE_test.Data
{
  [Table("Director")]
  public partial class Director
  {
    public int EmployeeId { get; set; }
    public int PosteId { get; set; }

  
  }
}