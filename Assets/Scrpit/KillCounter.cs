using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    static public int CountToKill;

    [Tooltip("количество врагов: 0 - min, 1 -max")]
    [SerializeField] private List<int> rangeCountSponw;

    private void Awake()
    {
        CountToKill = Random.Range(rangeCountSponw[0], rangeCountSponw[1]);
        print(CountToKill);
    }
}
