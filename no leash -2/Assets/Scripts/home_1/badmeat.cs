using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class Badmeat : MonoBehaviour
{
    [Header("距离设置")]
    public Transform targetObject;
    public float showDistance;

    [Header("碰撞设置")]
    public bool disappearWhenCollided = true;
    public bool useTrigger = true;

    private SpriteRenderer spriteRenderer;
    private Collider2D objectCollider;
    private bool isHiddenByCollision = false;

    void Awake()
    {
        showDistance = 50f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<Collider2D>();
        objectCollider.isTrigger = useTrigger;
        spriteRenderer.enabled = false;
        
        // 新增代码：自动查找dog对象
        if (targetObject == null)
        {
            GameObject dog = GameObject.Find("dog1");
            if (dog != null)
            {
                targetObject = dog.transform;
            }
            else
            {
                Debug.LogWarning("未找到名为'dog1'的游戏对象");
            }
        }
    }
    
    void Update()
    {
        // 保持原有代码不变
        if (targetObject == null || isHiddenByCollision) return;

        float distance = Vector3.Distance(transform.position, targetObject.position);
        bool shouldShow = distance <= showDistance;

        if (spriteRenderer.enabled != shouldShow)
        {
            spriteRenderer.enabled = shouldShow;
        }
    }

    // 以下方法保持不变...
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!useTrigger && disappearWhenCollided && collision.gameObject.transform == targetObject)
        {
            HandleDisappearance();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (useTrigger && disappearWhenCollided && other.transform == targetObject)
        {
            HandleDisappearance();
        }
    }

    private void HandleDisappearance()
    {
        Destroy(gameObject);
    }

    public void ResetVisibility()
    {
        isHiddenByCollision = false;
        spriteRenderer.enabled = true;
        objectCollider.enabled = true;
    }
}