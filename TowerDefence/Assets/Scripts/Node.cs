using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;
    private BuildManager manager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        manager = BuildManager.instance;

    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!manager.CanBuild)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("There is already a turret on this node - TODO: Display on screen!");
            return;
        }

        manager.BuildTurretOn(this);

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!manager.CanBuild)
        {
            return;
        }
        Debug.Log("CanBuild!" + manager.CanBuild);

        rend.material.color = (manager.HasMoney ? hoverColor : notEnoughMoneyColor);

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
