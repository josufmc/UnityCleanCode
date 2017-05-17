using Assets.scripts.Portal.Model;
using Game.Portal.Controller;
using Game.Portal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.Portal.Factory {
    class PortalFactory {

        private PortalsController portalsController;
        private PortalUICollection portalUICollection;

        public PortalFactory(PortalsController portalsController, PortalUICollection portalUICollection) {
            this.portalsController = portalsController;
            this.portalUICollection = portalUICollection;
            this.portalsController.SetPortalRemoveListener(portalUICollection);
        }

        public void CreatePortal(PortalUI portalUI) {
            Guid guid = Guid.NewGuid();
            PortalData portalData = new PortalData(guid);
            PortalController portalController = new PortalController();
            portalUI.SetGuid(guid);
            portalUI.SetPortalData(portalData);
            portalUI.SetPortalEnterNotifier(portalController);
            portalController.SetPortalDataOutput(portalUI);
            portalController.SetPortalRemoveOutput(portalUI);
            portalsController.AddPortal(portalController);
            portalUICollection.AddPortalUI(portalUI);
        }
    }
}
