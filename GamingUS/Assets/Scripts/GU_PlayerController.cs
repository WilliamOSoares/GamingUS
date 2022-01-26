using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GU_PlayerController : MonoBehaviour
{

    // Componentes
    Rigidbody corpo;
    Transform avatar;
    Animator anim;
    // Movimento
    [SerializeField] InputAction wasd;
    Vector2 movimento;
    [SerializeField] float velocidadeMovimento;

    private void OnEnable()
    {
        wasd.Enable();
    }

    private void OnDisable()
    {
        wasd.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponent<Rigidbody>();
        avatar = transform.GetChild(0);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimento = wasd.ReadValue<Vector2>();
        if (movimento.x != 0)
        {
            avatar.localScale = new Vector2(Mathf.Sign(movimento.x), 1);
        }
        anim.SetFloat("Speed",movimento.magnitude);
    }

    private void FixedUpdate()
    {
        corpo.velocity = movimento * velocidadeMovimento;
    }
}

