using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour, Iinteract
{
    public bool insideCloset;
   
    private Movement mov;
    private GameObject exitPosition;
    private GameObject Player;

    private void Start()
    {
        exitPosition = gameObject.transform.GetChild(1).gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");
        mov = Player.GetComponent<Movement>();
    }

    public void Interact()
    {
        if (!insideCloset) // If the player is not inside the closet it will transport them inside the closet and set the bool to true
        {
            Player.GetComponent<CapsuleCollider>().enabled = false;
            Player.GetComponent<Rigidbody>().useGravity = false;
            GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
            insideCloset = true;
            mov.canWalk = false;
        }

        else if (insideCloset) // If the player in inside the closet it will transport them outside the closet and set the bool to false
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = exitPosition.transform.position;
            Player.GetComponent<CapsuleCollider>().enabled = true;
            Player.GetComponent<Rigidbody>().useGravity = true;
            insideCloset = false;
            mov.canWalk = true;
        }
    }
}
