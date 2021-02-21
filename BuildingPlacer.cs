using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour {

    private bool currentlyPlacing;
    private BuildingPreset curBuildingPreset;
 
    private float placementIndicatorUpdateRate = 0.05f;
    private float lastUpdateTime;
    private Vector3 curPlacementPos;
 
    public GameObject placementIndicator;
    public static BuildingPlacer inst;
 
    void Awake ()
    {
        inst = this;
    }

    public void BeginNewBuildingPlacement (BuildingPreset buildingPreset)
    {
        if(City.inst.money < buildingPreset.cost)
            return;

        currentlyPlacing = true;
        curBuildingPreset = buildingPreset;
        placementIndicator.SetActive(true);
    }

    public void CancelBuildingPlacement()
    {
        currentlyPlacing = false;
        placementIndicator.SetActive(false);
    }

    void PlaceBuilding ()
    {
        GameObject buildingObj = Instantiate(curBuildingPreset.prefab, curPlacementPos, Quaternion.identity);
        City.inst.OnPlaceBuilding(curBuildingPreset);
 
        CancelBuildingPlacement();
    }

    C#
void Update ()
{
    if(Input.GetKeyDown(KeyCode.Escape))
        CancelBuildingPlacement();

    if(Time.time - lastUpdateTime > placementIndicatorUpdateRate && currentlyPlacing)
    {
        lastUpdateTime = Time.time;

        curPlacementPos = Selector.inst.GetCurTilePosition();
        placementIndicator.transform.position = curPlacementPos;
    }

    if(currentlyPlacing && Input.GetMouseButtonDown(0))
    {
        PlaceBuilding();
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            CancelBuildingPlacement();
 
        if(Time.time - lastUpdateTime > placementIndicatorUpdateRate && currentlyPlacing)
        {
            lastUpdateTime = Time.time;
 
            curPlacementPos = Selector.inst.GetCurTilePosition();
            placementIndicator.transform.position = curPlacementPos;
        }   
 
        if(currentlyPlacing && Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
    }
}