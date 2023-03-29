using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public bool b_playerDead = false;

    private Rigidbody2D body;
    public UIScript UI_Obj;
    public GameManager GM_Obj;
    public AudioSource PlayerSound;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        UI_Obj = GameObject.Find("EndGameCanvas").GetComponent<UIScript>();
        GM_Obj = GameObject.Find("ChastTrigger").GetComponent<GameManager>();
        PlayerSound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (b_playerDead == true)
        {
            UI_Obj.YouLose();
        }

        if(b_playerDead == false && GM_Obj.b_GameEnd == false)
        {
            //Move Camera
            MoveCamera();

            //Look At Mouse
            LookAtMouse();

            //Move Player
            Move();
        }
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector3)(mousePos - new Vector2(transform.position.x, transform.position.y));
    }

    private void Move()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        body.velocity = input.normalized * moveSpeed;

        //if(body.velocity.x == 0 && body.velocity.y == 0)
        //{
        //    PlayerSound.Play();
        //}
    }

    private void MoveCamera()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -1.0f);
    }

    public void Die()
    {
        b_playerDead = true;
    }
}
