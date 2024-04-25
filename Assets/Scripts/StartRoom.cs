using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class StartRoom : MonoBehaviour
{
    [SerializeField] GameObject Roles, Start;

    public void ChooseCaptain()
    {
        RoleManager.instance.combat = false;
        RoleManager.instance.captain = true;
        RoleChosen();
    }

    public void ChooseCombat()
    {
        RoleManager.instance.captain = false;
        RoleManager.instance.combat = true;
        RoleChosen();
    }

    public void RoleChosen()
    {
        Roles.SetActive(false);
        Start.SetActive(true);
    }
}
