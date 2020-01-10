using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInfo : MonoBehaviour
{   
    public enum Type{
        Fast, Tank, Med,
    }
    public GameObject enemy;
    public int Level;
    public Type type;
}
