using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack = 4f;
    float timer;

    //drag whip sprites to this field in editor
    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMove playerMove;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);
    [SerializeField] int whipDamage = 1;

        private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    //timer attack animation countdown
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    //instantiates the gameobjects/sprites based on left or right facing
    private void Attack()
    {
        // Debug.Log("Attack");
        timer = timeToAttack;

        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            //combat mechanics- collider array detecting everything that overlaps with object
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }

        else
        {
            leftWhipObject.SetActive(true);
            //combat mechanics- collider array everything that overlaps with object
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }    
    }
    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            //checks if enemy is present by cycling through collider array
            Enemy e = colliders[i].GetComponent<Enemy>();
            if (e != null)
            {
                        colliders[i].GetComponent<Enemy>().TakeDamage(whipDamage);
            }
        }
    }
}
