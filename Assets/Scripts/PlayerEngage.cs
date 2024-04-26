using UnityEngine;
using Photon.Pun;

public class PlayerEngage : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject Captain, Combat;

    private void Start()
    {
        if (RoleManager.instance.captain)
            this.Captain.SetActive(true);

        if (RoleManager.instance.combat)
            this.Combat.SetActive(true);
    }
}
