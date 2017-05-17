using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Game.Enemy.UI;
using Game.Impact.Service;
using Game.Impact.Model;

namespace Game.Enemy.Controller {
    class EnemyController : EnemyCollisionNotifier {

        private EnemyDeadOutput enemyDeadOutput;
        private EnemyDataOutput enemyDataOutput;
        private ImpactService impactService;

        public void SetEnemyDataOutput(EnemyDataOutput enemyDataOutput) {
            this.enemyDataOutput = enemyDataOutput;
        }
        public void SetEnemyDeadOutput(EnemyDeadOutput enemyDeadOutput) {
            this.enemyDeadOutput = enemyDeadOutput;
        }
        public void SetImpactService(ImpactService impactService) {
            this.impactService = impactService;
        }

        public void OnCollision(Impactable source, Impactable destiny) {
            impactService.DoImpact(destiny, source);
            enemyDataOutput.Log("Enemy collision! HP remaining: " + source.Life);
            ManageDeadAfterImpact(source);
        }

        private void ManageDeadAfterImpact(Impactable destiny) {
            if(destiny.IsDead()) {
                enemyDeadOutput.Die();
            }
        }
    }
}
