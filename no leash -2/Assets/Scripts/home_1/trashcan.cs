using UnityEngine;

public class RandomSpawnOnCollision : MonoBehaviour
{
    [Header("预制体设置")]
    public GameObject[] spawnPrefabs; // 随机选择的预制体数组

    [Header("碰撞设置")]
    public bool isTrigger = false; // 是否为触发器碰撞
    public LayerMask collisionMask; // 可碰撞的层级

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查是否为物理碰撞且层级匹配
        if (!isTrigger && CheckLayer(collision.gameObject.layer))
        {
            SpawnRandomPrefab();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否为触发器碰撞且层级匹配
        if (isTrigger && CheckLayer(other.gameObject.layer))
        {
            SpawnRandomPrefab();
            Destroy(gameObject);
        }
    }

    private void SpawnRandomPrefab()
    {
        if (spawnPrefabs.Length == 0)
        {
            Debug.LogError("未分配预制体！", this);
            return;
        }

        // 随机选择预制体
        GameObject prefabToSpawn = spawnPrefabs[Random.Range(0, spawnPrefabs.Length)];
        
        // 实例化预制体
        GameObject newObject = Instantiate(
            prefabToSpawn, 
            transform.position, 
            transform.rotation
        );
        
        Debug.Log($"生成新物体: {newObject.name}");
    }

    private bool CheckLayer(int layer)
    {
        // 使用位运算检查层级是否在碰撞掩码中
        return collisionMask == (collisionMask | (1 << layer));
    }
}