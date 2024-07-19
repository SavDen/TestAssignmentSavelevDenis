using UnityEngine;

public class EnemyRed : Enemy
{
    public override void ColorEnemy()
    {
        material.color = Color.red;
        print("Создался красный враг");
    }
}
