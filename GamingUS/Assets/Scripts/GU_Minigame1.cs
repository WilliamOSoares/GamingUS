using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GU_Minigame1 : MonoBehaviour
{
    [SerializeField] int clickButton;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject gamePanelDesafio;
    [SerializeField] GameObject[] myObjects;
    [SerializeField] Text[] textos;
    public Text butaoDesafio;
    public Text avisoDesafio;

    // Start is called before the first frame update
    void Start()
    {
        clickButton = 0;
    }

    private void OnEnable()
    {
        clickButton = 0;
    }

    public void ButtonClick(int button)
    {
        if (button == 1)
        {
            clickButton = 1;
            myObjects[0].GetComponent<Image>().color = Color.green;
            myObjects[1].GetComponent<Image>().color = Color.white;
            myObjects[2].GetComponent<Image>().color = Color.white;
        }
        else if (button == 2)
        {
            clickButton = 2;
            myObjects[0].GetComponent<Image>().color = Color.white;
            myObjects[1].GetComponent<Image>().color = Color.green;
            myObjects[2].GetComponent<Image>().color = Color.white;
        }
        else
        {
            clickButton = 3;
            myObjects[0].GetComponent<Image>().color = Color.white;
            myObjects[1].GetComponent<Image>().color = Color.white;
            myObjects[2].GetComponent<Image>().color = Color.green;
        }
    }

    public void Confirma()
    {
        if(clickButton == 2)
        {
            Debug.Log("Acertou");
            gamePanel.SetActive(false);
        }
        else
        {
            Debug.Log("Errou");
            OnEnable();
        }
    }

    public void ConfirmaDesafio()
    {
        switch (clickButton)
        {
            case 0:
                avisoDesafio.color = Color.red;
                avisoDesafio.text = "Por favor, selecione uma US na cafeteria";
                break;
            case 3:
                avisoDesafio.color = Color.green;
                avisoDesafio.text = "*Teste*Bom trabalho, pode fechar";
                break;
            default:
                avisoDesafio.color = Color.red;
                avisoDesafio.text = "Isso não é uma US de Desafio";
                break;
        }
    }

    public void OpenPanel()
    {
        gamePanel.SetActive(true);
    }

    public void ClosePanel()
    {
        gamePanel.SetActive(false);
    }

    public void OpenPanelDesafio()
    {
        gamePanelDesafio.SetActive(true);
    }

    public void ClosePanelDesafio()
    {
        avisoDesafio.text = "";
        gamePanelDesafio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (clickButton != 0){
            butaoDesafio.text = textos[clickButton-1].text;
        }
    }
}
