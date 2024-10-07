using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]

public class Ownership : MonoBehaviour
{
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView != null && photonView.Owner != PhotonNetwork.LocalPlayer &&  GameObject.Find("owner"))
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
