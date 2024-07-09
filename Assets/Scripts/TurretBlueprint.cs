using UnityEngine;
using System.Collections;
using System;


[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public static implicit operator GameObject(TurretBlueprint v)
    {
        throw new NotImplementedException();
    }
}
