using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{   //made targetDestination public so SpawnEnemy created enemies will have correct destination (EnemiesManager.cs)
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;
    [SerializeField] float speed;

    [SerializeField] int hp = 999;
    [SerializeField] int damage = 1;
    
    //cache 2d rigidbody of object
    Rigidbody2D rgbd2d;

    private void Awake()
    {
       rgbd2d = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
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
       // Debug.Log("Attacking the player!");
       if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();

        }

       targetCharacter.TakeDamage(damage);

    }

    //public function damage calculation
    public void TakeDamage(int damage)
    {
        hp -= damage;
        //check if hp is zero to destroy object
        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }

}



