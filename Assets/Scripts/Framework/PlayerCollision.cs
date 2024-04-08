using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    public GameManagerScript gameManager;
    
    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.collider.tag == "Obstacles" || collisionInfo.collider.tag == "DeleteObstacles"){
            movement.stopPlayerMovement();
            gameManager.endGame(false);
        }
    }
}
