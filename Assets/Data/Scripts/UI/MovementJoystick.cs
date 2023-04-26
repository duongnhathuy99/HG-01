using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystick : MonoBehaviour
{

    private static MovementJoystick _instance;
    public static MovementJoystick Instance { get => _instance; }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickvec;
    Vector2 joystickTouchPos;
    Vector2 joystickOriginalPos;
    public float joystickRadius;

    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }
    public void PointerDown() 
    {
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickvec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius)
            joystick.transform.position = joystickTouchPos + joystickvec * joystickDist;
        else
            joystick.transform.position = joystickTouchPos + joystickvec * joystickRadius;
    }
    public void PointerUp()
    {
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
        joystickvec = Vector2.zero;
    }
}
