using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Drag your spawnpoint here")]
    public Transform spawnPoint;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Respawn if we hit Ground/Ceiling (Hazard) or an Enemy
        if (collision.collider.CompareTag("Hazard") || collision.collider.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Stop motion so we don't instantly re-collide
#if UNITY_6000_0_OR_NEWER
        rb.linearVelocity = Vector2.zero;
#else
        rb.velocity = Vector2.zero;
#endif
        rb.angularVelocity = 0f;

        // Move to spawn
        if (spawnPoint != null)
            transform.position = spawnPoint.position;
        else
            Debug.LogWarning("SpawnPoint not assigned on PlayerRespawn!");
    }
}