using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject leftWhipObject;
    [SerializeField ] GameObject rightWhipObject;

    PlayerMove playerMove;

        private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    //timer attack countdown...change timeToAttack to adjust
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
        timer = timeToAttack;

        if (playerMove.movementVector.x > 0)
        {
            rightWhipObject.SetActive(true);
        }

        else
        {
            leftWhipObject.SetActive(true);
        }    
    }
}
