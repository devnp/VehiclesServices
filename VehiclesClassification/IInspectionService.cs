using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesClassification
{
    public interface IInspectionService
    {
        void PrepareServicesPlan();
    }

    public class StandardPakiet : IInspectionService
    {
        public void PrepareServicesPlan()
        {

        }
    }
}
