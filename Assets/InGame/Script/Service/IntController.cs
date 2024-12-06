using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntController : MonoBehaviour
{

    public bool IsValueInteger<T>(T from)
    {
        return typeof(T) == typeof(int);
    }
}
