using Assets.scripts.Portal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Portal.Controller {
    class PortalsController: PortalRandomizer {

        private List<PortalController> portalList;

        public PortalsController() {
            portalList = new List<PortalController>();
        }

        public void AddPortal(PortalController portal) {
            portalList.Add(portal);
        }

        public void RemovePortal(PortalController portal) {
            portalList.Remove(portal);
        }

        private PortalController TeleportationDestiny(PortalController sourcePortal) {
            int index = portalList.IndexOf(sourcePortal);
            if (index < portalList.Count - 1) {
                return portalList[index++];
            }
            return portalList[0];
        }

        public PortalData GetRandomPortal(PortalData portal) {
            PortalController sourceController = GetPortalControllerByPortalData(portal);
            PortalController destinyController = TeleportationDestiny(sourceController);
            return destinyController.GetPortalData();
        }

        private PortalController GetPortalControllerByPortalData(PortalData portal) {
            for(int i = 0; i < portalList.Count; i++) {
                PortalController controller = portalList[i];
                if(controller.GetPortalData().Equals(portal)) {
                    return controller;
                }
            }
            throw new PortalControllerNotFoundException("Portal not found");
        }

    }
}
