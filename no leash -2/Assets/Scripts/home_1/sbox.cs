using UnityEngine;

public class HideAndSpawnOnCollision2D : MonoBehaviour
{
    [Tooltip("需要匹配的碰撞物体标签（留空则所有碰撞都触发）")]
    public string targetTag = "";

    [Tooltip("隐藏方式：禁用物体或仅禁用渲染器")]
    public HideMethod hideMethod = HideMethod.DisableObject;
    public enum HideMethod { DisableObject, DisableRenderer }

    [Header("生成新预制体配置")]
    [Tooltip("待生成的预制体名称（需放在Resources文件夹）")]
    public string spawnPrefabName = "elec";
    [Tooltip("生成位置偏移量")]
    public Vector3 spawnOffset = Vector3.zero;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查标签匹配条件
        if (!string.IsNullOrEmpty(targetTag) && !collision.gameObject.CompareTag(targetTag)) 
            return;

        // 隐藏或销毁当前物体
        switch (hideMethod)
        {
            case HideMethod.DisableObject:
                SpawnNewPrefab(); // 先生成新物体
                gameObject.SetActive(false); // 再隐藏自身
                break;
            case HideMethod.DisableRenderer:
                GetComponent<Renderer>().enabled = false;
                SpawnNewPrefab();
                break;
        }
    }

    // 生成新预制体
    private void SpawnNewPrefab()
    {
        // 动态加载预制体资源
        GameObject elecPrefab = Resources.Load<GameObject>(spawnPrefabName);
        if (elecPrefab != null)
        {
            // 计算生成位置（当前物体位置 + 偏移量）
            Vector3 spawnPos = transform.position + spawnOffset;
            // 实例化预制体
            Instantiate(elecPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Debug.LogError($"预制体 {spawnPrefabName} 加载失败！请检查Resources路径");
        }
    }

    // 重新显示物体（可选）
    public void ResetObject()
    {
        gameObject.SetActive(true);
        if (TryGetComponent<Renderer>(out var renderer))
            renderer.enabled = true;
    }
}