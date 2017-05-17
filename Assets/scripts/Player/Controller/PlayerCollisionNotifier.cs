using Game.Impact.Model;
using Game.Impact.Service;
using Game.Player.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Player.Controller {
    public interface PlayerCollisionNotifier {
        void OnCollision(Impactable source, Impactable destiny);
    }
}
