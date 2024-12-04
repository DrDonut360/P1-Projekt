using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Health health;
    void Start()
    {
        
    }

    void Update()
    {
        animator.SetInteger("Health", health.health);
    }
}
