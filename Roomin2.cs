using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomin2 : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject dver;
    public GameObject thi;

    public void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(thi);
        dver.SetActive(true);
        Field.StartFight = true;
    }
}
