using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Game.Enemy.UI;
using Game.Impact.Service;
using Game.Impact.Model;

namespace Game.Enemy.Controller {
    public interface EnemyCollisionNotifier {

        void OnCollision(Impactable source, Impactable destiny);
    }
}
