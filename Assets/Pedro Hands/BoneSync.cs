using Photon.Pun;
using UnityEngine;

public class BoneSync : MonoBehaviourPun, IPunObservable
{
    public Transform[] bones; // List of bones to synchronize
    float t = 0;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //bool changed = (Time.frameCount % 2 == 0);
            //stream.SendNext(changed);
            //if (!changed) return;
            //t = Time.time;
            stream.SendNext(bones[0].localPosition);
            foreach (var bone in bones)
            {
                //stream.SendNext(bone.localPosition);
                stream.SendNext(bone.localRotation);
            }
        }
        else
        {
            //bool changed = (bool)stream.ReceiveNext();
            //if (!changed) return;
            bones[0].localPosition = (Vector3)stream.ReceiveNext();
            foreach (var bone in bones)
            {
                //bone.localPosition = (Vector3)stream.ReceiveNext();
                bone.localRotation = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}
//public class BoneSync : MonoBehaviourPun, IPunObservable
//{
//    public Transform[] bones; // List of bones to synchronize

//    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
//    {
//        if (stream.IsWriting)
//        {
//            foreach (var bone in bones)
//            {
//                stream.SendNext(bone.localPosition);
//                stream.SendNext(bone.localRotation);
//            }
//        }
//        else
//        {
//            foreach (var bone in bones)
//            {
//                bone.localPosition = (Vector3)stream.ReceiveNext();
//                bone.localRotation = (Quaternion)stream.ReceiveNext();
//            }
//        }
//    }
//}
