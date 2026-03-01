using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform player;

    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float spawnHeightOffset = 6f;
    [SerializeField] private float horizontalRange = 4f;

    private float timer = 0f;

    private void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    private void SpawnCoin()
    {
        float randomX = Random.Range(-horizontalRange, horizontalRange);

        Vector3 spawnPosition = new Vector3(
            randomX,
            player.position.y + spawnHeightOffset,
            0f
        );

        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}