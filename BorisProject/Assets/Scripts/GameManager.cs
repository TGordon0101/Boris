using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject Player_Obj;
    public AI AI_Script_Obj;

    public bool b_ChaseState;
    public bool b_GameEnd;

    void Start()
    {
        Player_Obj = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            b_ChaseState = true;
            AI_Script_Obj.SetBoolChase(true);
        }
    }

    public void SetGameEnd(bool _EndGameBool)
    {
        b_GameEnd = _EndGameBool;
    }
}