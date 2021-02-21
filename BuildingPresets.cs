using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(filename = "Building Preset", menuName = "New Building Preset")]
public class BuildingPreset : ScriptableObject {

    public string displayName;
    public int cost;
    public int costPerTurn;
    public GameObject prefab;

    public int population;
    public int jobs;
    public int food;

    /// Factory = cost-20, CostPerTern-5, pop-0/jobs-10/food-0
    /// Farm = cost-10, CostPerTern-5, pop-0/jobs-0/food-5
    /// House = cost-10, CostPerTurn-5 pop-10/jobs-0/food-0
    /// Road = cost-5, CostPerTurn-5 pop-0/jobs-0/food-0
}