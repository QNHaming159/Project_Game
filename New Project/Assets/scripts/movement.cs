using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public int speed = 10;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;
    // Start is called before the first frame update
    void Start()
    {
     characterBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2(speed, speed);
        inputMovement = new Vector2 (
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
    }
    private void FixedUpdate()
    {
    Vector2 delta = inputMovement * velocity * Time.deltaTime;
    Vector2 newPosition = characterBody.position + delta;
    characterBody.MovePosition(newPosition);
    }
}
