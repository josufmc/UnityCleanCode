using Assets.scripts.Portal.Model;
using Game.Portal.Controller;
using Game.Portal.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Game.Player.UI;

public class PortalUI : MonoBehaviour, PortalDataOutput, PortalRemoveOutput {

    private Guid guid;
    private PortalEnterNotifier portalEnterNotifier;
    private PortalData portalData;


    public void SetPortalEnterNotifier(PortalEnterNotifier portalEnterNotifier) {
        this.portalEnterNotifier = portalEnterNotifier;
    }
    public void SetPortalData(PortalData portalData) {
        this.portalData = portalData;
    }

    public void SetGuid(Guid guid) {
        this.guid = guid;
    }

    public Guid GetGuid() {
        return guid;
    }

    public PortalData GetPortalData() {
        return portalData;
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject collider = collision.gameObject;
        PlayerUI player = collider.GetComponent<PlayerUI>();
        if(player != null) {
            portalEnterNotifier.OnPortalEnter(player.GetPlayerData());
        }
    }

    public void Remove() {
        Destroy(gameObject);
    }
}
