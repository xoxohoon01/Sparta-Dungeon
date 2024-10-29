using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    // ���콺 �ΰ���
    public float lookSensitivity = 0.05f;

    public Transform cameraContainer;

    // ī�޶� �ִ� ���� ����
    public float minLookY = -25;
    public float maxLookY = 85;

    // ī�޶� ���� ���� ����
    private float camCurrentRotationY;

    // ���콺 ��Ÿ��
    private Vector2 mouseDelta;

    // ī�޶� ��Ÿ���� ȸ���� ����
    public void CameraLook()
    {
        // ī�޶� ���� ���� ����
        camCurrentRotationY += mouseDelta.y * lookSensitivity;
        camCurrentRotationY = Mathf.Clamp(camCurrentRotationY, minLookY, maxLookY);
        cameraContainer.localEulerAngles = new Vector3(-camCurrentRotationY, 0, 0);

        // ĳ���� �¿� ���� ����
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
