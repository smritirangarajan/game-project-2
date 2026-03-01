using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] private float despawnDistance = 10f;
    [SerializeField] private float fallSpeed = 1f;
    private Transform player;

    private void Start()
    {
        GeckoController gecko = FindFirstObjectByType<GeckoController>();
        if (gecko != null)
        {
            player = gecko.transform;
        }
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

    public void Collect()
    {
        GameManager gm = FindFirstObjectByType<GameManager>();
        if (gm != null)
        {
            gm.AddScore(1);
        }

        Destroy(gameObject);
    }
}