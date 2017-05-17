using Assets.scripts.Portal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Portal.UI {
    public interface PortalUIIdentifier {
        PortalUI GetPortalUI(PortalData portalData);
    }
}
