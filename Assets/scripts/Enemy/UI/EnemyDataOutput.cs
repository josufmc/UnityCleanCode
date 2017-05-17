using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Game.Enemy.Controller;
using Game.Enemy.Model;

namespace Game.Enemy.UI {
    public interface EnemyDataOutput {

        EnemyData GetEnemyData();

        void Log(string msg);
    }
}
