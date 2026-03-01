using UnityEngine;

public class Puddle : MonoBehaviour
{
    private Transform player;
    private float despawnDistance = 12f;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GeckoController gecko = collision.GetComponent<GeckoController>();
        if (gecko != null)
        {
            gecko.TriggerSlip();
        }
    }
}