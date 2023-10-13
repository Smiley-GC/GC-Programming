using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTag : MonoBehaviour
{
    public enum Type
    {
        NONE,
        SPEED_UP,
        SPEED_DOWN
    }

    public Type type = Type.NONE;

    // enums are the automatic way of doing the following:
    //const int NONE = 0;
    //const int SPEED_UP = 1;
    //const int SPEED_DOWN = 2;
    //int type = NONE;
}
