using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizdukiControl : MonoBehaviour
{
    public bool Niza;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NiziaZone")
        {
            Niza = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NiziaZone")
        {
            Niza = false;
        }
    }
}


