using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float speed;
    protected SpriteRenderer material;
    private float healt;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>();
        healt = maxHealth;
        ColorEnemy();
    }


    public abstract void ColorEnemy();
}
