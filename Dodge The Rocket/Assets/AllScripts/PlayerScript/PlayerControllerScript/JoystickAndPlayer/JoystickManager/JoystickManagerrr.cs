using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class
JoystickManagerrr
: MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Image JoystickCircle;

    [SerializeField]
    private Image JoystickCenter;

    private Vector2 posInput;

   

    // Start is called before the first frame update
    void Start()
    {
        JoystickCircle = GetComponent<Image>();
        JoystickCenter = transform.GetChild(0).GetComponent<Image>();
    }

    public async void OnDrag(PointerEventData eventData)
    {
        if (
            RectTransformUtility
                .ScreenPointToLocalPointInRectangle(JoystickCircle
                    .rectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out posInput)
        )
        {
            posInput.x =
                posInput.x / (JoystickCircle.rectTransform.sizeDelta.x);
            posInput.y =
                posInput.y / (JoystickCircle.rectTransform.sizeDelta.y);

            // Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());
            //normalize
            if (posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }

            // joystick move
            JoystickCenter.rectTransform.anchoredPosition =
                new Vector2(posInput.x *
                    (JoystickCenter.rectTransform.sizeDelta.x / 1f),
                    posInput.y *
                    (JoystickCenter.rectTransform.sizeDelta.y / 1f));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag (eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        JoystickCenter.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        if (posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float inputVertical()
    {
        if (posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Vertical");
    }
}
