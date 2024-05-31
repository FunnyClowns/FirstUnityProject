using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{
    private Animator animator;
    bool menuCamera;

    void Awake(){
        animator = GetComponent<Animator>();
    }

    public void SwitchState(){
        
        if(menuCamera){
            animator.Play("MenuCamera");
        } else {
            animator.Play("LevelCamera");
        }

        menuCamera = !menuCamera;

    }
}
