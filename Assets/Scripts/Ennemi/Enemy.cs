using UnityEngine;

public class Enemy : MonoBehaviour
{
       public int maxHealth = 3;
       public int currentHealth;
       public HealthBar healthBar;
       
       private Collider2D _collider;
       private Animator _animator;
       
       public void TakeDamage(int damage)
       {
              currentHealth -= damage;
              healthBar.SetHealth(currentHealth);
              if (currentHealth <= 0)
              {
                     Destroy(gameObject);
              }
       }
       private void Start()
       {
              currentHealth = maxHealth;
              healthBar.SetMaxHealth(maxHealth);
              _animator = GetComponent<Animator>();
       }
       private void OnTriggerEnter2D(Collider2D collision)
       {
              if (collision.CompareTag("Player"))
              {
                     TakeDamage(1);
              }
       }
}