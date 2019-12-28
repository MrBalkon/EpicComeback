using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPOs : MonoBehaviour
{
    private GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.localPosition = new Vector3(transform.position.x, transform.position.y,0);

    }



}
