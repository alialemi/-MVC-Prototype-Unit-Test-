using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSA.Core.DataAccess.DataModel
{
    public enum AccessType {
        None,
        Read,
        Write,
        Read_Write
    };

    public class UserAccess
    {
        public int AccessId { get; set; }

        public AccessType AccessType { get; set; }

        public Feature Feature { get; set; }

        public User User { get; set; }

        public Page Page { get; set; }
    }
}
