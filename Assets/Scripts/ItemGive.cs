using UnityEngine;

public class ItemGive : MonoBehaviour
{
 
    Vector3 newPosition = new Vector3(-80.54f, 2.464f, 40.036f); // Позиция внутри грузовика
    void OnCollisionEnter(Collision collision)
    {

        collision.gameObject.transform.position = newPosition;


    }
}