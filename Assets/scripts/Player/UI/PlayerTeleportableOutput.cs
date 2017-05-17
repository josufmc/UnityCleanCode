using Assets.scripts.Portal.Model;
using Game.Player.Controller;
using Game.Player.Model;
using Game.Portal.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Player.UI {
    public interface PlayerTeleportableOutput {
        void Teleport(PortalData portal);
    }
}
