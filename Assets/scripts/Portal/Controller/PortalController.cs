using Assets.scripts.Portal.Model;
using Game.Player.Model;
using Game.Player.UI;
using Game.Portal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Portal.Controller {
    public class PortalController : PortalEnterNotifier, PortalDataOutput {

        PortalDataOutput portalDataOutput;

        public PortalData GetPortalData() {
            return portalDataOutput.GetPortalData();
        }

        public void OnPortalEnter(PlayerData playerData) {

        }
    }
}
