using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ItemBase
{
    internal static GameObject CurrentItemToUse;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Use");
        Debug.Log(UseButton);
        UseButton.SetActive(true);
        CurrentItemToUse = this.gameObject;
        transform.localScale = transform.localScale * 1.1f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = transform.localScale / 1.1f;
        UseButton.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
