using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    Player player;
    Rigidbody Rb;

    void Start()
    {
        player = Player.Instance;
        Rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        player.GrabbedItem.position = transform.position;
        Rb.useGravity = false;
    }

    void OnMouseDrag()
    {
        Rb.velocity = (player.GrabbedItem.position - transform.position) * 5f;
    }

    void OnMouseUp()
    {
        Rb.useGravity = true;
    }
}
