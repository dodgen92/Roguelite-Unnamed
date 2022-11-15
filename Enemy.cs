using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameObject;
    [SerializeField] float speed;

    
    //cache 2d rigidbody of object
    Rigidbody2D rgbd2d;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
    }

    private void FixedUpdate()
    {
        //chase towards destination...subtract position of the character from target position (set it to player character in editor)
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {     ///checking if collision is with player
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attacking the player!");
    }

}



