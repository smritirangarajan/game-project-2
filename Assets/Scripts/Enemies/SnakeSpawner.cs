using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject snakePrefab;
    [SerializeField] private Transform player;

    [SerializeField] private float spawnInterval = 6f;
    [SerializeField] private float spawnHeightOffset = 8f;

    private float timer;

    private void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnSnake();
            timer = 0f;
        }
    }
    private void SpawnSnake()
    {
        Camera cam = Camera.main;

        float cameraTop =
            cam.transform.position.y + cam.orthographicSize;

        float spawnY = cameraTop + 2f; // 2 units above visible screen

        float randomX = Random.Range(-2f, 2f);

        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        Instantiate(snakePrefab, spawnPosition, Quaternion.identity);
    }
}