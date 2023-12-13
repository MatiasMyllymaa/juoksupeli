using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            animator.SetBool("isJumping", true);
        }
        if (!Input.GetKey("w"))
        {
            animator.SetBool("isJumping", false);
        }
        if (Input.GetKey("s"))
        {
            animator.SetBool("isSliding", true);
        }
        if (!Input.GetKey("s"))
        {
            animator.SetBool("isSliding", false);
        }
    }
}
