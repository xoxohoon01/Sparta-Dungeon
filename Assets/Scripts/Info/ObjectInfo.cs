using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    None,
    JumpPlatform,
    Item
}

public class ObjectInfo : MonoBehaviour
{
    public string Name;
    public string Description;
    public ObjectType Type;
    
}
