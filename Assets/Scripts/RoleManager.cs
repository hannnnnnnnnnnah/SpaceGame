using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : MonoBehaviour
{
    public static RoleManager instance;
    public bool captain, combat, financial;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
