using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public GameObject Player_Obj;
    public GameObject AI_Obj;

    public Vector3 Target_Position;
    public Vector3 Rotation;
    public NavMeshAgent Monster_AI_Mesh;

    public Animator AI_Animation;

    public bool AI_Chase;

    // Start is called before the first frame update
    void Start()
    {
        Monster_AI_Mesh = GetComponent<NavMeshAgent>();

        Player_Obj = GameObject.FindGameObjectWithTag("Player");
        AI_Obj = GameObject.FindGameObjectWithTag("Enemy");

        AI_Chase = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AI_Chase == true) {
            Target_Position = Player_Obj.transform.position;

            Monster_AI_Mesh.SetDestination(new Vector3(Target_Position.x, Target_Position.y, 1));


            Vector3 diff = Player_Obj.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
            AI_Animation.SetFloat("Speed", 1.0f);

        }
        else {
            AI_Animation.SetFloat("Speed", 0.0f);
        }

    }

    public void SetBoolChase(bool _Chase)
    {
        AI_Chase = _Chase;
    }
}