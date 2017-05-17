using Game.Enemy.Controller;
using Game.Enemy.Model;
using Game.Enemy.UI;
using Game.Impact.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Enemy.Factory {
    class EnemyFactory {

        private ImpactService impactService;

        public EnemyFactory(ImpactService impactService) {
            this.impactService = impactService;
        }

        public void CreateEnemy(EnemyUI enemyUI) {
            EnemyController enemyController = new EnemyController();
            EnemyData enemyData = new EnemyData(40, 10);
            enemyController.SetEnemyDataOutput(enemyUI);
            enemyController.SetEnemyDeadOutput(enemyUI);
            enemyController.SetImpactService(impactService);
            enemyUI.SetEnemyControllerInput(enemyController);
            enemyUI.SetEnemyData(enemyData);
        }
    }
}
