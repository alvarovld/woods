using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate bool Condition();
public interface IActionBehaviour
{
    bool isProccessingAction();
    void setProcessingUntilConditionApplies(Condition condition);
    void setProcessingUntilConditionApplies(float min, float max);

}
