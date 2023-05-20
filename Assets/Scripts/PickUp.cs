using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public GameObject destroyEffect;
    public Vector3 Direction { get; set; }
    private GameObject itemHolding;

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(itemHolding)
            {

            }
            else
            {   //position + direcao do personagem magnitude = 1, radious, mask
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                if(pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }
    }
}
