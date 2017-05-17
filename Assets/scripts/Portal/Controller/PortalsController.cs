using Assets.scripts.Portal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Portal.Controller {
    class PortalsController: PortalRandomizer, PortalRemover {

        private List<PortalController> portalList;
        private PortalRemoveListener portalRemoveListener;

        public PortalsController() {
            portalList = new List<PortalController>();
        }

        public void SetPortalRemoveListener(PortalRemoveListener portalRemoveListener) {
            this.portalRemoveListener = portalRemoveListener;
        }

        public void AddPortal(PortalController portal) {
            portalList.Add(portal);
        }

        public void RemovePortal(PortalController portal) {
            portalList.Remove(portal);
            if (portalRemoveListener != null) {
                portalRemoveListener.PortalRemove(portal.GetPortalData().GetGuid());
            }
            portal.Remove();
        }

        private PortalController TeleportationDestiny(PortalController sourcePortal) {
            int index = portalList.IndexOf(sourcePortal);
            if (index < portalList.Count - 1) {
                return portalList[index+1];
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

        public void RemovePortal(PortalData portal) {
            PortalController portalController = GetPortalControllerByPortalData(portal);
            RemovePortal(portalController);
        }
    }
}
