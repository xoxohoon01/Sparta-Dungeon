using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            switch(other.GetComponent<ObjectInfo>().Type)
            {
                case ObjectType.JumpPlatform:
                    GetComponent<Rigidbody>().AddForce(Vector2.up * 10, ForceMode.Impulse);
                    break;
                case ObjectType.Item:
                    if (other.GetComponent<ItemScript>().data.name == "¼Óµµ ¾÷")
                    {
                        GetComponent<PlayerStatus>().moveSpeed = 10.0f;
                        Destroy(other.gameObject);
                    }
                    break;
            }
        }
    }
}
