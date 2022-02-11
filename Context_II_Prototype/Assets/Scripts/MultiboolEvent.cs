using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiboolEvent : MonoBehaviour
{
    public UnityEvent onAllTrue;
    public bool[] conditions;

    public void SetConditionTrue(int index)
    {
        conditions[index] = true;

        bool done = true;
        for (int i = 0; i < conditions.Length; i++)
        {
            done = done && conditions[i];
        }

        if (done) { onAllTrue.Invoke(); }
        //Check here
    }

    public void SetConditionFalse(int index)
    {
        conditions[index] = false;
    }
}
