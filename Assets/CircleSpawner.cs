using UnityEngine;


public class CircleSpawner : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public GameObject circlePrefab;

    [Header("First Circle (Fixed Points)")]
    public float firstCircleOffsetY = 1f;
    public float firstCircleX = 1f;

    [Header("Next Circles")]
    public float minX = -2.3f;
    public float maxX = 2.3f;

    public float minYGap = 2f;
    public float maxYGap = 3f;

    private float lastSpawnY;
    private bool firstCircleSpawned;

    void Start()
    {
        if (player == null || circlePrefab == null)
            return;
        SpawnFirstCircle();
    }

    void Update()
    {
        if (!firstCircleSpawned) return;

        if (player.position.y + 4f > lastSpawnY)
        {
            SpawnNextCircle();
        }
    }

    void SpawnFirstCircle()
    {

        float fixedXLeft = -0.5f;
        float fixedXRight = 0.5f;

        float x = Random.value < 0.5f ? fixedXLeft : fixedXRight;
        float y = player.position.y + firstCircleOffsetY;

        Vector2 spawnPos = new Vector2(x, y);
        Instantiate(circlePrefab, spawnPos, Quaternion.identity);

        lastSpawnY = y;
        firstCircleSpawned = true;
    }


    void SpawnNextCircle()
    {
        float x = Random.Range(minX, maxX);
        float yGap = Random.Range(minYGap, maxYGap);

        lastSpawnY += yGap;
        Vector2 spawnPos = new Vector2(x, lastSpawnY);

        Instantiate(circlePrefab, spawnPos, Quaternion.identity);
    }
}
