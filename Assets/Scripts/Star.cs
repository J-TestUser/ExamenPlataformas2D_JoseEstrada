using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
     
}
