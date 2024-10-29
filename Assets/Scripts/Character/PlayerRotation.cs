using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    // 마우스 민감도
    public float lookSensitivity = 0.05f;

    public Transform cameraContainer;

    // 카메라 최대 상하 각도
    public float minLookY = -25;
    public float maxLookY = 85;

    // 카메라 현재 상하 각도
    private float camCurrentRotationY;

    // 마우스 델타값
    private Vector2 mouseDelta;

    // 카메라 델타값을 회전에 적용
    public void CameraLook()
    {
        // 카메라 상하 각도 조절
        camCurrentRotationY += mouseDelta.y * lookSensitivity;
        camCurrentRotationY = Mathf.Clamp(camCurrentRotationY, minLookY, maxLookY);
        cameraContainer.localEulerAngles = new Vector3(-camCurrentRotationY, 0, 0);

        // 캐릭터 좌우 각도 조절
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
