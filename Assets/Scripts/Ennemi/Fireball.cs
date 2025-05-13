using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public float LifeTime = 2f;

    private Vector2 direction;

    void Start()
    {
        direction = transform.right.normalized;
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime));
    } 
}
