using Game.Player.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Portal.Controller {
    public interface PortalEnterNotifier {
        void OnPortalEnter(PlayerData playerData);
    }
}
