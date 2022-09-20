using UnityEngine;

public class LoseTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject LoseMenu;

    [SerializeField]
    private GameObject swipePanel;

    private Mouse mouse;


    private void Start()
    {
        mouse = GetComponent<Mouse>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            mouse.enabled = false;
            swipePanel.SetActive(false);
            LoseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
