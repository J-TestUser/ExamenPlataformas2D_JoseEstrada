using UnityEngine;

public class Coin : MonoBehaviour
{

    private CircleCollider2D _collider2D;
    private SpriteRenderer _renderer;

    void Awake()
    {
        _collider2D = GetComponent<CircleCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddCoin();
            _collider2D.enabled = false;
            _renderer.enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
