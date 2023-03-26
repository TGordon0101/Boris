using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public GameObject Player_Obj;

    public Vector3 Target_Position;
    public NavMeshAgent Monster_AI_Mesh;

    public GameObject AI_Obj;


    // Start is called before the first frame update
    void Start()
    {
        Monster_AI_Mesh = GetComponent<NavMeshAgent>();
        Player_Obj = GameObject.FindGameObjectWithTag("Player");

        AI_Obj = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Target_Position = Player_Obj.transform.position;

        Monster_AI_Mesh.SetDestination(new Vector3(Target_Position.x, Target_Position.y, 1));
        AI_Obj.transform.rotation = Quaternion.identity;
    }
}
