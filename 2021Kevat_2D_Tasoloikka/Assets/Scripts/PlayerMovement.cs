using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2; 
    public  Rigidbody2D rb2D;
    private float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate(){
        Vector2 playerVelocity = new Vector2(horizontalMovement * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = playerVelocity;
    }
}
