using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviourPun
{
    // UnityEvents for local and remote players
    public UnityEvent onLocalPlayerInstantiated;
    [Space(10)]
    public UnityEvent onRemotePlayerInstantiated;

    private void Start()
    {
        // Check if this is the local player
        if (photonView.IsMine)
        {
            // Trigger the event for the local player
            Debug.Log("Local player instantiated.");
            onLocalPlayerInstantiated.Invoke();
        }
        else
        {
            // Trigger the event for a remote player
            Debug.Log("Remote player instantiated.");
            onRemotePlayerInstantiated.Invoke();
        }
    }
}
