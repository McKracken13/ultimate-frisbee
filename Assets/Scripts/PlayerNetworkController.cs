﻿using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkController : NetworkBehaviour
{
    private DiscController discController;
    private GameObject disc;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer) return;

        disc = GameObject.Find("Disc");
        discController = disc.GetComponent<DiscController>();
    }

    public void pickup (Transform heldDiscTransform)
    {
        //discController.CmdPickup(heldDiscTransform);
    }

    public void RequestDiscAuthority ()
    {
        // Request authority for disc
        NetworkIdentity id = disc.GetComponent<NetworkIdentity>();
        CmdRequestAuthority(id);
    }

    [Command]
    void CmdRequestAuthority(NetworkIdentity otherId)
    {
        otherId.AssignClientAuthority(connectionToClient);
    }
}
