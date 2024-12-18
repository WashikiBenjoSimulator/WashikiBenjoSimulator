using System.Collections;
using System.Collections.Generic;
using GameScript;
using UnityEngine;

public class hipMoving : MonoBehaviour
{
    // [SerializeField] private GameObject hipInPlayerObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = hipInPlayerObj.transform.position;

        //rayを下方向に飛ばす
        Vector3 rayOrigin = transform.position;
        if(Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit))
        {
            //もしrayがbennkiタグのオブジェクトに当たったら
            if(hit.collider.CompareTag("bennki"))
            {
                GameManager.Instance.canPoop = true;
            }
        }
    }
}
