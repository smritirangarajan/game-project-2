using UnityEngine;

public class Tongue : MonoBehaviour
{
    [SerializeField] private float speed = 25f;
    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private float retractSpeed = 30f;

    private Vector2 direction;
    private Vector3 startPosition;
    private bool retracting = false;

    public void Initialize(Vector2 dir)
    {
        direction = dir.normalized;
        startPosition = transform.position;

        // Rotate to face direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Update()
    {
        if (!retracting)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            float distance = Vector2.Distance(startPosition, transform.position);

            if (distance >= maxDistance)
            {
                retracting = true;
            }
        }
        else
        {
            transform.Translate(-direction * retractSpeed * Time.deltaTime, Space.World);

            if (Vector2.Distance(startPosition, transform.position) <= 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin = collision.GetComponent<Coin>();
        if (coin != null)
        {
            coin.Collect();//得到了一个金币哦！
            retracting = true;
        }
    }
}