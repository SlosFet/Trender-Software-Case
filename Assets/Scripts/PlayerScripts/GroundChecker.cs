using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isGrounded)
            isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isGrounded)
            isGrounded = false;
    }
}
