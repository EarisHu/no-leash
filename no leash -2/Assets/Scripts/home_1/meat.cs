using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class DistanceBasedVisibility : MonoBehaviour
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
    }
    
    void Update()
    {
        if (targetObject == null || isHiddenByCollision) return;

        float distance = Vector3.Distance(transform.position, targetObject.position);
        bool shouldShow = distance <= showDistance;

        if (spriteRenderer.enabled != shouldShow)
        {
            spriteRenderer.enabled = shouldShow;
        }
    }

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
        // 直接销毁对象而不是隐藏
        Destroy(gameObject);
    }

    public void ResetVisibility()
    {
        isHiddenByCollision = false;
        spriteRenderer.enabled = true;
        objectCollider.enabled = true;
    }

    void OnDrawGizmosSelected()
    {
        if (targetObject != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, targetObject.position);
            Gizmos.DrawWireSphere(transform.position, showDistance);
        }
    }
}