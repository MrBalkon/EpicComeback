using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherScript : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharControl.moneySouls = CharControl.moneySouls + 1;
            Destroy(this.gameObject);
        }
    }
}
