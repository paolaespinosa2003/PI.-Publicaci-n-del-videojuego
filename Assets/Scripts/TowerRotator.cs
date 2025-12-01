using UnityEngine;
using UnityEngine.EventSystems;

// TowerRotator: touch-native, blocks rotation when touching UI elements.
public class TowerRotator : MonoBehaviour
{
    public float rotationSpeed = 70f;
    public float sensitivity = 1f;

    float lastTouchX;
    bool dragging = false;

    void Update()
    {
        // If pointer over UI, ignore rotation input
        if (EventSystem.current != null && Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            return;

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                dragging = true;
                lastTouchX = t.position.x;
            }
            else if (t.phase == TouchPhase.Moved && dragging)
            {
                float deltaX = t.position.x - lastTouchX;
                lastTouchX = t.position.x;

                transform.Rotate(
                    Vector3.up,
                    -deltaX * sensitivity * rotationSpeed * Time.deltaTime
                );
            }
            else if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                dragging = false;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            float delta = Input.GetAxis("Mouse X");
            transform.Rotate(
                Vector3.up,
                -delta * sensitivity * rotationSpeed * Time.deltaTime
            );
        }
    }
}