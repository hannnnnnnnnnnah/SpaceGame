using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngage : MonoBehaviour
{
    [SerializeField] GameObject tablet;
    private PlayerLook playerLook;
    bool tabletOpen = false;
    Animator animator;

    void Start()
    {
        playerLook = GetComponent<PlayerLook>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (!tabletOpen)
            {
                playerLook.rotate = false;
                tablet.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                animator.SetBool("Tablet", true);
                tabletOpen = true;
            }
            else
            {
                playerLook.rotate = true;
                tablet.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                animator.SetBool("Tablet", false);
                tabletOpen = false;
            }

        }
    }
}
