using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class FinancialAdvisor : NetworkBehaviour
{
    [SerializeField] Vector3 position1, position2;

    private void Start()
    {
        if (IsHost)
            gameObject.transform.position = position1;

        if (IsClient)
            gameObject.transform.position = position2;
    }
}
