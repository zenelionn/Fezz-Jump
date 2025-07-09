using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    [SerializeField] private SpriteRenderer fezziwig;


    private float moveX;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        // check what button is being pressed
        // if left button, run switch to left and ect
        if (Input.GetKeyDown(KeyCode.LeftArrow)|| (Input.GetKeyDown(KeyCode.A)))
        {
            //Debug.Log("left key");
            SwitchSpriteLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.D)))
        {
            //Debug.Log("right key");
            SwitchSpriteRight();
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }

    private void SwitchSpriteLeft()
    {
        fezziwig.flipX = true;
    }

    private void SwitchSpriteRight()
    {
        fezziwig.flipX = false;
    }
}
