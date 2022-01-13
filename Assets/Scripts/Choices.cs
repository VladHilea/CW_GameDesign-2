using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choices : MonoBehaviour
{
    public void Help()
    {
        Debug.Log("Help Villagers");
    }

    public void UpgradeWeapons()
    {
        Debug.Log("Upgrade Weapons");
    }

    public void Kill()
    {
        SceneManager.LoadScene("BadEnding");
        Debug.Log("Kill the villagers and take over the village");
    }

    public void LeaveVillage()
    {
        SceneManager.LoadScene("NeutralEnding");
        Debug.Log("Leave the village");
    }
}
