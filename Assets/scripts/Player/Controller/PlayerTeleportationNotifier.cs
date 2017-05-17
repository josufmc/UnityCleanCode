using Assets.scripts.Portal.Model;
using Game.Impact.Model;
using Game.Impact.Service;
using Game.Player.UI;
using Game.Portal.Controller;
using Game.Portal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Player.Controller {
    public interface PlayerTeleportationNotifier {
        void OnTeleportation(PortalData source);
    }
}
