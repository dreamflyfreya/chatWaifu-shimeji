using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found. Make sure there's a camera in the scene tagged as 'MainCamera'.");
        }
    }

    private void OnMouseDown()
    {
        if (mainCamera == null) return;

        screenPoint = mainCamera.WorldToScreenPoint(transform.position);
        offset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        if (mainCamera == null) return;

        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(cursorScreenPoint) + offset;
        transform.position = cursorPosition;
    }
}
