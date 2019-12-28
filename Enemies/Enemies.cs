using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    public int HP;
    public float speed;
    public int damage;
    public int soulsDropMin;
    public int soulsDropMax;
    private int soulsReal;
    

    private int poisonCount =0;
    GameObject souls;

    public Transform Heropos;
    public Animator anim;
    public Rigidbody2D rb;

    public bool LookLeft;
    public void Start()
    {
        souls = (GameObject)Resources.Load("Soul") as GameObject;
        Heropos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        LookLeft = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (CharControl.Poison > 0)
            {
                poisonCount = poisonCount + 3;
                InvokeRepeating("PoisonGet",1f,3f);
                
            }
            HP = HP - CharControl.damage;
            Debug.Log(HP);
            rb.velocity = Vector3.zero;
        }
    }


    public void PoisonGet()
    {
        HP = CharControl.PoisonDmg(HP, CharControl.Poison);
        poisonCount = poisonCount - 1;
    
        foreach (SpriteRenderer el in this.gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            el.color = new Color(0.9362738f, 1, 0.5707547f);
        }
        if (poisonCount == 0)
        {
            CancelInvoke("PoisonGet");
            foreach (SpriteRenderer el in this.gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                el.color = new Color(1, 1, 1);
            }
            poisonCount = 2;
        }
    }

    public void FixedUpdate()
    {
        
        if (HP <= 0)
        {
            soulsReal = Random.Range(soulsDropMin, soulsDropMax);
            for (int i = 0; i < soulsReal; i++)
            {
                Instantiate(souls, new Vector3(transform.position.x+Random.Range(-1f,1f), transform.position.y + Random.Range(-1f, 1f), 1) ,Quaternion.identity);
            }
           RoomController.EnemyCountReal = RoomController.EnemyCountReal - 1;
           Destroy(this.gameObject);
        }
    }
}
