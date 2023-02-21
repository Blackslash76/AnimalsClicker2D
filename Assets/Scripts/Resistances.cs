using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resistances
{
    [Range(0f, 1f)]
    public float fire, 
        water, 
        ice, 
        lightning, 
        holy, 
        shadow = 0f;
}
