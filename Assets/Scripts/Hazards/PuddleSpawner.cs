using UnityEngine;

public class PuddleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject puddlePrefab;
    [SerializeField] private Transform player;

    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnHeightOffset = 7f;
    [SerializeField] private float horizontalRange = 4f;

    private float timer = 0f;

    private void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPuddle();
            timer = 0f;
        }
    }

    private void SpawnPuddle()
    {
        float randomX = Random.Range(-horizontalRange, horizontalRange);

        Vector3 spawnPosition = new Vector3(
            randomX,
            player.position.y + spawnHeightOffset,
            0f
        );

        Instantiate(puddlePrefab, spawnPosition, Quaternion.identity);
    }
}