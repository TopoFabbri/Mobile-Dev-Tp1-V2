using System;
using UnityEngine;


public class VirtualJoystick : MonoBehaviour
{
    [SerializeField] private GameObject handle;
    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private RectTransform rec;
    [SerializeField] private float maxLength = 3f;

    private int touchId = -1;

    public float X => handle.transform.position.x * sensitivity;
    public float Y => handle.transform.position.y * sensitivity;

    private void Awake()
    {
        if (Application.isMobilePlatform)
            Destroy(gameObject);
    }

    private void Update()
    {
        var touched = false;

        foreach (var touch in Input.touches)
        {
            if (CheckTouch(touch))
            {
                touched = true;
                SetHandle(touch);
            }
        }

        if (!touched)
            ResetHandle();
    }

    private bool CheckTouch(Touch touch)
    {
        var rect = rec.rect;
        rect.position += (Vector2)rec.position;

        Debug.DrawLine(rect.min, rect.max, Color.red);
        
        if (touch.phase == TouchPhase.Began && rect.Contains(touch.position))
            touchId = touch.fingerId;
        else if (touch.fingerId == touchId && touch.phase == TouchPhase.Ended)
            touchId = -1;

        return touch.fingerId == touchId;
    }

    private void SetHandle(Touch touch)
    {
        var position = touch.position;
        handle.transform.position = position;

        handle.transform.localPosition = Vector3.ClampMagnitude(handle.transform.localPosition, maxLength);
    }

    private void ResetHandle()
    {
        handle.transform.localPosition = Vector3.zero;
    }
}