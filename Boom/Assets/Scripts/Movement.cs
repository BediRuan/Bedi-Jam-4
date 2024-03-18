using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//God of Computer Science, please bless my code!
//God of Computer Science, please bless my code!
//God of Computer Science, please bless my code!
public class MovePositionDemo : MonoBehaviour
{
    
    public Vector2 direction;
    public Rigidbody2D rb;
    public float speed = 2f;
   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        
    }

    private void FixedUpdate()
    {
        //Move the object
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }

    
}