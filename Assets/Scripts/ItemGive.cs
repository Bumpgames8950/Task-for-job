using UnityEngine;

public class ItemGive : MonoBehaviour
{
 
    Vector3 newPosition = new Vector3(-80.54f, 2.464f, 40.036f); // ������� ������ ���������
    void OnCollisionEnter(Collision collision)
    {

        collision.gameObject.transform.position = newPosition;


    }
}