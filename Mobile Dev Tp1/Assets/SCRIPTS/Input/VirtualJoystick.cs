using UnityEngine;

public class VirtualJoystick : MonoBehaviour
{
    [SerializeField] protected GameObject handle;
    [SerializeField] protected RectTransform rec;
    [SerializeField] protected float maxLength = 100f;

    private int touchId = -1;

    public float X => handle.transform.localPosition.normalized.x;
    public float Y => handle.transform.localPosition.normalized.y;

    protected virtual void Awake()
    {
        if (!(Application.isMobilePlatform || Application.isEditor))
            Destroy(gameObject);
    }

    protected virtual void Update()
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

    protected bool CheckTouch(Touch touch)
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

    protected void SetHandle(Touch touch)
    {
        var position = touch.position;
        handle.transform.position = position;

        handle.transform.localPosition = Vector3.ClampMagnitude(handle.transform.localPosition, maxLength);
    }

    protected void ResetHandle()
    {
        handle.transform.localPosition = Vector3.zero;
    }
}