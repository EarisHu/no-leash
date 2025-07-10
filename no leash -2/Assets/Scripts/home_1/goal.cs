using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour {
    public Sprite sprite1, sprite2; // 需在Inspector中赋值
    public float switchInterval = 0.5f; // 切换间隔（秒）
    public string targetScene; // 目标场景名（需在Build Settings中添加）
    public string collisionTag = "Player"; // 指定碰撞物体标签
    private SpriteRenderer renderer;
    private bool isSprite1 = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(collisionTag))
        {
            SceneManager.LoadScene(targetScene);
        }
    }
    void Start() {
        renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SwitchSprites());
    }

    IEnumerator SwitchSprites() {
        while (true) {
            renderer.sprite = isSprite1 ? sprite1 : sprite2;
            isSprite1 = !isSprite1;
            yield return new WaitForSeconds(switchInterval);
        }
    }
}