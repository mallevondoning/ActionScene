using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyList;

    float timeCheck;

    void Awake()
    {
        Instantiate(_enemyPrefab, _enemyList.transform);
    }

    void Update()
    {
        if (DataManager.IsPlaying)
        {
            if (timeCheck >= 5f)
            {
                EnemyController checkEC = Instantiate(_enemyPrefab, _enemyList.transform).GetComponent<EnemyController>();
                GameManager.Instance.EnemyList.Add(checkEC);
                timeCheck = 0f;
            }

            timeCheck += Time.deltaTime;
        }
    }
}
