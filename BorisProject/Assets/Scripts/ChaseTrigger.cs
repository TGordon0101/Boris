using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChaseTrigger : MonoBehaviour
{
    public GameObject Player_Obj;
    public AI AI_Script_Obj;

    public bool PlayerDectected;

    void Start()
    {
        Player_Obj = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            PlayerDectected = true;
            AI_Script_Obj.SetBoolChase(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            PlayerDectected = false;
        }
    }
}