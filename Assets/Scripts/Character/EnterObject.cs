using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterObject : MonoBehaviour
{
    IEnumerator speedUpCoroutine;
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
                        if (speedUpCoroutine != null) StopCoroutine(speedUpCoroutine);
                        GetComponent<PlayerStatus>().moveSpeed = 10.0f;
                        speedUpCoroutine = SpeedUp(other.GetComponent<ItemScript>().data.duration);
                        StartCoroutine(speedUpCoroutine);
                        Destroy(other.gameObject);
                    }
                    break;
            }
        }
    }

    IEnumerator SpeedUp(float _duration)
    {
        yield return new WaitForSeconds(_duration);
        GetComponent<PlayerStatus>().moveSpeed = 5.0f;
    }
}
