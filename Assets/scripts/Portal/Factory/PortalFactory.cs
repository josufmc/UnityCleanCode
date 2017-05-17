using Assets.scripts.Portal.Model;
using Game.Portal.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.Portal.Factory {
    class PortalFactory {

        private PortalsController portalsController;

        public PortalFactory(PortalsController portalsController) {
            this.portalsController = portalsController;
        }

        public void CreatePortal(PortalUI portalUI) {
            PortalData portalData = new PortalData();
            PortalController portalController = new PortalController();
            portalUI.SetPortalData(portalData);
            portalUI.SetPortalEnterNotifier(portalController);
            portalsController.AddPortal(portalController);
        }
    }
}
