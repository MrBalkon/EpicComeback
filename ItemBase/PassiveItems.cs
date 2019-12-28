using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : Item
{
    // Start is called before the first frame update
   

    private void OnDestroy()
    {
        CharControl.hpUp = 1;
    }
}
