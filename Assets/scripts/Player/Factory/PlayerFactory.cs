using Game.Enemy.Controller;
using Game.Enemy.Model;
using Game.Enemy.UI;
using Game.Impact.Service;
using Game.Player.Controller;
using Game.Player.Model;
using Game.Player.UI;
using Game.Portal.Controller;
using Game.Portal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Player.Factory {
    class PlayerFactory {

        private ImpactService impactService;
        private PortalRandomizer portalRandomizer;
        private PortalRemover portalRemover;
        private PortalUIIdentifier portalUIIdentifier;

        public PlayerFactory(
            PortalRandomizer portalRandomizer,
            PortalRemover portalRemover,
            ImpactService impactService, 
            PortalUIIdentifier portalUIIdentifier
            ) {

            this.portalRandomizer = portalRandomizer;
            this.portalRemover = portalRemover;
            this.impactService = impactService;
            this.portalUIIdentifier = portalUIIdentifier;
        }

        public void CreatePlayer(PlayerUI playerUI) {
            PlayerController playerController = new PlayerController();
            PlayerData playerData = new PlayerData(100, 20);
            playerController.SetPortalsController(portalRandomizer);
            playerController.SetPlayerDataOutput(playerUI);
            playerController.SetPlayerDeadOutput(playerUI);
            playerController.SetPlayerTeleportableOutput(playerUI);
            playerController.SetImpactService(impactService);
            playerUI.SetPlayerTeleportationNotifier(playerController);
            playerUI.SetPlayerCollisionNotifier(playerController);
            playerUI.SetPlayerData(playerData);
            playerUI.SetPortalUIIdentifier(portalUIIdentifier);
            playerUI.SetPortalRemover(portalRemover);
        }
    }
}
