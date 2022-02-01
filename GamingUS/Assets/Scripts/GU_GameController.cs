using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GU_GameController : MonoBehaviour
{
    private static GU_GameController _instancia;
    public static GU_GameController Instancia
    {
        get
        {
            if (_instancia == null)
            {
                _instancia = FindObjectOfType<GU_GameController>();
                if (_instancia == null)
                {
                    GameObject gameController = Instantiate(Resources.Load<GameObject>("GameController"));
                    _instancia = gameController.GetComponent<GU_GameController>();
                }
            }            
            return _instancia;
        }
    }

    //Personagens
    public GameObject[] personagens;
    public GameObject naCena;
    private int nPlayer = -1;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (naCena == null)
        {
            if (nPlayer >= 0)
            {
                naCena = Instantiate(personagens[nPlayer]);
            }
        }
    }

    public void SetPlayer(int playerNumber)
    {
        switch (playerNumber)
        {
            case 8:
                Debug.Log("N�mero 8");
                break;
            case 7:
                Debug.Log("N�mero 7");
                break;
            case 6:
                Debug.Log("N�mero 6");
                break;
            case 5:
                Debug.Log("N�mero 5");
                break;
            case 4:
                Debug.Log("N�mero 4");
                break;
            case 3:
                Debug.Log("N�mero 3");
                break;
            case 2:
                Debug.Log("N�mero 2");
                break;
            case 1:
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[1]);
                nPlayer = 1;
                Debug.Log("N�mero 1");
                break;
            case 0:
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[0]);
                nPlayer = 0;
                Debug.Log("N�mero 0");
                break;
            default:
                Debug.Log("Colocar o que n�o tem");
                break;
        }
    }
}
