using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    private Color startColor;
    private Renderer rend;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void UpgradeTurret()
    {
        if(PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Argent inssufisant pour l'amélioration");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;

        //supréssion de l'ancienne tourelle.
        Destroy(turret);

        //création de la nouvelle tourelle.
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isUpgraded = true;

        Debug.Log("Tourelle améliorée !");
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if(PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Argent inssufisant");
            return;
        }

        PlayerStats.money -= blueprint.cost;

        turretBlueprint = blueprint;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        Debug.Log("La tourelle a été construite.");
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        Destroy(turret);
        turretBlueprint = null; 
        isUpgraded = false;
    }

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if(!buildManager.canBuild) 
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());

    }

   private void OnMouseEnter()
   {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.canBuild)
        {
            return;
        }

        if(buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughMoneyColor;
        }

   }

   private void OnMouseExit()
   {
        rend.material.color = startColor;
   }
   
}
