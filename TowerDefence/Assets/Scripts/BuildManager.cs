using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Multiple BuildManagers?!");
        }
        instance = this;
        Debug.Log("Awake: " + CanBuild);
    }

    //[HideInInspector]
    public TurretBlueprint turretToBuild = null;

    public GameObject buildEffect;

    public int availableMoney = 100;

    public bool CanBuild { get { return turretToBuild.prefab != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.costs; } }

    public void SelectTurret(TurretBlueprint blueprint)
    {
        turretToBuild = blueprint;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.costs)
        {
            Debug.Log("Not Enough Money!");
            return;
        }
        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        node.turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), node.transform.rotation);
        PlayerStats.money -= turretToBuild.costs;
        Debug.Log("Money Left: " + PlayerStats.money);

        availableMoney -= turretToBuild.costs;
    }
}
