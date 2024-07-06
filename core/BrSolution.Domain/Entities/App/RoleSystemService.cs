using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Domain.Entities.App
{
    public class RoleSystemService : IEntity
    {
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public int SystemServiceId { get; set; }

        public SystemService SystemService { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
