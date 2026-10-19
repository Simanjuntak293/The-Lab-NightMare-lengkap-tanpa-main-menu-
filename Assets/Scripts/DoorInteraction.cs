using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Animator doorAnimator; 
    [SerializeField] private GameObject interactUI; 

    private bool isPlayerNearby = false;
    private bool isOpen = false;

    private void Update()
    {
        // Jika player dekat dan menekan tombol E
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen; 
            doorAnimator.SetBool("isOpen", isOpen);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactUI != null) interactUI.SetActive(true); // Munculkan teks
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactUI != null) interactUI.SetActive(false); // Sembunyikan teks
        }
    }
}