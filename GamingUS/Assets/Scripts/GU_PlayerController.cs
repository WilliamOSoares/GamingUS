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

    //Personagens
    [SerializeField] GameObject[] personagens;
    public int playerNumber;

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

    public void SetPlayer(int playerNumber)
    {
        switch (playerNumber)
        {
            case 8:
                Debug.Log("Número 8");
                break;
            case 7:
                Debug.Log("Número 7");
                break;
            case 6:
                Debug.Log("Número 6");
                break;
            case 5:
                Debug.Log("Número 5");
                break;
            case 4:
                Debug.Log("Número 4");
                break;
            case 3:
                Debug.Log("Número 3");
                break;
            case 2:
                Debug.Log("Número 2");
                break;
            case 1:
                GameObject newObject1 = Instantiate(personagens[1]);
                newObject1.name = personagens[1].name;
                Undo.RegisterCreatedObjectUndo(newObject1, "Replace With Prefabs");
                newObject1.transform.parent = this.transform.parent;
                newObject1.transform.localPosition = this.transform.localPosition;
                newObject1.transform.localRotation = this.transform.localRotation;
                newObject1.transform.localScale = this.transform.localScale;
                newObject1.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
                eu = newObject1.GetComponent<GU_PlayerController>();
                Undo.DestroyObjectImmediate(this);
                Debug.Log("Número 1");
                break;
            case 0:
                GameObject newObject0 = Instantiate(personagens[0]);
                newObject0.name = personagens[0].name;
                Undo.RegisterCreatedObjectUndo(newObject0, "Replace With Prefabs");
                newObject0.transform.parent = this.transform.parent;
                newObject0.transform.localPosition = this.transform.localPosition;
                newObject0.transform.localRotation = this.transform.localRotation;
                newObject0.transform.localScale = this.transform.localScale;
                newObject0.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
                eu = newObject0.GetComponent<GU_PlayerController>();
                Undo.DestroyObjectImmediate(this);        
                //GU_PlayerController temp = Instantiate(personagens[0], transform.position, transform.rotation).GetComponent<GU_PlayerController>();
                //eu = temp;
                //this.gameObject = personagens[0];
                Debug.Log("Número 0");
                break;
            default:
                Debug.Log("Colocar o que não tem");
                break;
        }
    }
}

