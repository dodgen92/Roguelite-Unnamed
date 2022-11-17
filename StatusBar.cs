using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] Transform bar;


    //method that calculates the value between 0 and 1 by dividing by dividing converted value of current hp to float by max hp value
    public void SetState(int current, int max)
    {
        float state = (float)current;
        state /= max;
        if (state < 0f){ state = 0f; }
        bar.transform.localScale = new Vector3(state, 1f, 1f);

    }    
}
