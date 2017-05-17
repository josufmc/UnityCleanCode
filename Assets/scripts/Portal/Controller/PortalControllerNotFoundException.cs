using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Portal.Controller {
    public class PortalControllerNotFoundException : Exception {
        public PortalControllerNotFoundException(): base() {

        }

        public PortalControllerNotFoundException(string msg) : base(msg) {

        }
    }
}
