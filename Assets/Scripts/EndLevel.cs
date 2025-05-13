using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ColliderCheck))]
public class EndLevel : MonoBehaviour
{
    
    public string NextSceneName;
    
    private ColliderCheck _colliderCheck;
    
    private void Awake()
    {
        _colliderCheck = GetComponent<ColliderCheck>();
    }

    private void Update()
    {
        if (_colliderCheck.IsCheck)
            SceneManager.LoadScene(NextSceneName);
    }
}
