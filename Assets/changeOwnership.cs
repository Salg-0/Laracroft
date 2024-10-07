using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(XRGrabInteractable))]
public class ChangeOwnershipOnGrab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private PhotonView photonView;

    void Awake()
    {
        // Get references to the required components
        grabInteractable = GetComponent<XRGrabInteractable>();
        photonView = GetComponent<PhotonView>();

        // Subscribe to the grab event
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Request ownership if the local player is not already the owner
        if (photonView != null && photonView.Owner != PhotonNetwork.LocalPlayer)
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the grab event
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}
