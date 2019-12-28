using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpawn,  enemyChoose;
    public int enemyCount;
    public GameObject Enemy1, Enemy2, EnemyBig;
    public GameObject enemyClone;
    public GameObject EnemySpawn;
    public Vector3 EnPos;
    public Transform Batya;
    internal static bool StartFight;
    public GameObject Dver;
    internal static int DoorOpen;
    public GameObject thisF;
    void Start()
    {
        EnPos = new Vector3(transform.position.x,transform.position.y,5);
        StartFight = false;
        enemyCount = Random.Range(3, 6);
        DoorOpen = enemyCount;
    }

    private void SpawnEnemies()
    {
        
        if (enemyCount > 0)
        {
            EnPos = new Vector3(transform.position.x + Random.Range(-7, 7), transform.position.y + Random.Range(-7, 7), 5);
            enemyChoose = Random.Range(1, 101);
            if (enemyChoose < 10) enemyClone = EnemyBig;
            if (enemyChoose >= 10 && enemyChoose <= 55) { enemyClone = Enemy1; }
            if (enemyChoose > 55) { enemyClone = Enemy2; }
            Debug.Log(enemyChoose);
            EnemySpawn = Instantiate(enemyClone, EnPos, Quaternion.identity,transform);
            
            enemyCount -= 1;
            Debug.Log(enemyCount);
        }
        if (enemyCount == 0)
        {
            StartFight = false;
            
        }
    }
    public void OpenDoor()
    {
        Dver.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void FixedUpdate()
    {
        if (StartFight == true)
        {
            SpawnEnemies();
        }
        if (DoorOpen == 0)
        {
            Dver.SetActive(false);
            enemyCount = Random.Range(3, 6);
            thisF.SetActive(false);
        }
    }
}
