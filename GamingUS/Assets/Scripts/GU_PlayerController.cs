using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class GU_PlayerController : MonoBehaviour
{

    [SerializeField] bool noControle;
    public static GU_PlayerController eu;

    // Componentes
    Rigidbody corpo;
    Transform avatar;
    Animator anim;

    // Movimento
    [SerializeField] InputAction wasd;
    Vector2 movimento;
    [SerializeField] float velocidadeMovimento;

    //Regras
    [SerializeField] bool impostor;
    [SerializeField] InputAction demitir;

    List<GU_PlayerController> alvos;
    public Collider minhaColisao;
    bool taDemitido;
    [SerializeField] GameObject caixaDemissao;

    private void Awake()
    {
        demitir.performed += demitirAlvo;
    }

    private void OnEnable()
    {
        wasd.Enable();
        demitir.Enable();
    }

    private void OnDisable()
    {
        wasd.Disable();
        demitir.Disable();
    }

    public void SetRole(bool newRole)
    {
        impostor = newRole;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GU_PlayerController alvoTemp = other.GetComponent<GU_PlayerController>();
            if (impostor)
            {
                if (alvoTemp.impostor)
                {
                    return;
                }
                else
                {
                    alvos.Add(alvoTemp);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GU_PlayerController alvoTemp = other.GetComponent<GU_PlayerController>();
            if (alvos.Contains(alvoTemp))
            {
                alvos.Remove(alvoTemp);
            }
        }
    }

    void demitirAlvo(InputAction.CallbackContext contexto)
    {
        if (contexto.phase == InputActionPhase.Performed)
        {
            if (alvos.Count == 0)
            {
                return;
            }
            else
            {
                if (alvos[alvos.Count-1].taDemitido)
                {
                    return;
                }
                transform.position = alvos[alvos.Count-1].transform.position;
                alvos[alvos.Count-1].Demitido();
                alvos.RemoveAt(alvos.Count-1);
            }
        }
    }

    public void Demitido()
    {
        taDemitido = true;
        anim.SetBool("isDead", taDemitido);
        minhaColisao.enabled = false;

        GU_Box caixaTemp = Instantiate(caixaDemissao,transform.position, transform.rotation).GetComponent<GU_Box>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (noControle)
        {
            eu = this;
        }
        alvos = new List<GU_PlayerController>();
        corpo = GetComponent<Rigidbody>();
        avatar = transform.GetChild(0);
        anim = GetComponent<Animator>();
        if (!noControle)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!noControle)
        {
            return;
        }

        movimento = wasd.ReadValue<Vector2>();
        if (movimento.x != 0)
        {
            avatar.localScale = new Vector2(Mathf.Sign(movimento.x), 1);
        }
        anim.SetFloat("Speed",movimento.magnitude);
    }

    private void FixedUpdate()
    {
        velocidadeMovimento = 10;
        corpo.velocity = movimento * velocidadeMovimento;
    }
}

