using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] float moveSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (Vector3) direction * moveSpeed;
        Camera.main.transform.position = gameObject.transform.position + new Vector3(0,0,-10);
    }

    public void Walk(Vector2 direction)
    {
        this.direction = direction;
    }


}
