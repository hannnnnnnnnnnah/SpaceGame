using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject button, startMessage;
    public void Continue()
    {
        Destroy(this.startMessage);
        this.button.SetActive(true);
    }
}
