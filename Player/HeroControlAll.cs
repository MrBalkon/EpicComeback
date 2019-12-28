using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class HeroControlAll : MonoBehaviour
{
    //стартовые характеристики
    [SerializeField]
    public float run;
    public int MaxHp;
    public int hp;
    public float ShootSpeed;
    public int damage;
    public float ShootRate;
    //стартовые характеристики

    //бафы/дебафы
    public float speedup;
    public int hpUp;
    public float Armor;

    public float damageup;
    public int Poison;
    public float Fire;
    public float Ice;
    public float multiShoot;

    public bool AutoShoot;
    public bool invisibility;
    public bool UnTouchable;
    //бафы/дебафы
    public Joystick joystick;

    public Rigidbody2D rb;
    public Rigidbody2D rbb;
    public RectTransform heropos;
    public bool BulletAngle;
    public Animator anim;
    public int animNum;
    public Animator BulletAnim;
    public float side = 1;
    public Vector2 HeroDirection = new Vector2(-1, 0);


    private bool LookLeft = false;

    public GameObject Skill1;
    public GameObject Skill2;

   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            rb.velocity = Vector3.zero;
            if (UnTouchable == false)
            {
                
                CharControl.hp -= 1; ;
            }
            

        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            rb.velocity = Vector3.zero;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            rb.velocity = Vector3.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc")
        {
            CharControl.NearNpc = true;
        }
        if (collision.gameObject.tag == "Item")
        {
            CharControl.NearItem = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc")
        {
            CharControl.NearNpc = false;
        }
        if (collision.gameObject.tag == "Item")
        {
            CharControl.NearItem = false;
        }
    }
    public void Awake()
    {
        CharControl.maxHp = MaxHp;
        CharControl.damage = damage;
        CharControl.hp = hp;
        CharControl.Poison = Poison;
        Skill1.SetActive(true);
        Skill2.SetActive(true);
        
    }
    
    public void Flip()
    {
        transform.Rotate(Vector3.up * 180);
    }
    
    protected void FixedUpdate()
    {   speedup = CharControl.speedup;
        if (CharControl.hpUp > 0)
        {
            CharControl.hp = CharControl.hp + CharControl.hpUp;
            CharControl.hpUp = 0;
        }
       // Armor = CharControl.Armor;
       // damageup = CharControl.damageup;
       // Poison = CharControl.Poison;
       // Fire = CharControl.Fire;
        //Ice = CharControl.Ice;
       // multiShoot = CharControl.speedup;

        //AutoShoot = CharControl.AutoShoot;
       // invisibility = CharControl.invisibility;
       // UnTouchable = CharControl.UnTouchable;

        if (CharControl.hp <= 0)
        {
            Application.LoadLevel("DungeonLvl1");
        }

        if (joystick.Horizontal >= .4f)
        {
            side = 4;
            if (!LookLeft)
            {
                Flip();
                LookLeft = !LookLeft;
            }
            if (animNum != 5) animNum = 1;
        }

        if (joystick.Horizontal <= -.4f)
        {
            side = 2;
            if (LookLeft)
            {
                Flip();
                LookLeft = !LookLeft;
            }
            if (animNum != 5) animNum = 1;
        }

        if (joystick.Vertical >= .4f)
        {
            side = 1;
            if (animNum != 5) animNum = 2;
        }

        if (joystick.Vertical <= -.4f)
        {

            side = 3;
            if (animNum != 5) animNum = 3;
        }

        ///test
        if (Input.GetKey("d"))
        {
            run = 6f + speedup; //идет вправо
            rb.MovePosition(new Vector2(rb.position.x + run * Time.deltaTime, rb.position.y));
            side = 4;
            if (!LookLeft)
            {
                Flip();
                LookLeft = !LookLeft;
            }
            anim.SetInteger("hui", 1);
        }
        else if (Input.GetKey("a"))
        {
            run = -6f - speedup; //идет влево
            rb.MovePosition(new Vector2(rb.position.x + run * Time.deltaTime, rb.position.y));
            side = 2;
            if (LookLeft)
            {
                Flip();
                LookLeft = !LookLeft;
            }
            anim.SetInteger("hui", 1);
        }

        if (Input.GetKey("w"))
        {
            run = 6f + speedup; //идет вправо
            rb.MovePosition(new Vector2(rb.position.x, rb.position.y + run * Time.deltaTime));
            if (side != 1)
            {
                anim.SetInteger("hui", 2);
            }
            side = 1;


        }
        if (Input.GetKey("s"))
        {
            run = -6f - speedup; //идет влево
            rb.MovePosition(new Vector2(rb.position.x, rb.position.y + run * Time.deltaTime));
            if (side != 3)
            {
                anim.SetInteger("hui", 3);
            }
            side = 3;

        }
        ///test

    }
}
    


