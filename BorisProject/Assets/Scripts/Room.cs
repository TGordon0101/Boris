using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    private TilemapRenderer m_renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            m_renderer.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            m_renderer.enabled = false;
        }
    }
}
