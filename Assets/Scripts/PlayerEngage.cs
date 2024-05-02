using UnityEngine;
using Photon.Pun;

public class PlayerEngage : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject Captain, Combat;

    private void Start()
    {
        if (RoleManager.instance.captain && photonView.IsMine)
            this.Captain.SetActive(true);

        if (RoleManager.instance.combat && photonView.IsMine)
            this.Combat.SetActive(true);
    }
}
