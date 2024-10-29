using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPanel : MonoBehaviour
{
    public float jumpPanelPower;
    bool isJumpPanel = false;
    private Rigidbody _rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "JumpPanel")
        {
            isJumpPanel = true;
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        OnJumpPanel();
    }

    void OnJumpPanel()
    {
        if (isJumpPanel)
        {
            _rigidbody.AddForce(Vector2.up * jumpPanelPower, ForceMode.Impulse);
        }
    }
}
