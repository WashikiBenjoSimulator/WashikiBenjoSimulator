using UnityEngine;

public class AdjustZByHeight : MonoBehaviour
{
    public Transform body;          // 高さの基準となるBody Transform
    public float zSensitivity = 1f;    // 高さの変化に対するZ座標の変化の感度

    public float minHeight = -1f;  // Z座標調整を適用する最小高さ (Body基準)
    public float maxHeight = 1f;   // Z座標調整を適用する最大高さ (Body基準)

    public float minZ = -1f;       // 最小Z座標
    public float maxZ = 1f;        // 最大Z座標

    private float initialBodyY;       // Bodyの初期Y座標

    void Start()
    {
        if (body == null)
        {
            Debug.LogError("Body Transformがアサインされていません！");
            enabled = false; // スクリプトを無効化
            return;
        }

        initialBodyY = body.position.y;
    }

    void Update()
    {
        if (body == null) return;

        float heightDifference = body.position.y - initialBodyY;
        float normalizedHeight;

        // 高さの変化を0～1の範囲に正規化
        if (heightDifference <= minHeight)
        {
            normalizedHeight = 0f;
        }
        else if (heightDifference >= maxHeight)
        {
            normalizedHeight = 1f;
        }
        else
        {
            normalizedHeight = Mathf.InverseLerp(minHeight, maxHeight, heightDifference);
        }

        // 正規化された高さに基づいてZ座標を計算
        float targetZ = Mathf.Lerp(minZ, maxZ, normalizedHeight);

        // オブジェクトのZ座標を設定
        transform.position = new Vector3(transform.position.x, transform.position.y, targetZ);
    }
}