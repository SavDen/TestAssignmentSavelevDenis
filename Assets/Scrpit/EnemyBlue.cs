using UnityEngine;

public class EnemyBlue : Enemy
{
    public override void ColorEnemy()
    {
        material.color = Color.blue;
        print("Создался синий враг");
    }
}
