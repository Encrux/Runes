using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardListener : MonoBehaviour
{
    PlayerController playerController;
    Vector2 direction;

    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        direction = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        direction *= 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Vertical();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Horizonzal();
        }

        playerController.Walk(direction.normalized);
    }

    private void Vertical()
    {
        direction.y += Input.GetKey(KeyCode.W) ? 1 : 0;
        direction.y -= Input.GetKey(KeyCode.S) ? 1 : 0;
    }

    private void Horizonzal()
    {
        direction.x += Input.GetKey(KeyCode.D) ? 1 : 0;
        direction.x -= Input.GetKey(KeyCode.A) ? 1 : 0;
    }

}
