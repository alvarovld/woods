using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSetByCondition : MonoBehaviour, IActionBehaviour
{
    bool processing;
    Condition conditionApplies;

    public bool isProccessingAction()
    {
        return processing;
    }

    public void setProcessingUntilConditionApplies(float min, float max)
    {
    }

    public void setProcessingUntilConditionApplies(Condition condition)
    {
        conditionApplies = condition;
        processing = true; ;
    }

    private void Awake()
    {
        processing = false;
        conditionApplies = () => { return true; };
    }

    private void Update()
    {
        if(conditionApplies())
        {
            processing = false;
        }
    }
}
