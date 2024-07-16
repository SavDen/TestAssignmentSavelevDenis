using UnityEngine;

public class RedEnemyCreator : EnemyCreator
{
    public override Enemy FactoryMethod(Transform pointSpown)
    {
        var prefab = Resources.Load<GameObject>("EnemyRed");
        var go = GameObject.Instantiate(prefab, pointSpown);
        var enemyComponent = go.GetComponent<EnemyRed>();
        return enemyComponent;
    }
}
