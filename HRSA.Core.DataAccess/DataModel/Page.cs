using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSA.Core.DataAccess.DataModel
{
     public class Page
    {
         public int Id { get; set; }

         public string PageContent { get; set; }

         public string PageName { get; set; }

         public DateTime CreatedOn { get; set; }

         public string CreatedBy { get; set; }

         [NotMapped]
         public IList<Feature> Features { get; set; }
    }
}
