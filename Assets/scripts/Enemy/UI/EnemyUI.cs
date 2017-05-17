using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Enemy.Controller;
using System;
using Game.Enemy.Model;
using Game.Player.UI;

namespace Game.Enemy.UI {

    public class EnemyUI : MonoBehaviour, EnemyDataOutput, EnemyDeadOutput {

        private EnemyCollisionNotifier enemyControllerInput;
        private EnemyData enemyData;

        public void SetEnemyControllerInput(EnemyCollisionNotifier enemyControllerInput) {
            this.enemyControllerInput = enemyControllerInput;
        }
        public void SetEnemyData(EnemyData enemyData) {
            this.enemyData = enemyData;
        }

        public EnemyData GetEnemyData() {
            return enemyData;
        }

        public void Log(string msg) {
            Debug.Log(msg);
        }

        private void OnCollisionEnter(Collision collision) {
            PlayerUI player = collision.gameObject.GetComponent<PlayerUI>();
            if (player != null) {
                enemyControllerInput.OnCollision(GetEnemyData(), player.GetPlayerData());
            }
        }

        public void Die() {
            gameObject.SetActive(false);
        }
    }
}
