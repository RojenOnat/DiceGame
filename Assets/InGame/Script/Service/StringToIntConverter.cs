using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringToIntConverter
{

    public int ConvertStringToInt(string from)
    {
        int result = int.Parse(from);
        return  result;
    }
}
