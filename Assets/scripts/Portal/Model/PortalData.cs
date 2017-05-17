using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.Portal.Model {
    public class PortalData {
        private Guid guid;

        public PortalData(Guid guid) {
            this.guid = guid;
        }

        public Guid GetGuid() {
            return guid;
        }
    }
}
