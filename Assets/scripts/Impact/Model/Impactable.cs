using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Impact.Model {
    public interface Impactable {
        int Life { get; }

        void SufferImpact(int damage);
        int ImpactOutput();
        bool IsDead();
    }
}
