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

    public static List<Transform> caixas;
    List<Transform> caixasEncontr;

    [SerializeField] InputAction report;
    [SerializeField] LayerMask ignoreCaixa;

    private void Awake()
    {
        demitir.performed += demitirAlvo;
        report.performed += reportCaixa;
    }

    private void OnEnable()
    {
        wasd.Enable();
        demitir.Enable();
        report.Enable();
    }

    private void OnDisable()
    {
        wasd.Disable();
        demitir.Disable();
        report.Disable();
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
        gameObject.layer = 8;

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
        caixas = new List<Transform>();
        caixasEncontr = new List<Transform>();
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

        if (caixas.Count>0)
        {
            procuraCaixa();
        }
    }

    void procuraCaixa()
    {
        foreach (Transform caixa in caixas)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, caixa.position - transform.position);
            Debug.DrawRay(transform.position, caixa.position - transform.position, Color.cyan);
            if (Physics.Raycast(ray, out hit, 1000f,~ignoreCaixa))
            {
                if (hit.transform == caixa)
                {
                    //Debug.Log(hit.transform.name);
                    //Debug.Log(caixasEncontr.Count);
                    if (caixasEncontr.Contains(caixa.transform))
                        return;
                    caixasEncontr.Add(caixa.transform);
                }
                else
                {
                    caixasEncontr.Remove(caixa.transform);
                }
            }
        }
    }

    private void reportCaixa(InputAction.CallbackContext obj)
    {
        if (caixasEncontr == null)
            return;
        if (caixasEncontr.Count == 0)
            return;
        Transform tempCaixa = caixasEncontr[caixasEncontr.Count - 1];
        caixas.Remove(tempCaixa);
        caixasEncontr.Remove(tempCaixa);
        tempCaixa.GetComponent<GU_Box>().Report();
    }

    private void FixedUpdate()
    {
        velocidadeMovimento = 10;
        corpo.velocity = movimento * velocidadeMovimento;
    }
}

