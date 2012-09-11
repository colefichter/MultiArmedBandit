using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAB;

namespace MABTests
{
    class EmptyRepository : IBanditRepo<object>
    {
        #region IBanditRepo<object> Members

        public IAlternative[] Alternatives
        {
            get { return new EmptyAlternative[0]; }
        }
        
        #endregion
    }

    class EmptyAlternative : AbstractAlternative
    {
    }
}
