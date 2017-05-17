using Game.Impact.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Enemy.Model {
    public class EnemyData : Impactable {

        private const int DEATH_TRESHOLD = 0;

        public int Life { get; set; }
        public int Damage { get; set; }

        public EnemyData(int life, int damage) {
            Life = life;
            Damage = damage;
        }

        public void SufferImpact(int damage) {
            Life -= damage;
        }

        public int ImpactOutput() {
            return Damage;
        }

        public bool IsDead() {
            return Life <= DEATH_TRESHOLD;
        }
    }
}
