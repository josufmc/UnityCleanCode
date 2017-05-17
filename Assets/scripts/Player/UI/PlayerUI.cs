using Game.Player.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Game.Player.Model;
using Game.Enemy.UI;
using Game.Portal.Controller;
using Assets.scripts.Portal.Model;
using Game.Portal.UI;

namespace Game.Player.UI {

    public class PlayerUI : MonoBehaviour, PlayerDataOutput, PlayerDeadOutput, PlayerTeleportableOutput {

        [SerializeField]
        private float moveSpeed = 10f;
        [SerializeField]
        private float turnSpeed = 200f;

        private PlayerTeleportationNotifier playerTeleportationNotifier;
        private PlayerCollisionNotifier playerCollisionNotifier;
        private PortalRemover portalRemover;
        private PortalUIIdentifier portalUIIdentifier;
        private PlayerData playerData;

        void Update() {
            if(Input.GetKey(KeyCode.UpArrow)) {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.DownArrow)) {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.LeftArrow)) {
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.RightArrow)) {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        }

        private void OnCollisionEnter(Collision collision) {
            GameObject collider = collision.gameObject;
            EnemyUI enemy = collider.GetComponent<EnemyUI>();
            PortalUI portal = collider.GetComponent<PortalUI>();
            if(enemy != null) {
                playerCollisionNotifier.OnCollision(GetPlayerData(), enemy.GetEnemyData());
            }
            if(portal != null) {
                playerTeleportationNotifier.OnTeleportation(portal.GetPortalData());
            }
        }

        public void Log(string msg) {
            Debug.Log(msg);
        }

        public void SetPlayerCollisionNotifier(PlayerCollisionNotifier playerCollisionNotifier) {
            this.playerCollisionNotifier = playerCollisionNotifier;
        }

        public void SetPlayerTeleportationNotifier(PlayerTeleportationNotifier playerTeleportationNotifier) {
            this.playerTeleportationNotifier = playerTeleportationNotifier;
        }

        public void SetPortalRemover(PortalRemover portalRemover) {
            this.portalRemover = portalRemover;
        }

        public void SetPortalUIIdentifier (PortalUIIdentifier portalUIIdentifier) {
            this.portalUIIdentifier = portalUIIdentifier;
        }

        public PlayerData GetPlayerData() {
            return playerData;
        }

        public void SetPlayerData(PlayerData playerData) {
            this.playerData = playerData;
        }

        public void Die() {
            gameObject.SetActive(false);
        }

        public void Teleport(PortalData portal) {
            PortalUI target = portalUIIdentifier.GetPortalUI(portal);
            Transform targetTransform = target.GetComponent<Transform>();
            transform.position = targetTransform.position + (-targetTransform.forward * 4);

            portalRemover.RemovePortal(portal);
        }
    }

}

