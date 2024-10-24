using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    public float lookSensitivity = 0.05f;

    public Transform cameraContainer;
    public float minLookX = -25;
    public float maxLookX = 85;

    private float camCurrentRotationX;
    private Vector2 mouseDelta;

    public void CameraLook()
    {
        camCurrentRotationX += mouseDelta.y * lookSensitivity;
        camCurrentRotationX = Mathf.Clamp(camCurrentRotationX, minLookX, maxLookX);
        cameraContainer.localEulerAngles = new Vector3(-camCurrentRotationX, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Camera.main.transform.SetParent(cameraContainer.transform);
    }

    private void LateUpdate()
    {
        CameraLook();
    }
}
