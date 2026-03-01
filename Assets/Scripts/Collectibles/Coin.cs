using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Despawn")]
    [SerializeField] private float despawnDistance = 10f;

    [Header("Pulse Animation")]
    [SerializeField] private float pulseSpeed = 4f;
    [SerializeField] private float pulseAmount = 0.02f;

    [Header("Optional Spin")]
    [SerializeField] private bool rotate = true;
    [SerializeField] private float rotationSpeed = 120f;

    private Transform player;
    private Vector3 originalScale;

    private void Start()
    {
        GeckoController gecko = FindFirstObjectByType<GeckoController>();
        if (gecko != null)
        {
            player = gecko.transform;
        }

        originalScale = transform.localScale;
    }

    private void Update()
    {
        HandlePulse();
        HandleRotation();
        HandleDespawn();
    }

    private void HandlePulse()
    {
        float scaleOffset = Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = originalScale + Vector3.one * scaleOffset;
    }

    private void HandleRotation()
    {
        if (!rotate) return;

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void HandleDespawn()
    {
        if (player == null) return;

        if (transform.position.y < player.position.y - despawnDistance)
        {
            Destroy(gameObject);
        }
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