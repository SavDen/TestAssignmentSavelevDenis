using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpown : MonoBehaviour
{
    [Header("Spown Points")]
    [SerializeField] private List<Transform> points;

    [Header("Range Min&Max")]
    [Tooltip("время задержки спавна: 0 - min, 1 -max")]
    [SerializeField] private List<float> rangeSponw;

    private void Start ()
    {
        StartCoroutine("Spawn");
    }

    private void RandomEnemy()
    {
        var randomTypeEnemy = Random.Range(0, 1);
        var randomPoint = Random.Range(0 , points.Count);
        switch (randomTypeEnemy)
        {
            case (0):
                EnemyCreator creatorRed = new RedEnemyCreator();
                Enemy redEnemy = creatorRed.FactoryMethod(points[randomPoint]);
                break;
            case (1):
                EnemyCreator creatorBlue= new BlueEnemyCreator();
                Enemy blueEnemy = creatorBlue.FactoryMethod(points[randomPoint]);
                break;
        }

    }

    IEnumerator Spawn()
    {
        while(true)
        {
            var randomRangeSpownDelay = Random.Range(rangeSponw[0], rangeSponw[1]);

            yield return new WaitForSeconds(randomRangeSpownDelay);
            RandomEnemy();
        }

    }

}
