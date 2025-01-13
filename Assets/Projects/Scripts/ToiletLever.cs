using GameScript;
using Projects.Scripts.Core;
using UnityEngine;

public class ToiletLever : SingletonMonoBehaviour<ToiletLever>, IAltoManager
{
    public float rotateAngle = -60f;
    public float rotateDuration = 0.5f;
    public float returnDelay = 1.0f;

    private Quaternion initialRotation;
    private bool isReturning = false;
    private float timer = 0f;

    void Start()
    {
        initialRotation = transform.localRotation;
    }

    void IAltoManager.OnInitialize()
    {
        // 初期化処理があればここに書く
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isReturning)
        {
            RotateLever();
        }


        // レバーが戻るまでの処理
        if (isReturning)
        {
            timer += Time.deltaTime;

            if (timer >= returnDelay)
            {
                RotateBack();
            }
        }
    }

    public void RotateLever()
    {
        transform.localRotation = initialRotation * Quaternion.Euler(0f, 0f, rotateAngle);
        timer = 0f;
        isReturning = true;
    }

    private void RotateBack()
    {
        transform.localRotation = initialRotation;
        isReturning = false;
    }
}
