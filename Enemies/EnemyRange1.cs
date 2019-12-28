using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange1 :Enemies
{
    public GameObject Gun;
    public SpriteRenderer GunSr;
    public Transform BulletSpawn;

    public float ShootSpeed;
    public float ShootRate;

    public float RandomTimeForMoving;
    public float RandomTimeForShooting;

    
    private bool isShooting;
    private float RngShooting;
    private new void Start()
    {
        base.Start();
        anim.SetBool("isPatroling", true);
        isShooting = false;

        Shooting();
        Shooting();
    }
    public void Flip()
    {
        transform.Rotate(Vector3.up * 180);
        GunSr.flipX = !GunSr.flipX;
    }
    public void EnemyBahSystem()
    {

    }

    public void Shooting()
    {
        if (isShooting == true)
        {
            anim.SetBool("isShooting", true);
            RngShooting = Random.Range(2f, 3f);
            isShooting = false;
        }
        else
        {
            anim.SetBool("isShooting", false);
            isShooting = true;
            Invoke("Shooting", RngShooting);
        }
       // Debug.Log(isShooting);
    }
    public new void FixedUpdate()
    {
        base.FixedUpdate();
        Debug.Log(Heropos.position);
        if (Vector3.Distance(transform.position, Heropos.transform.position) > 15f)
        {
            anim.SetBool("isFollowing", true);
            anim.SetBool("isPatroling", false);
            anim.SetBool("isShooting", false);
        }
        else
        {
            anim.SetBool("isFollowing", false);
            anim.SetBool("isPatroling", true);
            anim.SetBool("isShooting", true);
        }

        


        if (transform.position.x > Heropos.position.x)
        {
            if (!LookLeft)
            {
                Flip();
                LookLeft = true;
            }
        }
        else
        {
            if (LookLeft)
            {
                Flip();
                LookLeft = false;
            }
        }
        var angle = Vector2.Angle(Vector2.right, Heropos.position - transform.position);
        Gun.transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < Heropos.position.y ? angle : -angle);
    }
}
