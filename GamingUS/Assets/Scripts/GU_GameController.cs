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
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[8]);
                nPlayer = 8;
                break;
            case 7:
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[7]);
                nPlayer = 7;
                break;
            case 6:
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[6]);
                nPlayer = 6;
                break;
            case 5:
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[5]);
                nPlayer = 5;
                break;
            case 4:
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[4]);
                nPlayer = 4;
                break;
            case 3:
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[3]);
                nPlayer = 3;
                break;
            case 2:
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[2]);
                nPlayer = 2;
                break;
            case 1:
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[1]);
                nPlayer = 1;
                break;
            case 0:
                if (naCena != null)
                {
                    Object.DestroyImmediate(naCena);
                }
                naCena = Instantiate(personagens[0]);
                nPlayer = 0;
                break;
            default:
                Debug.Log("Colocar o que não tem");
                break;
        }
    }
}
