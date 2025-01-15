using System.Collections;
using System.Collections.Generic;
using GameScript;
using Projects.Scripts.Core;
using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onCliderEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("ToiletPaper"))
        {
            GameManager.Instance.isToiletPaperTouch = true;
        }
        if (collider.gameObject.CompareTag("FlushHandle"))
        {
            ToiletLever.Instance.RotateLever();
            GameManager.Instance.isFlushHandleTouch = true;
        }
    }
}
