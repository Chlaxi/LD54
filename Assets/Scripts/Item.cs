using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string name;

    public void Use()
    {
        Debug.Log("*Chug chug*");
    }
}
