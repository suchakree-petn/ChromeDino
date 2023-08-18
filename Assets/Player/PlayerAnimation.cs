using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float y_Axis;
    void Update()
    {
        y_Axis = transform.parent.GetComponent<Rigidbody2D>().velocity.y;
        animator.SetFloat("y_Axis", y_Axis);
    }
}
