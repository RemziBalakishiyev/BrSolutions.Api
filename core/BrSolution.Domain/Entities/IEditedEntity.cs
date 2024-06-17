using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Domain.Entities
{
    public interface IEditedEntity : IEntity
    {
        public DateTime? LastEditedDate { get; set; }
    }
}
