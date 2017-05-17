using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Player.Controller;
using Game.Player.UI;
using Game.Enemy.Controller;
using Game.Enemy.UI;
using Game.Impact.Service;
using Game.Enemy.Model;
using Game.Player.Model;
using Game.Enemy.Factory;
using Game.Player.Factory;
using Assets.scripts.Portal.Factory;
using Game.Portal.Controller;
using Game.Portal.UI;

namespace Game.Main {
    public class MainScript : MonoBehaviour {

        private void Start() {
            Inject();
        }

        private void Inject() {

            // Services
            ImpactService impactService = new ImpactService();

            // Groupal controller
            PortalsController portalsController = new PortalsController();
            PortalUICollection portalUIList = new PortalUICollection();
            portalsController.SetPortalRemoveListener(portalUIList);

            // Factories
            PlayerFactory playerFactory = new PlayerFactory(portalsController, portalsController, impactService, portalUIList);
            EnemyFactory enemyFactory = new EnemyFactory(impactService);
            PortalFactory portalFactory = new PortalFactory(portalsController, portalUIList);
            
            // References
            PlayerUI playerUI = GameObject.Find("/Player").GetComponent<PlayerUI>();
            EnemyUI enemyUI1 = GameObject.Find("/Enemies/Enemy1").GetComponent<EnemyUI>();
            EnemyUI enemyUI2 = GameObject.Find("/Enemies/Enemy2").GetComponent<EnemyUI>();
            PortalUI portalUI1 = GameObject.Find("/Portals/Portal1").GetComponent<PortalUI>();
            PortalUI portalUI2 = GameObject.Find("/Portals/Portal2").GetComponent<PortalUI>();
            PortalUI portalUI3 = GameObject.Find("/Portals/Portal3").GetComponent<PortalUI>();

            // Injection
            playerFactory.CreatePlayer(playerUI);
            enemyFactory.CreateEnemy(enemyUI1);
            enemyFactory.CreateEnemy(enemyUI2);
            portalFactory.CreatePortal(portalUI1);
            portalFactory.CreatePortal(portalUI2);
            portalFactory.CreatePortal(portalUI3);
        }
    }
}
