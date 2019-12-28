using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public List<GameObject> doors;
    public List<GameObject> enemies;
    private float EnemyRng;
    public bool doorsAllow;
    public Animator animdoors;

    public float halfVis;
    public float halfShir;
    public int EnemyCountMin;
    public int EnemyCountMax;
   internal static int EnemyCountReal;

    public Vector3 EnemySpawnPoint;
    private GameObject EnemyClone;
    public GameObject EnemySpawner;

    private bool SpawnAllow;
    void Start()
    {
        SpawnAllow = true;
        EnemyCountReal = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < doors.Count; i++)
            {
                animdoors = doors[i].GetComponent<Animator>();
                animdoors.SetInteger("hui", 2);
            }
            SpawnAllow = true;
            EnemySpawner.SetActive(true);
            if (SpawnAllow == true) EnemySpawn();
            doorsAllow = true;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }
    public void EnemyChoose()
    {
        EnemyRng = Random.Range(1, 20);
        if (EnemyRng <= 10) EnemyClone = enemies[0];
        else EnemyClone = enemies[1];
    }
    public void EnemySpawn()
    {
        
        EnemyCountReal = Random.Range(EnemyCountMin, EnemyCountMax);
        for (int i = 0; i < EnemyCountReal; i++)
        {
            EnemyChoose();
            EnemySpawnPoint = new Vector3(Random.Range(-halfShir, halfShir), Random.Range(-halfVis, halfVis),0);
            Instantiate(EnemyClone, EnemySpawner.transform.position+EnemySpawnPoint,Quaternion.identity,EnemySpawner.transform);
        }
        SpawnAllow = false;
    }
    void Update()
    {

        if (EnemyCountReal == 0)
        {
            if (doorsAllow == true)
            {
                for (int i = 0; i < doors.Count; i++)
                {
                    animdoors = doors[i].GetComponent<Animator>();
                    animdoors.SetInteger("hui", 1);
                }
               // this.gameObject.SetActive(false);
                doorsAllow = false;
            }
           
        }
    }
}
