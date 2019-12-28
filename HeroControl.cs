using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Joystick joystick;

    //стартовые характеристики
    float run = 3f;
    public float speedup; //herohar
    internal static float dash;  //herohar
    internal static float ShootSpeed;  //herohar
    internal static int hp;
    internal static float dashCD = 4f;
    //стартовые характеристики

    public Rigidbody2D rb;
    public Rigidbody2D rbb;
    public Rigidbody2D rbullet;
    public RectTransform heropos;
    public Animator anim;
    private int animNum;
    public SpriteRenderer sr;

    internal static float side = 1;
    public Vector2 HeroDirection ;

    internal static bool Dash;
    private bool PredDash = false;
    static bool Shoot = true;
    private bool LookLeft;
    internal static bool isUntouchable = false;


    public GameObject Bullet;
    public GameObject BulletCopy;
    public SpriteRenderer bulletsr;

    public GameObject[] HP ;
    

    void Start()
    {
       
        Dash = true;
        speedup = 3f;
           dash = 150f;
        ShootSpeed = 14f;
            hp = 3;
        LookLeft = false;
        HeroDirection = new Vector2(-1, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (isUntouchable == false)
            {
                HP[hp].SetActive(false);
                hp -= 1;
            }
            
        }
        if (collision.gameObject.tag == "Udar")
        {
           
            HP[hp].SetActive(false);
            hp -= 1;
        }
    }
    public void ShootBul()
    {
        if (animNum != 5)
        {
            if (Shoot == true)
            {
                BulletCopy = Instantiate(Bullet, new Vector3(heropos.position.x, heropos.position.y, 0), Quaternion.identity);
                rbb = BulletCopy.GetComponent<Rigidbody2D>();
                rbb.velocity = new Vector2(ShootSpeed * HeroDirection.x, ShootSpeed * HeroDirection.y);
                bulletsr = BulletCopy.GetComponent<SpriteRenderer>();
                if (side == 2)
                {
                    animNum = 4;

                }
                if (side == 4)
                {
                    animNum = 4;
                }

                if (animNum != 2) bulletsr.sortingOrder = 8;
                else bulletsr.sortingOrder = 5;
                Shoot = false;
                Invoke("ShootCD", 0.4f);
            }
        }
        
    }

    public void DashStartAnim()
    {
        if (Dash == true)
        {
            DashTime.TimerCheck = true;
            animNum = 5;
            Dash = false;
            Invoke("DashCD", dashCD);
        }
    }
    public void Dashepta()
    {
        
            
            PredDash = true;
            rb.velocity = new Vector2(HeroDirection.x*dash,HeroDirection.y*dash);
            
            Invoke("DashTime1",0.03f);
            
        
    }
    // Update is called once per frame
    public void Flip()
    {
        transform.Rotate(Vector3.up*180);
    }
    public void DashCD()
    {
        Dash = true;
    }
    public void DashTime1()
    {
        rb.velocity = new Vector2(0,0);
        PredDash = false;
        animNum = 0;
    }
    public void ShootCD() 
    {
        Shoot = true;
    }
    void Update()
    {
       
    }
    public void FixedUpdate()
    {
        
        if (hp == 0)
        {
            Application.LoadLevel("DungeonLvl1");
        }
        
      //  if (Input.GetMouseButton(0))
       // {
       //     ShootBul();
       // }
        if (Input.GetKey("h"))
        {
            ShootBul();
        }

        if (Input.GetKey("space"))
        {
            DashStartAnim();
        }
       
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
            if (side!=1)
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

        if (animNum == 5)
        {

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
          
            if (animNum != 5) animNum = 2;
        }

        if (joystick.Vertical <= -.4f)
        {
            
            side = 3;
            if (animNum != 5) animNum = 3;
        }

        if ((joystick.Horizontal >= .4f ^ joystick.Horizontal <= -.4f ^ joystick.Vertical >= .4f ^ joystick.Vertical <= -.4f) ^ (joystick.Vertical >= .4f & joystick.Horizontal >= .4f) ^ (joystick.Vertical >= .4f & joystick.Horizontal <= -.4f) ^ (joystick.Vertical <= -.4f & joystick.Horizontal <= -.4f) ^ (joystick.Vertical <= -.4f & joystick.Horizontal >= .4f))
        {
            if (PredDash == false)
            {
                rb.MovePosition(new Vector2(rb.position.x + joystick.Direction.x * (run + speedup) * Time.fixedDeltaTime, rb.position.y + joystick.Direction.y * (run + speedup) * Time.fixedDeltaTime));
            }
            HeroDirection = joystick.Direction;
        }
        else
        {

            if (animNum != 5) animNum = 0;
        }
        anim.SetInteger("hui", animNum);

    }
}