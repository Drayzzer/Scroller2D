using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    public void Die()
    {
        Invoke("RestartLevel", 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallDetector"))
        {
           Die();
        }
    }}
