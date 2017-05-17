using Game.Impact.Model;
using Game.Impact.Service;
using Game.Player.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Portal.UI;
using Game.Portal.Controller;
using Assets.scripts.Portal.Model;

namespace Game.Player.Controller {
    class PlayerController : PlayerCollisionNotifier, PlayerTeleportationNotifier, PlayerTeleportationFinishedNotifier {

        private PortalRandomizer portalRandomizer;
        private PlayerDataOutput playerDataOutput;
        private PlayerDeadOutput playerDeadOutput;
        private PlayerTeleportableOutput playerTeleportableOutput;
        private ImpactService impactService;

        public void SetPlayerDataOutput(PlayerDataOutput playerDataOutput) {
            this.playerDataOutput = playerDataOutput;
        }
        public void SetPlayerDeadOutput(PlayerDeadOutput playerDeadOutput) {
            this.playerDeadOutput = playerDeadOutput;
        }
        public void SetPlayerTeleportableOutput(PlayerTeleportableOutput playerTeleportableOutput) {
            this.playerTeleportableOutput = playerTeleportableOutput;
        }
        public void SetImpactService(ImpactService impactService) {
            this.impactService = impactService;
        }
        public void SetPortalsController(PortalRandomizer portalRandomizer) {
            this.portalRandomizer = portalRandomizer;
        }

        public void OnCollision(Impactable source, Impactable destiny) {
            impactService.DoImpact(destiny, source);
            playerDataOutput.Log("Player collision! HP remaining: " + source.Life);
            ManageDeadAfterImpact(source);
        }

        private void ManageDeadAfterImpact(Impactable source) {
            if(source.IsDead()) {
                playerDeadOutput.Die();
            }
        }

        public void OnTeleportation(PortalData source) {
            PortalData destiny = portalRandomizer.GetRandomPortal(source);
            playerTeleportableOutput.Teleport(destiny);
        }

        public void OnTeleportationFinished(PortalData portal) {
            throw new NotImplementedException();
        }
    }
}
