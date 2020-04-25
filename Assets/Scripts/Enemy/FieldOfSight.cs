using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfSight : MonoBehaviour
{
    public float angleOfSight;
    public Vector3 forward;
    public float fixAngle;


    public void setTotalAngle(float angle)
    {
        angleOfSight = angle;
    }
    public bool isTransformInFieldOfSight(Transform otherTransform)
    {
        Vector3 otherVector = otherTransform.position - transform.position;
        Vector2 plain = new Vector2(otherVector.x, -otherVector.z);
        Vector2 forwardPlain = new Vector2(forward.x, -forward.z);
        float angleFromOtherToForward = Vector2.Angle(forwardPlain, plain);

        if (angleFromOtherToForward > (angleOfSight / 2))
        {
            return false;
        }
        return true;

    }

    void setForward()
    {
        Quaternion fixedRotation = Quaternion.Euler(0, fixAngle, 0) * transform.rotation;
        forward = fixedRotation * new Vector3(0, 0, 1);
    }

    private void Update()
    {
        setForward();
    }

}
