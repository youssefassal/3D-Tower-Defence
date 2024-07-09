﻿using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one");
            return;
        }
        instance = this;
    }



    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; }}
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }



    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log ("not enough money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;


        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log ("turret build! money left: " + PlayerStats.Money);
    }


    public void SelectTurretToBuilt(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }


}
