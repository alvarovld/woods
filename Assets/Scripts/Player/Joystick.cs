using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    public float walkingSpeed = 0.5f;
    private bool screenPressed = false;
    private Vector2 startPoint;
    private Vector2 endPoint;
    public float speed;

    public Transform innerCircle;
    public Transform outerCircle;
    public Canvas canvas;
    public Button runButton;
    public float runningSpeed;


    void Start()
    { 
        walkingSpeed = 4;
        runningSpeed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        setIsScreenPressed();
        setStartPointEndPointPosition();
        setJoystickPosition();
        showJoystickWhenPressed();
    }

    void setJoystickPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            innerCircle.transform.position = startPoint;
            outerCircle.transform.position = startPoint;
        }

        if (Input.GetMouseButton(0))
        {
            innerCircle.transform.position = startPoint;
            outerCircle.transform.position = startPoint;
        }

    }

    Vector2 getCanvasSpaceFromWorldSpace(Vector3 worldPosition)
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(worldPosition);
        Vector2 worldObjectScreenPosition = new Vector2(
        ((viewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
        ((viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));

        return worldObjectScreenPosition;
    }

    void setStartPointEndPointPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = getCanvasSpaceFromWorldSpace(Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z)));
        }
        if (Input.GetMouseButton(0))
        {
            endPoint = getCanvasSpaceFromWorldSpace(Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z)));
        }     
    }

    void setIsScreenPressed()
    {
        if (Input.GetMouseButton(0))
        {
            screenPressed = true;
        }
        else
        {
            screenPressed = false;
        }
    }

    public void setRunningSpeed()
    {
        speed = runningSpeed;
    }

    public void setWalkingSpeed()
    {
        speed = walkingSpeed;
    }

    private void FixedUpdate()
    {
        moveCharacter();
    }  

    void showJoystickWhenPressed()
    {
        if(Input.GetMouseButtonDown(0))
        {
            innerCircle.GetComponent<Image>().enabled = true;
            outerCircle.GetComponent<Image>().enabled = true;
        }
        if(!Input.GetMouseButton(0))
        {
            innerCircle.GetComponent<Image>().enabled = false;
            outerCircle.GetComponent<Image>().enabled = false;
        }
    }

    void moveCharacter()
    {
        if (!screenPressed)
        {
            return;
        }

        Vector2 offset = endPoint - startPoint;
        if (offset.magnitude < 0.1f)
        {
            return;
        }
        Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
        rotateCharacter(direction);
        moveForward();
        innerCircle.transform.position = new Vector2(startPoint.x + direction.x, startPoint.y + direction.y);
    }

    void rotateCharacter(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void doMoveCharacter(Vector2 direction)
    {
        GetComponent<Transform>().Translate(direction * speed * Time.deltaTime);
    }

    void moveForward()
    {
        GetComponent<Transform>().Translate(new Vector2(1, 0) * speed * Time.deltaTime);
    }
}
