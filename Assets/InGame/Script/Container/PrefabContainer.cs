using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds prefabs within it.
/// </summary>
public class PrefabContainer : MonoBehaviour
{
    [Tooltip("The prefab of the tile object.")]
    public GameObject TilePrefab;
    
    [Tooltip("The prefab of the apple object.")]
    public GameObject ApplePrefab;
    
    [Tooltip("The prefab of the pear object.")]
    public GameObject PearPrefab;
    
    [Tooltip("The prefab of the strawberry object.")]
    public GameObject StrawberryPrefab;

    [Tooltip("The prefab of the dice object.")]
    public GameObject DicePrefab;
}
