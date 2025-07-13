using UnityEngine;

public class Pop : MonoBehaviour
{
    [Header("距离设置")]
    public Transform targetObject;  // 检测的目标物体
    public float showDistance = 250f;
    
    [Header("跟随设置")] 
    public Transform followParent;  // 要跟随的父物体（如果不指定则用当前父物体）
    
    private SpriteRenderer spriteRenderer;
    private Vector3 originalLocalPos;  // 初始本地位置
    private Quaternion originalLocalRot; // 初始本地旋转

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        
        // 如果没有指定followParent，则使用当前的父物体
        if (followParent == null) 
        {
            followParent = transform.parent;
        }
        
        // 记录初始相对位置和旋转
        originalLocalPos = transform.localPosition;
        originalLocalRot = transform.localRotation;
    }

    void Update()
    {
        // 先更新位置和旋转（完全跟随父物体）
        if (followParent != null)
        {
            transform.position = followParent.position;
            transform.rotation = followParent.rotation;
            
            // 保持初始的相对位置和旋转
            transform.localPosition += originalLocalPos;
            transform.localRotation *= originalLocalRot;
        }

        // 距离检测和透明度控制
        if (targetObject == null)
        {
            spriteRenderer.enabled = false;
            return;
        }

        float distance = Vector3.Distance(transform.position, targetObject.position);
        bool shouldShow = distance <= showDistance;
        spriteRenderer.enabled = shouldShow;

        if (shouldShow)
        {
            float alpha = CalculateAlpha(distance);
            spriteRenderer.color = new Color(1, 1, 1, alpha);
        }
    }

    float CalculateAlpha(float distance)
    {
        if (distance <= 140f) return 1.0f - (distance / 140f) * 0.2f;
        else if (distance <= 170f) return 0.8f - Mathf.Pow((distance - 140f) / 30f, 0.5f) * 0.6f;
        else return 0.2f - (distance - 170f) / (showDistance - 170f) * 0.2f;
    }

    public void ResetVisibility()
    {
        spriteRenderer.enabled = true;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }
}