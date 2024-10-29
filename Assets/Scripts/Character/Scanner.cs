using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scanner : MonoBehaviour
{
    // 오브젝트 정보 표시 패널
    public GameObject scanDataPanel;
    public TMP_Text scanDataTitle;
    public TMP_Text scanDataContext;

    private void Awake()
    {
        scanDataPanel.SetActive(false);
    }
    private void Update()
    {
        // 카메라 기준 forward방향 100만큼 특정 레이어만 레이캐스트
        // 캐스트 성공시 해당 오브젝트의 ObjectInfo에서 정보를 가져와 패널에 표시
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f, LayerMask.GetMask("Interactable"));
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100f, Color.green);
        if (hit.collider != null)
        {
            scanDataPanel.SetActive(true);
            scanDataTitle.text = hit.collider.GetComponent<ObjectInfo>().Name;
            scanDataContext.text = hit.collider.GetComponent<ObjectInfo>().Description;
        }
        else
        {
            scanDataPanel.SetActive(false);
        }
    }
}
