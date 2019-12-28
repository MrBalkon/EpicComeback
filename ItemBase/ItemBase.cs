using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemBase : MonoBehaviour
{
    // Start is called before the first frame update
    

    public List<GameObject> Items;

    internal static GameObject UseButton;

   
    
    
   public void Awake()
    {
      UseButton = GameObject.FindGameObjectWithTag("UseButton");
        UseButton.SetActive(true);
    }
    public void Start()
    {

            UseButton.SetActive(false);

    }
    

}

