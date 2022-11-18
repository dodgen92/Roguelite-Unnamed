using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject healthPickUp;

    //Drop rate field in the editor ex- 0.4 = 40% drop chance
    [SerializeField][Range(0f, 1f)] float chance = 1f;

    private void OnDestroy()
    {
        if (Random.value < chance)
        {
    
        Transform t = Instantiate(healthPickUp).transform;
        t.position = transform.position;
        }
    }
}
