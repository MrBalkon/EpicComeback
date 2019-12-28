using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ded : NpcControl
{ 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Sleep", false);
            Eventss[0].dei = Do;
            Eventss[1].dei = fu;
            DialogControll.TextTranslater(ChoosesId, Eventss);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Sleep", true);
            ItemBase.UseButton.SetActive(false);
            DialogControll.DialogClose();
        }
    }

    public void Do()
    {
        Debug.Log("Do");
    }

    public void fu()
    {
        Debug.Log("Fu");
    }
}
