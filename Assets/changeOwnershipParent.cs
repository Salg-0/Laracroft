using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeOwnershipParentOnGrab : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public PhotonView photonView;

    void Awake()
    {
        // Subscribe to the grab event
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnParentGrabbed);
        }
    }

    private void OnParentGrabbed(SelectEnterEventArgs args)
    {
        // Request ownership if the local player is not already the owner
        if (photonView != null && photonView.Owner != PhotonNetwork.LocalPlayer)
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }
    }
}
