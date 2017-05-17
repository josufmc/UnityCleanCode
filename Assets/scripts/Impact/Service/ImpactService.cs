using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Game.Impact.Model;

namespace Game.Impact.Service {
    public class ImpactService {

        public void DoImpact(Impactable source, Impactable destiny) {
            destiny.SufferImpact(source.ImpactOutput());
        }
    }
}
