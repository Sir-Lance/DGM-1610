using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int enemies;

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemiesMBT = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = enemiesMBT.Length;
    }

}
