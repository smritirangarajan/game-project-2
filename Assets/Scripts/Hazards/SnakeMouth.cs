using UnityEngine;

public class SnakeMouth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something entered snake mouth: " + collision.name);

        GeckoController gecko = collision.GetComponent<GeckoController>();

        if (gecko != null)
        {
            Debug.Log("Gecko detected!");
            GameManager gm = FindFirstObjectByType<GameManager>();
            if (gm != null)
            {
                gm.GameOver();
            }
        }
    }
}