using UnityEngine;

/// <summary>
/// Gecko movement + tongue shooting.
/// - Left / Right movement
/// - Hold UpArrow to climb
/// - Slip temporarily when hitting puddle
/// - Shoot tongue upward toward mouse
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class GeckoController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float climbSpeed = 6f;
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float gravityScale = 2f;

    [Header("Slip Settings")]
    [SerializeField] private float slipForce = 18f;
    [SerializeField] private float slipDuration = 1f;

    [Header("Tongue")]
    [SerializeField] private GameObject tonguePrefab;
    [SerializeField] private Transform tongueSpawnPoint;

    private Rigidbody2D rb;

    private bool isSlipping = false;
    private float slipTimer = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    private void Update()
    {
        HandleSlipTimer();
        HandleMovement();
        HandleTongue();
        CheckFallDeath();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        bool climbing = Input.GetKey(KeyCode.UpArrow);

        float verticalVelocity = rb.linearVelocity.y;

        if (isSlipping)
        {
            // Hard downward override
            verticalVelocity = -slipForce;
        }
        else if (climbing)
        {
            verticalVelocity = climbSpeed;
        }

        rb.linearVelocity = new Vector2(horizontalInput * horizontalSpeed, verticalVelocity);
    }

    private void HandleSlipTimer()
    {
        if (!isSlipping) return;

        slipTimer -= Time.deltaTime;

        if (slipTimer <= 0f)
        {
            isSlipping = false;
        }
    }

    public void TriggerSlip()
    {
        isSlipping = true;
        slipTimer = slipDuration;
    }

    private void HandleTongue()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootTongue();
        }
    }

    private void ShootTongue()
    {
        if (tonguePrefab == null || tongueSpawnPoint == null) return;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        Vector2 direction = mouseWorld - tongueSpawnPoint.position;

        // Only allow upward shots
        if (direction.y <= 0f)
            return;

        direction.Normalize();

        GameObject tongue = Instantiate(
            tonguePrefab,
            tongueSpawnPoint.position,
            Quaternion.identity
        );

        tongue.GetComponent<Tongue>().Initialize(direction);
    }

    private void CheckFallDeath()
    {
        if (transform.position.y < -8f)
        {
            GameManager gm = FindFirstObjectByType<GameManager>();
            if (gm != null)
            {
                gm.GameOver();
            }
        }
    }
}