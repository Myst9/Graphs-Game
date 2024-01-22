using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [Header("Movement")] 
    public float moveSpeed = 5f;
    // Start is called before the first frame update

    public float groundDrag;

    [Header("GroundCheck")]
    bool is_grounded;
    public LayerMask groundMask;
    public float playerHeight;



    public Transform orientation;

    public float rotationRate;
    public Rigidbody rb;
    int coins = 0;
    public float dead_y = -50;


    float horizontal_input;
    float vertical_input;
    Vector3 movedir;


    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        rb.freezeRotation= true;
    }

    // Update is called once per frame
    void Update()
    {
        groundCheck();
        speedControl();
        getInput();
        //Debug.Log("Prev Movem: " + movem);
        //movem = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z) * movem;
        //movem = Quaternion.Euler(xRot, yRot, zRot) * movem;
        /*movem = movem.normalized;
        if (movem != Vector3.zero)
        {
            rotate(movem);
            translate(movem);
        }*/
        //Debug.Log("Post Movem: " + movem);
        moveplayer();

    }

    private void speedControl()
    {
        Vector3 curr = new Vector3(rb.velocity.x,0,rb.velocity.z);
        if(curr.magnitude > moveSpeed) {
            curr = curr.normalized * moveSpeed;
            rb.velocity = new Vector3(curr.x, rb.velocity.y, curr.z);
        }
    }
    void groundCheck()
    {
        is_grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundMask);
        if (is_grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("Coins: " + coins);
        }
    }

    void getInput()
    {
        horizontal_input = Input.GetAxisRaw("Horizontal");
        vertical_input = Input.GetAxisRaw("Vertical");
    }

    void moveplayer()
    {
        movedir= orientation.forward* vertical_input + orientation.right* horizontal_input;
        if (movedir == Vector3.zero)
        {
            rb.velocity = new Vector3(rb.velocity.x/3, rb.velocity.y/3,rb.velocity.z/3);
        }
        else
        {
            rotate();
            rb.AddForce(movedir.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        
    }
    /*void translate(Vector3 movem)
    {
        rb.MovePosition(rb.position + movem * Time.deltaTime * moveSpeed);
    }*/
    void rotate()
    {
        Quaternion toRotate = Quaternion.LookRotation(movedir, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, Time.deltaTime * rotationRate);
    }
}
