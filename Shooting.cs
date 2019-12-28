using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Player;
    public Player1 scriptPlayer;
    public bool ShootCheck ;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
  
    public void OnPointerUp(PointerEventData eventData)
    {
        ShootCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ShootCheck = true;
    }

    private void FixedUpdate()
    {
        if (ShootCheck == true)
        {
            scriptPlayer.ShootBul();
        }
    }
}
