using UnityEngine;
using UnityEngine.UI;

public class BorderObjectController : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;
    public Camera mainCamera;

    public float showDistance = 5f;
    public float moveSmoothTime = 0.2f;
    public float fadeSpeed = 5f;

    public bool useUI = false;
    public bool useScreenSpaceClamp = true;
    public float screenCircleRadiusPixels = 200f;

    private SpriteRenderer spriteRenderer;
    private Image uiImage;
    private Canvas canvas;
    private Vector3 velocity = Vector3.zero;
    private float targetAlpha = 0f;

    void Start()
    {
        if (useUI)
        {
            uiImage = GetComponent<Image>();
            canvas = GetComponentInParent<Canvas>();
            Color c = uiImage.color;
            c.a = 0f;
            uiImage.color = c;
        }
        else
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            Color c = spriteRenderer.color;
            c.a = 0f;
            spriteRenderer.color = c;
        }
    }

    void Update()
    {
        if (targetB == null || targetA == null || mainCamera == null)
        {
            targetAlpha = 0f;
            UpdateAlpha();
            return;
        }

        float distance = Vector3.Distance(targetA.position, targetB.position);

        // 计算屏幕空间距离
        Vector3 screenCenter = mainCamera.WorldToScreenPoint(targetA.position);
        Vector3 screenPos = mainCamera.WorldToScreenPoint(targetB.position);
        float screenDist = Vector2.Distance(screenCenter, screenPos);

        // 隐藏条件：太近 或 太远
        if (screenDist < screenCircleRadiusPixels || distance > showDistance)
        {
            targetAlpha = 0f;
            UpdateAlpha();
            return;
        }

        targetAlpha = 1f;

        Vector3 clampedPos = useScreenSpaceClamp
            ? ClampToScreenCircle(targetB.position)
            : targetB.position;

        if (useUI)
        {
            Vector3 screenTarget = mainCamera.WorldToScreenPoint(clampedPos);
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform, screenTarget, canvas.worldCamera, out Vector2 localPoint))
            {
                transform.localPosition = Vector3.SmoothDamp(transform.localPosition, localPoint, ref velocity, moveSmoothTime);
            }
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, moveSmoothTime);
        }

        Vector3 direction = (targetB.position - targetA.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        UpdateAlpha();
    }

    private void UpdateAlpha()
    {
        if (useUI)
        {
            Color currentColor = uiImage.color;
            float newAlpha = Mathf.Lerp(currentColor.a, targetAlpha, Time.deltaTime * fadeSpeed);
            uiImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        }
        else
        {
            Color currentColor = spriteRenderer.color;
            float newAlpha = Mathf.Lerp(currentColor.a, targetAlpha, Time.deltaTime * fadeSpeed);
            spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        }
    }

    private Vector3 ClampToScreenCircle(Vector3 worldPos)
    {
        Vector3 screenCenter = mainCamera.WorldToScreenPoint(targetA.position);
        Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPos);

        Vector2 offset = new Vector2(screenPos.x - screenCenter.x, screenPos.y - screenCenter.y);

        if (offset.magnitude > screenCircleRadiusPixels)
        {
            offset = offset.normalized * screenCircleRadiusPixels;
        }

        Vector3 clampedScreenPos = new Vector3(screenCenter.x + offset.x, screenCenter.y + offset.y, screenPos.z);
        return mainCamera.ScreenToWorldPoint(clampedScreenPos);
    }
}