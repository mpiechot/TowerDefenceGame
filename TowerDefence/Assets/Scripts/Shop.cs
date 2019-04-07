using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public TurretBlueprint[] blueprints;

    private BuildManager manager;
    
    void Start()
    {
        manager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        manager.SelectTurret(blueprints[0]);
    }
    public void SelectMissleTurret()
    {
        manager.SelectTurret(blueprints[1]);
    }
    public void SelectLaserTurret()
    {
        manager.SelectTurret(blueprints[2]);
    }
}
