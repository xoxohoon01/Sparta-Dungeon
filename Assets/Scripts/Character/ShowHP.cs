using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHP : MonoBehaviour
{
    public Image HPBar;
    public PlayerStatus status;

    private void Awake()
    {
        HPBar.type = Image.Type.Filled;
        HPBar.fillMethod = Image.FillMethod.Horizontal;
    }
    private void Update()
    {
        HPBar.fillAmount = status.HP / status.MaxHP;
    }
}
