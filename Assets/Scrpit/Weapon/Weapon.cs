using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrewab;
    [SerializeField] private float _delayFire;
    [SerializeField] private Transform _pointBullet;
    [SerializeField] private List<Transform> _enemy = new List<Transform>();

    private CircleCollider2D circleCollider2D;

    private float _privateDelayFire;
    private bool _fire;

    private void Awake()
    {
        _privateDelayFire = _delayFire;
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (_enemy.Count != 0)
        {
            CheackListEnemyNull();
            NearestEnemy();
            DelayFire();

            if(_fire)
            {
                Fire();
            }
        }
    }

    public void Fire()
    {
        Instantiate(BulletPrewab, _pointBullet.position, transform.rotation);

        _privateDelayFire = _delayFire;
        _fire = false;

    }

    private void DelayFire()
    {
        _privateDelayFire -= Time.deltaTime;

        if (_privateDelayFire <= 0)
        {
            _fire = true;
        }

    }

    public void NearestEnemy()
    {
        float minDistanse = Mathf.Infinity;
        float curDistance = 0;
        Vector2 position = transform.position;
        int nearestEnemy = 0;

        for(int i =0; i<_enemy.Count; i++)
        {
            curDistance = Vector2.Distance(position, _enemy[i].position);

            if(curDistance < minDistanse)
            {
                minDistanse = curDistance;
                nearestEnemy = i;
            }
        }

        if (_enemy.Count > 0)
        {
            RotateToEnemy(nearestEnemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy component))
        {
            _enemy.Add(component.transform);
            
        }
    }

    private void CheackListEnemyNull()
    {
        for (int i = 0; i < _enemy.Count; i++)
        {
            if (_enemy[i] == null)
            {
                _enemy.RemoveAt(i);
            }
        }

    }

    private void RotateToEnemy(int nearEnemy)
    {
        Vector2 direction = _enemy[nearEnemy].position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
