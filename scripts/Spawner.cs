using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;//存放敌人
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, 1);//
    }

    void SpawnEnemy()//产生敌人
    {
        int index = Random.Range(0, 1);//随机产生
        Instantiate(enemies[index], transform.position, transform.localRotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
