using UnityEngine;
using Unity.Netcode;

public class PlayerEngage : NetworkBehaviour
{
    [SerializeField] bool tabletUser, shipMover;
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
        if (tabletUser)
            UseTablet();
    }

    void UseTablet()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
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

    void ShipMove()
    {
        transform.Translate(Vector3.forward);
    }
}
