using System.Collections;
using System.Collections.Generic;
using GameScript;
using UnityEngine;

public class Poop : MonoBehaviour
{
    private bool isFalling = true;  // オブジェクトが落下中かどうかのフラグ
    private Rigidbody rb;

    void Start()
    {
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();

        // Rigidbodyの重力を有効にして、自由落下を開始
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("benki"))
        {
            Debug.Log("Poop is in the toilet");
            GameManager.Instance.successPoop = true;
        }
        // 他のオブジェクトに接触したときに処理
        if (isFalling)
        {
            // 物理演算を停止して、オブジェクトの動きを止める
            rb.velocity = Vector3.zero;  // 速度をゼロにして停止
            rb.isKinematic = true;  // 物理シミュレーションを停止

            // 落下が完了したのでフラグを変更
            isFalling = false;

            // ここで接触したオブジェクトに応じて、追加の処理を行うことも可能です
            // 例えば、接触したオブジェクトをログに表示
            Debug.Log("接触したオブジェクト: " + collision.gameObject.name);
        }
    }
}