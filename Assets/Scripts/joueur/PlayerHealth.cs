using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;
    private Animator _animator;

    // me permet de rajouter une variable pour que je puisse controler l'animation de degats
    private bool isDamaged = false;
    private bool isDead = false;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        if (isDead) return;
        if (isDamaged) return;
        
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        _animator.SetTrigger("Damage");
        isDamaged = true;
        StartCoroutine(ResetDamageState());
        
        if (currentHealth <= 0 && !isDead)
        {
            Die();
            
        }
    }

    private IEnumerator ResetDamageState()
    {
        yield return new WaitForSeconds(0.3f);
        
        isDamaged = false;
    }
    public void Die()
    {
        if (isDead) return;
        isDamaged = true;
        _animator.SetBool("Death", true);
        Invoke("RestartLevel", 5);
    }
    public void RestartLevel()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemy"))
        {
            TakeDamage(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            TakeDamage(1);
        }
    }
}