using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRLink
{
   public Transform vrController;
   public Transform target;
   public Vector3 trackingPositionOffset;
   public Vector3 trackingRotationOffset;

   // VRヘッドセット、ハンドコントローラーの位置と向きをTargetに設定
   public void Control()
   {
       target.position = vrController.TransformPoint(trackingPositionOffset);
       target.rotation = vrController.rotation * Quaternion.Euler(trackingRotationOffset);
   }
}

public class AvatarController : MonoBehaviour
{
   public VRLink head;
   public VRLink leftHand;
   public VRLink rightHand;

   public Transform headTarget;
   private Vector3 modelOffset;

   void Start()
   {
       // 頭のTarget位置とモデルの位置の差異を取得
       modelOffset = transform.position - headTarget.position;
   }

   void LateUpdate()
   {
       // VRヘッドセットの位置と向きを元にモデルの位置と向きを設定
       transform.position = headTarget.position + modelOffset;
       transform.forward = Vector3.ProjectOnPlane(headTarget.up,Vector3.up).normalized;

       // VRヘッドセット、ハンドコントローラーの位置とリグのTargetの位置の同期させる
       head.Control();
       leftHand.Control();
       rightHand.Control();
   }
}
