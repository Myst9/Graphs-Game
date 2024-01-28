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


    public Logic l;
    public CamSwitch cs;

    public Transform orientation;
    public GameObject cam;


    public float rotationRate;
    public Rigidbody rb;
    //int coins = 0;
    public float dead_y = -50;


    float horizontal_input;
    float vertical_input;
    Vector3 movedir;


    private float timer;
    private float dead_time = 450;
    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        rb.freezeRotation= true;
        timer = 0; 
        l = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        cs = GameObject.FindGameObjectWithTag("GameController").GetComponent<CamSwitch>();
    }

    void checkTime()
    {
        if(timer < dead_time)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        groundCheck();
        speedControl();
        checkTime();
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
        if (cam.activeSelf)
        {
            getInput();
            moveplayer();
        }

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
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            l.addScore(1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Done"))
        {
            Debug.Log("Player i done");
            //Destroy(gameObject);
            gameObject.SetActive(false);
            Destroy(other.gameObject);
            cam.SetActive(false);
            cs.cam10.SetActive(true);
            //Destroy(cam);
        }
        else//Must be a spawner
        {
            dead_time += 300;
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
            rb.velocity = new Vector3(rb.velocity.x/2, rb.velocity.y/2,rb.velocity.z/2);
        }
        else
        {
            rotate();
            rb.velocity = movedir.normalized * moveSpeed;
            //rb.AddForce(movedir.normalized * moveSpeed*2f, ForceMode.Force);
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