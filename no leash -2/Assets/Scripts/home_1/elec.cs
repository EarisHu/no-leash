using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [Tooltip("物体生成后的存活时间（秒）")]
    public float lifetime = 2f;  // 默认2秒后销毁

    void Start()
    {
        // 直接调用延迟销毁方法（最简洁的实现）
        Destroy(gameObject, lifetime);
    }

    // 可选：扩展方法支持动态修改销毁时间
    public void SetLifetime(float newTime)
    {
        CancelInvoke(nameof(DestroySelf));  // 取消之前的销毁调用
        lifetime = newTime;
        Invoke(nameof(DestroySelf), lifetime);  // 重新设置销毁定时
    }

    private void DestroySelf()
    {
        if (this != null && gameObject != null) 
        {
            Destroy(gameObject);
        }
    }

    // 安全销毁验证（防止空引用）
    void OnDestroy()
    {
        CancelInvoke();  // 确保所有待执行调用被清除
    }
}