using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Photon.Pun;
using UnityEngine.XR;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (!photonView.IsMine)
        {
            rightHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);

            MapPosition(head, XRNode.Head);
            Debug.Log("head");
            MapPosition(leftHand, XRNode.LeftHand);
            Debug.Log("LeftHand");
            MapPosition(rightHand, XRNode.RightHand);
            Debug.Log("RightHand");
        }

    }

    void MapPosition(Transform target, XRNode node){
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        Debug.Log(position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);
        Debug.Log(rotation);
        
        target.position = position;
        target.rotation = rotation;
    }
}
