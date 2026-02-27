using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval = 1f;
    private float initialSpawnInterval;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private Transform[] spawnPoints;

    private float timer;
    private float elapsed;
    [SerializeField] private float minInterval = 0.1f;

    void Update()
    {
        float dt = Time.deltaTime;
        timer += dt;
        elapsed += dt;

        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (sceneName != "Level_3")
        {
            if (elapsed >= 3f)
            {
                elapsed -= 3f;
                float minAllowed = Mathf.Max(minInterval, initialSpawnInterval - 1f);
                spawnInterval = Mathf.Max(minAllowed, spawnInterval - 0.02f);
            }
            initialSpawnInterval = spawnInterval;
        }

        if (timer >= spawnInterval)
        {
            timer = 0f;
            ShootAtPlayer();
        }
    }

    void ShootAtPlayer()
    {
        if (projectilePrefab == null || player == null || spawnPoints == null || spawnPoints.Length == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Vector2 direction = (player.position - spawnPoint.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject proj = Instantiate(projectilePrefab, spawnPoint.position, rotation);

        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        float speed = projectileSpeed;

        if (sceneName == "Level_2")
        {
            proj.transform.localScale *= 2f;
        }
        else if (sceneName == "Level_3")
        {
            if (Random.value < 0.3f)
            {
                speed *= 2f;
            }
            else
            {
                proj.transform.localScale *= 2f;
            }
        }

        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
        }
    }
}
