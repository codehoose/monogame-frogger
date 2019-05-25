using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameFrogger.Controllers
{
    interface IReset
    {
        void Reset(ResetMode resetMode);
    }
}
