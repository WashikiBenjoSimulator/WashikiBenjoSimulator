using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseCorrect : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(transform.position + new Vector3(0, 20, 0), 0.5f, Vector3.down, out RaycastHit hit, 50f, layerMask))
        {
            var userPos = transform.position;
            userPos.y = 0.15f;

            transform.position = userPos;
        }else
        {
            var userPos = transform.position;
            userPos.y = 0.0f;

            transform.position = userPos;
        }
    }

    // void OnTriggerEnter(Collider collider)
    // {
    //     if (collider.gameObject.CompareTag("ashiba"))
    //     {
    //         onAshiba = true;
    //     }
    // }

    // void OnTriggerExit(Collider collider)
    // {
    //     if (collider.gameObject.CompareTag("ashiba"))
    //     {
    //         onAshiba = false;
    //     }
    // }
}
