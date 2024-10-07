using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsIdentifier : MonoBehaviour
{
    public static Transform leftHand;
    public static Transform rightHand;

    public Transform left;
    public Transform right;

    private void Awake()
    {
        leftHand = left;
        rightHand = right;
    }
}
