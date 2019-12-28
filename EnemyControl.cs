using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP;
    public Animator anim;
    public GameObject udar;
    public GameObject tr;
    public Transform Player;
    public bool iderboi;

    private void Awake()
    {
        tr = GameObject.FindGameObjectWithTag("Player");
        Player = tr.GetComponent<Transform>();
       
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP -= 1;
        }
    }
    public void Fight()
    {        
        udar.SetActive(true);
    }
    public void vernut()
    {
        udar.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (HP == 0)
        {
            Destroy(this.gameObject);
            Field.DoorOpen -= 1;
        }
        
    }
    private void FixedUpdate()
    {
        if (Player.position.x + 10 <= transform.position.x)
        {
            if (iderboi = false)
            {
                
                iderboi = true;
                Fight();
            }
        }
    }
}
