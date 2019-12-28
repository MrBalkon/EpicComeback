using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLoc : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject loca;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        loca.SetActive(true);
    }
}
