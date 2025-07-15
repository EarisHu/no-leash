using UnityEngine;
using UnityEngine.UI;

public class PositionProgressBar : MonoBehaviour
{
    [Header("绑定设置")]
    public Slider progressSlider; // 进度条Slider组件
    public Transform targetObject; // 要跟踪的目标物体（如玩家）
    
    [Header("地图边界")]
    public float leftBoundary = -10f; // 地图左边界X坐标
    public float rightBoundary = 10f; // 地图右边界X坐标
    
    [Header("平滑设置")]
    public bool useSmoothTransition = true; // 是否启用平滑过渡
    [Range(1f, 10f)] public float smoothSpeed = 3f; // 平滑过渡速度

    private float _currentProgress; // 当前进度值（用于平滑过渡）

    void Start()
    {
        // 验证组件绑定
        if (progressSlider == null)
            progressSlider = GetComponent<Slider>();
        
        // 初始化进度条范围
        progressSlider.minValue = 0f;
        progressSlider.maxValue = 1f;
        
        // 初始化当前进度
        _currentProgress = CalculateTargetProgress();
    }

    void Update()
    {
        float targetProgress = CalculateTargetProgress();
        
        if (useSmoothTransition)
        {
            // 使用平滑过渡效果
            _currentProgress = Mathf.MoveTowards(
                _currentProgress,
                targetProgress,
                smoothSpeed * Time.deltaTime
            );
            progressSlider.value = _currentProgress;
        }
        else
        {
            // 直接设置进度值
            progressSlider.value = targetProgress;
        }
    }

    // 计算目标进度比例 (0-1之间)
    private float CalculateTargetProgress()
    {
        // 获取目标物体X坐标并计算相对于边界的位置比例
        float targetX = targetObject.position.x;
        float progress = (targetX - leftBoundary) / (rightBoundary - leftBoundary);
        
        // 限制在0-1范围内
        return Mathf.Clamp01(progress);
    }

    // 在编辑器中可视化边界（调试用）
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(leftBoundary, -100), new Vector3(leftBoundary, 100));
        Gizmos.DrawLine(new Vector3(rightBoundary, -100), new Vector3(rightBoundary, 100));
    }
}