using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using UnityEngine.XR;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.Controls;

[RequireComponent(typeof(PhotonView))]

public class follwoHands : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionReference position;
    public InputActionReference rotation;
    public InputActionReference pinch;

    public AxisControl pinchStrengthIndex;
    public Animator animator;

    private bool following = false;

    private Quaternion _rotationValue;
    private Vector3 _positionValue;
    private PhotonView photonView;

    void Start()
    {
               
        if (photonView != null && photonView.Owner != PhotonNetwork.LocalPlayer && GameObject.Find("owner"))
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("owner") && following){
            _positionValue = position.action.ReadValue<Vector3>();
            _rotationValue = rotation.action.ReadValue<Quaternion>();
            this.transform.position = _positionValue;
            this.transform.rotation = _rotationValue;


            // Debug.Log("Pinching controls: " + (pinch.action.ReadValue<int>() & (int)4));
            if((pinch.action.ReadValue<int>() & (int)4) > 0) {
                animator.SetTrigger("TrClose");
            }else{
                animator.SetTrigger("TrOpen");
            }

        }
    }

    public void toggleFollowing(){
        following = !following;
        this.transform.position = new Vector3(0,0,0);
    }


}
