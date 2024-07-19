using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float[] _speedRange;

    protected SpriteRenderer material;

    private Rigidbody2D _rigidbody2D;
    private int _healt;
    private float _speed;

    private void OnEnable()
    {
        EventSystem.DeadPlayer += Dead;
        EventSystem.WinPlayer += Dead;
    }

    private void OnDisable()
    {
        EventSystem.DeadPlayer -= Dead;
        EventSystem.WinPlayer -= Dead;
    }

    private void Awake()
    {
        _healt = _maxHealth;
        _speed = SpeedRange;

        material = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        ColorEnemy();
    }

    private float SpeedRange => Random.Range(_speedRange[0], _speedRange[1]);

    public abstract void ColorEnemy();

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        _rigidbody2D.velocity = Vector2.down * _speed;
    }

    public void TakeDamage(int damage)
    {
        _healt -= damage;

        if (_healt <= 0)
        {
            EventSystem.DeadEnemy?.Invoke();
            Dead();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.transform.TryGetComponent<Bullet>(out Bullet bullet))
        {
            EventSystem.DamagePlayer?.Invoke();
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

}
