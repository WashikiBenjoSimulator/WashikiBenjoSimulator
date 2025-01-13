using UnityEngine;

public class FollowGroundSimple : MonoBehaviour
{
    public Transform body;          // レイキャストの基準となるBody Transform
    public float raycastDistance = 1.5f; // レイキャストを飛ばす距離
    public LayerMask groundLayer;       // 地面として認識するレイヤー
    public float yOffset = 0f;          // 地面からのY軸オフセット

    void Update()
    {
        if (body == null)
        {
            Debug.LogError("Body Transformがアサインされていません！");
            return;
        }

        // Bodyの位置から真下へレイを飛ばす
        Ray ray = new Ray(body.position, Vector3.down);
        RaycastHit hit;

        // レイが地面に衝突した場合
        if (Physics.Raycast(ray, out hit, raycastDistance, groundLayer))
        {
            // オブジェクトのY座標を地面のY座標 + オフセットに設定する
            transform.position = new Vector3(transform.position.x, hit.point.y + yOffset, transform.position.z);
        }
    }
}