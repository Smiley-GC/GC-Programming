using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTag : MonoBehaviour
{
    public enum Type
    {
        NONE,
        SPEED_UP,
        SPEED_DOWN,
    }

    public Type type = Type.NONE;
}
