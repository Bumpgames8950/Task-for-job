using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public GameObject interactionHintPanel; // Подсказка при подходе к двери
    public Button yesButton;           
    public Button noButton;            
    public GameObject door;               

    private bool _isInRange;             

    void Start()
    {
        
        interactionHintPanel.SetActive(false);

        
        yesButton.onClick.AddListener(OpenDoor);
        noButton.onClick.AddListener(CloseHint);
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player")) 
        {
            _isInRange = true;
            ShowHint();
        }
    }

    void OnTriggerExit(Collider other)
    {
     
        if (other.CompareTag("Player"))
        {
            _isInRange = false;
            CloseHint();
        }
    }

    void ShowHint()
    {
       
        interactionHintPanel.SetActive(true);
    }

    void CloseHint()
    {
        
        interactionHintPanel.SetActive(false);
    }

    void OpenDoor()
    {
       
        Destroy(door);

       
        CloseHint();
    }
}
