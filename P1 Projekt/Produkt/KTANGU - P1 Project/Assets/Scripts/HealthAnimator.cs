using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class HealthAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Health health;
    void Start()
    {
        if (health == null)
        {
            foreach (GameObject obj in FindObjectsOfType<GameObject>())
            {
                if (obj.CompareTag("Player"))
                {
                    health = obj.GetComponent<Health>();
                }
            }
        }
        
    }

    void Update()
    {
        animator.SetInteger("Health", health.health);
    }
}
