using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletLife = 0.5f; //характеристкка
    public Animator anim;

    public int ThisBulletDamage;
  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharControl.hp = CharControl.hp - ThisBulletDamage;
        }
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        anim.SetBool("hui", true);
    }
    void Start()
    {
        
        Invoke("animbul", BulletLife);
        
    }
    public void animbul()
    {
        anim.SetBool("hui", true);
    }
    public void DestroyBul()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
