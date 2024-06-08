using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();  
    }

    void Update()
    {
        // Movement Animations 
        animator.SetBool("IsRunning", Input.GetKey("w")); 
        animator.SetBool("Backward", Input.GetKey("s"));
        animator.SetBool("right", Input.GetKey("d"));
        animator.SetBool("left", Input.GetKey("a"));

        // Jump Animation
        bool isJumping = Input.GetKeyDown("space");
        animator.SetBool("jump", isJumping); 

        // Reset 'jump' after animation plays
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("jump")) // Replace 'Jump' with your actual jump state name
        {
            animator.SetBool("jump", false); 
        }
    }
}
