using UnityEngine;

public class BlueEnemyCreator : EnemyCreator
{
    public override Enemy FactoryMethod(Transform pointSpown)
    {
        var prefab = Resources.Load<GameObject>("EnemyBlue");
        var go = GameObject.Instantiate(prefab, pointSpown);
        var enemyComponent = go.GetComponent<EnemyBlue>();
        return enemyComponent;
    }
}
