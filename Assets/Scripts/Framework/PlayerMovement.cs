using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forceForwardSpeed = 2000f;
    public float forceRightSpeed = 500f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forceForwardSpeed * Time.deltaTime);

        if(Input.GetKey("d")){
            rb.AddForce(forceRightSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } else if(Input.GetKey("a")){
            rb.AddForce(-forceRightSpeed * Time.deltaTime, 0,0, ForceMode.VelocityChange);
        }
    }

    public void stopPlayerMovement(){
        this.enabled = false;
    }

}