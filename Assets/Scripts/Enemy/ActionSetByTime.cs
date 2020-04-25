using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSetByTime : MonoBehaviour, IActionBehaviour
{
    float actionTime;
    bool processing;
    public bool isProccessingAction()
    {
        return processing;
    }

    private void Awake()
    {
        processing = false;
    }

    public void setProcessingUntilConditionApplies(float min, float max)
    {
        processing = true;
        setActionTime(min, max);
    }

    void setActionTime(float min, float max)
    {
        actionTime = Random.Range(min, max);
    }

    public void setProcessingUntilConditionApplies(Condition condition)
    {
        processing = false;
    }

    void Update()
    {
        if(!processing)
        {
            return;
        }

        actionTime -= Time.deltaTime;

        if (actionTime <= 0)
        {
            processing = false; ;
        }
        
    }
}
