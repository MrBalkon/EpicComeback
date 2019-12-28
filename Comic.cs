using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comic : MonoBehaviour
{
    // Start is called before the first frame update
    public int c;
    public GameObject i2, i3;
    void Start()
    {
        c = 3;
    }

    public void Comics()
    {
        c -= 1;
        if (c == 2) { i2.SetActive(true); }
        if (c == 1) { i3.SetActive(true); }
        if (c == 0) { SceneManager.LoadScene(2); }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
