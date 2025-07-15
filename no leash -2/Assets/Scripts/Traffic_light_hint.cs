using UnityEngine;

public class Traffic_light_hint: MonoBehaviour
{
    [Tooltip("拖拽需要监测的物体到此字段")]
    public GameObject targetObject; // 需要监测的外部物体
    
    [Tooltip("当目标物体的X坐标超过此值时，当前物体会显示")]
    public float triggerXValue;

    private bool hasShown = false; // 防止重复触发

    void Start()
    {
        // 初始隐藏自身[1,4](@ref)
        gameObject.SetActive(false);
    }

    void Update()
    {
        // 检查目标物体是否有效
        if (targetObject == null)
        {
            Debug.LogWarning("目标物体未指定！", this);
            return;
        }

        // 若未触发过且目标X超过阈值
        if (!hasShown && targetObject.transform.position.x > triggerXValue)
        {
            // 显示当前物体[1,4](@ref)
            gameObject.SetActive(true);
            hasShown = true; // 标记已触发
        }
    }
}