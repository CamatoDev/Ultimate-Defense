using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint stantardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamerTurret;   

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStantardTurret()
    {
        Debug.Log("Tourelle stantard selectionnée"); 
        buildManager.SelectTurretToBuild(stantardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Lance missile selectionnée"); 
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamerTurret()
    {
        Debug.Log("Tourelle laser selectionnée"); 
        buildManager.SelectTurretToBuild(laserBeamerTurret);
    }


}
