using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public interface IMyMapper<First, Second>
    {
        public First Map(Second Second);

        public Second Map(First First);

        public IEnumerable<First> Map(IEnumerable<Second> Second);

        public IEnumerable<Second> Map(IEnumerable<First> First);
    }

}
