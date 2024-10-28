using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterJumpPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            if (other.GetComponent<ObjectInfo>().Name == "Á¡ÇÁ´ë")
            {
                GetComponent<Rigidbody>().AddForce(Vector2.up * 10, ForceMode.Impulse);
            }
        }
    }
}
