using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    public float speed = 5.0f;
    public float turnSpeed = 5.0f;
    private bool isOnGround = true;
    public float jumpHeight = 5;
    private Animator playerAnim;
    private Rigidbody playerRb;
    public float topBound = 8;
    public float rightBound = 67;
//NOTE: MAKE BOUNDS TO KEEP PLAYER ON THE GROUND    

    
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
       
       
        if (forwardInput != 0)
        {
            playerAnim.SetBool("Static_b", true);
            playerAnim.SetFloat("Speed_f", 1);
        }

        if (forwardInput == 0)
        {
            playerAnim.SetFloat("Speed_f", 0);
        }
        
       
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isOnGround = false;                       //adds force 1 time only
            playerAnim.SetTrigger("Jump_trig");
        }


        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
