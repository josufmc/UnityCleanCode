using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Portal.Controller {
    public interface PortalRemoveListener {
        void PortalRemove(Guid guid);
    }
}
