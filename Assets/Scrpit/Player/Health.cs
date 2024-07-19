using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Text textCount;
    [SerializeField] private int health;

    private void OnEnable()
    {
        EventSystem.DamagePlayer += Damage;
    }

    private void OnDisable()
    {
        EventSystem.DamagePlayer -= Damage;

    }
    private void Awake()
    {
        textCount.text = health.ToString();
    }
    private void Damage()
    {
        health--;
        UpdateUI();

        if(health <= 0)
        {
            Dead();
        }
    }

    private void UpdateUI()
    {
        textCount.text = health.ToString();
    }

    private void Dead()
    {
        EventSystem.DeadPlayer?.Invoke();
        Destroy(gameObject);
    }

}
