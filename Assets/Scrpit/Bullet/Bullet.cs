using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int damage;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigidbody2D.velocity = transform.right * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<Enemy>(out Enemy component))
        {
            EventSystem.DamageEnemy?.Invoke(damage);
            Destroy(gameObject);
        }
    }
}
