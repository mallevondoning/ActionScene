using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public List<EnemyController> EnemyList { get; set; } = new List<EnemyController>();

    private void Awake()
    {
        Instance = this;
    }

    public void StopGame()
    {
        foreach (var item in EnemyList)
        {
            item.StopAllCoroutines();
        }
    }
}
