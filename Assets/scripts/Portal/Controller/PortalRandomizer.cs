using Assets.scripts.Portal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Portal.Controller {
    public interface PortalRandomizer {
        PortalData GetRandomPortal(PortalData portal);
    }
}
