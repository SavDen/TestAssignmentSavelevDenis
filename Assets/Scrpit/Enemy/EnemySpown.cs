using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpown : MonoBehaviour
{
    [Header("Spown Points")]
    [SerializeField] private List<Transform> points;

    [Header("Range Min&Max")]
    [Tooltip("время задержки спавна: 0 - min, 1 -max")]
    [SerializeField] private List<float> rangeTimeSponw;
    [Tooltip("количество врагов: 0 - min, 1 -max")]
    [SerializeField] private List<int> rangeCountSponw;

    private void Start ()
    {
        StartCoroutine("Spawn");
    }

    private void RandomEnemy()
    {
        var randomTypeEnemy = Random.Range(0, 2);
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
        int maxCountEnemy = Random.Range(rangeCountSponw[0], rangeCountSponw[1]);
        int currentCountEnemy = 0;

        while(currentCountEnemy < maxCountEnemy)
        {
            var randomRangeSpownDelay = Random.Range(rangeTimeSponw[0], rangeTimeSponw[1]);

            yield return new WaitForSeconds(randomRangeSpownDelay);
            RandomEnemy();
            currentCountEnemy++;
        }

        StopAllCoroutines();

    }

}
