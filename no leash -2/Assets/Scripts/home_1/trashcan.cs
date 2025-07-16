using UnityEngine;

public class RandomSpawnOnCollision : MonoBehaviour
{
    [Header("预制体设置")]
    public GameObject[] spawnPrefabs; // 随机选择的预制体数组

    [Header("碰撞设置")]
    public bool isTrigger = false; // 是否为触发器碰撞
    public LayerMask collisionMask; // 可碰撞的层级
    private bool playerInRange = false;
    

    
    void Update()
    {
        // 检测玩家是否在范围内且按下了S键
        if (playerInRange && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("与物体交互");
            SpawnRandomPrefab();
            Destroy(gameObject);
        }
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // 检查是否为物理碰撞且层级匹配
    //     if (!isTrigger && CheckLayer(collision.gameObject.layer))
    //     {
    //         Debug.Log("111111");
    //             SpawnRandomPrefab();
    //             Destroy(gameObject);
    //     }
    // }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // // 检查是否为触发器碰撞且层级匹配
        // if (isTrigger && CheckLayer(other.gameObject.layer))
        // {
        //     Debug.Log("22222");
        //     if (Input.GetKey(KeyCode.S))
        //     {
        //         SpawnRandomPrefab();
        //         Destroy(gameObject);
        //     }
        // }
         if (other.CompareTag("dog"))
        {
            playerInRange = true;
            // 可以在这里显示提示UI，如"按S键交互"
            Debug.Log("进入交互范围");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("dog"))
        {
            playerInRange = false;
            // 可以在这里隐藏提示UI
            Debug.Log("离开交互范围");
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
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + 20f);
        GameObject newObject = Instantiate(
            prefabToSpawn,
            spawnPosition,
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