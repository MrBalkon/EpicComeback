using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForUseBut : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (CharControl.NearItem == true)
        {
            if (Item.CurrentItemToUse != null) Destroy(Item.CurrentItemToUse);
        }
        else
        {
            if (CharControl.NearNpc == true)
            {
                DialogControll.DialogOpen();
            }
           
        }

       
    }
}
