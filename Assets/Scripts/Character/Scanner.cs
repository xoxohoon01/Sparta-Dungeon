using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scanner : MonoBehaviour
{
    public GameObject scanDataPanel;
    public TMP_Text scanDataTitle;
    public TMP_Text scanDataContext;
    private void Awake()
    {
        scanDataPanel.SetActive(false);
    }
    private void Update()
    {
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
