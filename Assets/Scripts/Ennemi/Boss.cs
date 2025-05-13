using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float visionRange = 10f;
    public float firecooldown = 2f;
    public float nextFireTime = 0f;
    
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;
        
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= visionRange && Time.time >= nextFireTime)
        {
            ShootAtPlayer();
            nextFireTime = Time.time + firecooldown;
        }
    }

    void ShootAtPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * 10f;
    }
}
