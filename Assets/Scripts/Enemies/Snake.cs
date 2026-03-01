using UnityEngine;

public class Snake : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float despawnDistance = 12f;
    [SerializeField] private float fallSpeed = 3f;

    private void Start()
    {
        player = FindFirstObjectByType<GeckoController>()?.transform;
    }

    private void Update()
    {
        if (player == null) return;

        if (transform.position.y < player.position.y - despawnDistance)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);//按时间固定下降。
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GeckoController gecko = collision.GetComponent<GeckoController>();

        if (gecko != null)
        {
            FindFirstObjectByType<GameManager>()?.GameOver();
        }
    }
}