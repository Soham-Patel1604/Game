using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    [Header("Movement")]
    public int speed ;//to get desired movement speed
    public int shiftspeed;
    public static float speeds;
    
    public float groundDrag;
    [Header("jump")]
    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readytojump;
    [Header("keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    [Header("Ground Check")]
    public float playerhight;
    public LayerMask whatIsGround;
    bool grounded;
    private Rigidbody RigidbodyComponent;// to make  better 

    public Transform orientation;
    Vector3 movedirection;
    private float horizontalInput;//horizontal movement of player
    private float vertiacalInput;//
    private Transform playerTransform;
    bool keypressed;
     







// Start is called before the first frame update
void Start()
    {
        playerTransform=transform;
        RigidbodyComponent = GetComponent<Rigidbody>();
        readytojump = true;
        keypressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //make the player wrap to not bound and be in the screan
        if (playerTransform.position.y < -50)
        {
            playerTransform.position = new Vector3(0, 30, 0);
        }
        //gorund check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerhight*0.5f+0.2f,whatIsGround);
        MyInput();
        speedControl();

        if (grounded)
        {
            RigidbodyComponent.drag = groundDrag;
        }
        else
        {
            RigidbodyComponent.drag = 0;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //SceneManager.LoadSceneAsync("main menu");
        }
        

    }
    private void FixedUpdate()
    {
        MovePLayer();
    }
    void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        vertiacalInput = Input.GetAxis("Vertical");
        if (Input.getAxis("Horizontal") || Input.getAxis("Vertical"))
        {
            keypressed = true;
        }
        else
        {
            keypressed = false;
        }
        if (Input.GetKey(jumpKey) && readytojump && grounded)
        {
            readytojump = false;

            jump();

            Invoke(nameof(resetJump), jumpCoolDown);
        }

    }
    private void MovePLayer()
    {
        movedirection = orientation.forward * vertiacalInput + orientation.right * horizontalInput;
        if (grounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                RigidbodyComponent.AddForce(movedirection * shiftspeed * 10f, ForceMode.Force);
            }
            else
            {
                RigidbodyComponent.AddForce(movedirection * speed * 10f, ForceMode.Force);
            }
           
            
        }
        else if (!grounded)
        {
            RigidbodyComponent.AddForce(movedirection * speed * 10f * airMultiplier, ForceMode.Force);
        }
        
    }
    private void speedControl()
    {
        Vector3 flatvel = new Vector3(RigidbodyComponent.velocity.x, 0f, RigidbodyComponent.velocity.z);
        
        //limit velocity if needed
        if (flatvel.magnitude > speed)
        {
            Vector3 limitedvel=flatvel.normalized * speed;
            RigidbodyComponent.velocity = new Vector3(limitedvel.x,RigidbodyComponent.velocity.y,limitedvel.z);
        }
        speeds = RigidbodyComponent.velocity.magnitude;
    }
    private void jump()
    {

        //reset y velocity
        RigidbodyComponent.velocity = new Vector3(RigidbodyComponent.velocity.x, 0f, RigidbodyComponent.velocity.z);
        RigidbodyComponent.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void resetJump()
    {
        readytojump = true;
    }
   




}
