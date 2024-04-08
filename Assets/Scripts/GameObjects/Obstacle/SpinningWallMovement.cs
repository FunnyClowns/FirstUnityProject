using System.Collections;
using UnityEngine;

public class SpinningWallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;

    private Vector3 tempPos;
    private Vector3 currentPos;

    void Start(){
        setCurrentPos();
        StartCoroutine(MovementLooping());

    }

    
    private Vector3 velocity;

    void FixedUpdate(){
        if (tempPos != Vector3.zero)
            transform.position = Vector3.SmoothDamp(getTransformPos(), tempPos, ref velocity, Time.deltaTime, Random.Range(20f, 30f));


    }

    IEnumerator MovementLooping(){

        while (true){

            yield return new WaitForSeconds(getRandomTime());
            tempPos = getNextMovePos();

        }
    }



    private Vector3 getTransformPos(){

        return transform.position;
    }

    private void setCurrentPos(){
        currentPos = getTransformPos();
    }

    private float getRandomTime(){
        return Random.Range(5f, 10f);
    }

    private Vector3 getNextMovePos(){
        if (getTransformPos().z <= currentPos.z){

            return getTransformPos() + new Vector3(0, 0, 100f);
        } else {

            return currentPos;
        }
    }
}
