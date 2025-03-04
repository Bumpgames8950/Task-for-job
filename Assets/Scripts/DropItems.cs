using UnityEngine;
using UnityEngine.UI;

public class DropItems : MonoBehaviour
{
    public float pickupRange = 3f;       
    public Transform itemHoldPoint;      
    public Button dropButton;            
    public float dropForce = 5f;          

    private GameObject _heldItem;        

    void Start()
    {
        
        dropButton.gameObject.SetActive(false);
        dropButton.onClick.AddListener(DropItem);
        if (itemHoldPoint == null)
        {
            itemHoldPoint = new GameObject("ItemHoldPoint").transform;
            itemHoldPoint.SetParent(transform);
            itemHoldPoint.localPosition = new Vector3(0.5f, 0.5f, 1f); // Примерное положение перед игроком
        }
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            TryPickupItem();
        }
    }

    void TryPickupItem()
    {
        
        if (_heldItem != null) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            
            if (hit.collider.CompareTag("Pickable")) 
            {
                PickupItem(hit.collider.gameObject);
            }
        }
    }

    void PickupItem(GameObject item)
    {
        
        _heldItem = item;
        Rigidbody itemRb = item.GetComponent<Rigidbody>();
        if (itemRb != null)
        {
            itemRb.isKinematic = true;
            itemRb.useGravity = false;
        }
        item.transform.SetParent(itemHoldPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        dropButton.gameObject.SetActive(true);
    }

    void DropItem()
    {
        
        if (_heldItem == null) return;
        Rigidbody itemRb = _heldItem.GetComponent<Rigidbody>();
        if (itemRb != null)
        {
            itemRb.isKinematic = false;
            itemRb.useGravity = true;
        }
        _heldItem.transform.SetParent(null);
        itemRb.AddForce(itemHoldPoint.forward * dropForce, ForceMode.Impulse);
        _heldItem = null;
        dropButton.gameObject.SetActive(false);
    }
}
