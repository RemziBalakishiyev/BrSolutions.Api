using BrSolution.Infrastructure.PredefinedValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Domain.Entities.Libraries
{
    public class Gender : IEntity
    {
        public GenderValue Id{ get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
