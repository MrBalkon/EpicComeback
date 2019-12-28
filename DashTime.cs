using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashTime : MonoBehaviour
{
    // Start is called before the first frame update
    public Image DashB;
    public float DashCd = Player1.dashCD;
    public float Timer = Player1.dashCD;
    internal static bool TimerCheck = true;
   
    // Update is called once per frame
    void Update()
    {
       
        if (Player1.Dash == false && TimerCheck == true)
        {
            Timer = Timer - Time.deltaTime;
            DashB.fillAmount = (DashCd-Timer)/DashCd;
            if (Timer <= 0)
            {
                Timer = DashCd;
                TimerCheck = false;
            }
        }
       
    }
    
}
