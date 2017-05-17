using Assets.scripts.Portal.Model;
using Game.Portal.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Portal.UI {
    class PortalUICollection : PortalUIIdentifier, PortalRemoveListener {
        public Dictionary<Guid, PortalUI> portalUIDict;

        public PortalUICollection() {
            portalUIDict = new Dictionary<Guid, PortalUI>();
        }

        public void AddPortalUI(PortalUI portalUI) {
            portalUIDict.Add(portalUI.GetGuid(), portalUI);
        }

        public void RemovePortalUI(Guid guid) {
            portalUIDict.Remove(guid);
        }

        public PortalUI Find(Guid guid) {
            return portalUIDict[guid];
        }

        public PortalUI GetPortalUI(PortalData portalData) {
            return Find(portalData.GetGuid());
        }

        public void PortalRemove(Guid guid) {
            RemovePortalUI(guid);
        }
    }
}
