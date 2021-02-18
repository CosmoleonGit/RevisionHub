using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.revision
{
    public abstract class Revision
    {
        public abstract void Start(Action onFinish = null);
    }
}
