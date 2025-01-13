using System.Collections;
using System.Collections.Generic;
using Projects.Scripts.Core;
using UnityEngine;

public class TouchDetection : SingletonMonoBehaviour<TouchDetection>, IAltoManager
{
    public bool isToiletPaperTouch = false;
    public bool isFlushHandleTouch = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void IAltoManager.OnInitialize()
    {
        // 初期化処理があればここに書く
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onCliderEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("ToiletPaper"))
        {
            isToiletPaperTouch = true;
        }
        if (collider.gameObject.CompareTag("FlushHandle"))
        {
            ToiletLever.Instance.RotateLever();
            isFlushHandleTouch = true;
        }
    }
}
