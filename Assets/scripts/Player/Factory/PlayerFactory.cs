using Game.Enemy.Controller;
using Game.Enemy.Model;
using Game.Enemy.UI;
using Game.Impact.Service;
using Game.Player.Controller;
using Game.Player.Model;
using Game.Player.UI;
using Game.Portal.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Player.Factory {
    class PlayerFactory {

        private ImpactService impactService;
        private PortalsController portalsController;

        public PlayerFactory(PortalsController portalsController, ImpactService impactService) {
            this.portalsController = portalsController;
            this.impactService = impactService;
        }

        public void CreatePlayer(PlayerUI playerUI) {
            PlayerController playerController = new PlayerController();
            PlayerData playerData = new PlayerData(100, 20);
            playerController.SetPortalsController(portalsController);
            playerController.SetPlayerDataOutput(playerUI);
            playerController.SetPlayerDeadOutput(playerUI);
            playerController.SetPlayerTeleportableOutput(playerUI);
            playerController.SetImpactService(impactService);
            playerUI.SetPlayerCollisionNotifier(playerController);
            playerUI.SetPlayerData(playerData);
        }
    }
}
