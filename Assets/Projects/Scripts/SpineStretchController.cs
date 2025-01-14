using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SpineStretchController : MonoBehaviour
{
    [Header("Target References")]
    [SerializeField] private Transform hipTracker;
    [SerializeField] private Transform headTracker;
    [SerializeField] private Transform spineTransform;
    
    [Header("Constraint Settings")]
    [SerializeField] private MultiPositionConstraint spineConstraint;
    [SerializeField] private float updateRate = 30f; // 更新頻度（1秒あたりの回数）
    
    [Header("Stretch Settings")]
    [SerializeField] private float minStretchMultiplier = 0.5f;
    [SerializeField] private float maxStretchMultiplier = 2f;
    [SerializeField] private bool maintainWidth = true; // 幅を維持するかどうか
    
    private float originalDistance;
    private Vector3 originalScale;
    private float updateTimer;
    
    private void Start()
    {
        if (!ValidateComponents()) return;
        
        // 初期距離と初期スケールを保存
        originalDistance = Vector3.Distance(hipTracker.position, headTracker.position);
        originalScale = spineTransform.localScale;
    }
    
    private void Update()
    {
        // 更新頻度に基づいて処理を実行
        updateTimer += Time.deltaTime;
        if (updateTimer >= 1f / updateRate)
        {
            UpdateSpineStretch();
            updateTimer = 0f;
        }
    }
    
    private void UpdateSpineStretch()
    {
        if (!ValidateComponents()) return;
        
        // 現在のHipとHeadTrackerの距離を計算
        float currentDistance = Vector3.Distance(hipTracker.position, headTracker.position);
        
        // スケール係数を計算（元の距離との比率）
        float stretchFactor = Mathf.Clamp(
            currentDistance / originalDistance,
            minStretchMultiplier,
            maxStretchMultiplier
        );
        
        // 新しいスケールを計算
        Vector3 newScale = originalScale;
        newScale.y *= stretchFactor;
        
        // 幅を維持する場合は、X/Zスケールを調整
        if (maintainWidth)
        {
            float widthScale = Mathf.Sqrt(1f / stretchFactor); // 体積を保持するような計算
            newScale.x *= widthScale;
            newScale.z *= widthScale;
        }
        
        // スケールを適用
        spineTransform.localScale = newScale;
        
        // MultiPositionConstraintのweightを更新（必要に応じて）
        UpdateConstraintWeights(stretchFactor);
    }
    
    private void UpdateConstraintWeights(float stretchFactor)
    {
        if (spineConstraint != null)
        {
            var data = spineConstraint.data;
            var sourceObjects = data.sourceObjects;
            
            // ストレッチ係数に基づいてウェイトを調整
            // 例：ストレッチが大きいほどHeadTrackerの影響を強く
            float hipWeight = Mathf.Lerp(0.7f, 0.3f, (stretchFactor - minStretchMultiplier) / (maxStretchMultiplier - minStretchMultiplier));
            float headWeight = 1f - hipWeight;
            
            sourceObjects.SetWeight(0, hipWeight);  // HipTrackerのウェイト
            sourceObjects.SetWeight(1, headWeight); // HeadTrackerのウェイト
            
            data.sourceObjects = sourceObjects;
            spineConstraint.data = data;
        }
    }
    
    private bool ValidateComponents()
    {
        bool isValid = hipTracker != null && headTracker != null && spineTransform != null;
        if (!isValid)
        {
            Debug.LogError("Required components are missing in SpineStretchController!");
        }
        return isValid;
    }
    
    // インスペクタでの設定を容易にするためのセットアップメソッド
    public void SetupConstraint(MultiPositionConstraint constraint)
    {
        spineConstraint = constraint;
        
        // 初期のConstraint設定
        var data = constraint.data;
        var sourceObjects = data.sourceObjects;
        
        // デフォルトのウェイトを設定
        sourceObjects.SetWeight(0, 0.7f); // HipTracker
        sourceObjects.SetWeight(1, 0.3f); // HeadTracker
        
        data.sourceObjects = sourceObjects;
        constraint.data = data;
    }
}