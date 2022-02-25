using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GU_Minigame1 : MonoBehaviour
{
    [SerializeField] int clickButton;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject gamePanelDesafio;
    [SerializeField] GameObject gamePanelAtor;
    [SerializeField] GameObject gamePanelEspaco;
    [SerializeField] GameObject gamePanelItem;
    [SerializeField] GameObject gamePanelRegra;
    [SerializeField] GameObject gamePanelInteracao;
    [SerializeField] GameObject[] myObjects;
    [SerializeField] Text[] textos;
    public Text butaoDesafio;
    public Text butaoAtor;
    public Text butaoEspaco;
    public Text butaoItem;
    public Text butaoRegra;
    public Text butaoInteracao;
    public Text avisoDesafio;
    public Text avisoAtor;
    public Text avisoEspaco;
    public Text avisoItem;
    public Text avisoRegra;
    public Text avisoInteracao;
    private bool acertou;

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
        switch (button)
        {
            case 1:
                clickButton = 1;
                myObjects[0].GetComponent<Image>().color = Color.green;
                myObjects[1].GetComponent<Image>().color = Color.white;
                myObjects[2].GetComponent<Image>().color = Color.white;
                myObjects[3].GetComponent<Image>().color = Color.white;
                myObjects[4].GetComponent<Image>().color = Color.white;
                myObjects[5].GetComponent<Image>().color = Color.white;
                break;
            case 2:
                clickButton = 2;
                myObjects[0].GetComponent<Image>().color = Color.white;
                myObjects[1].GetComponent<Image>().color = Color.green;
                myObjects[2].GetComponent<Image>().color = Color.white;
                myObjects[3].GetComponent<Image>().color = Color.white;
                myObjects[4].GetComponent<Image>().color = Color.white;
                myObjects[5].GetComponent<Image>().color = Color.white;
                break;
            case 3:
                clickButton = 3;
                myObjects[0].GetComponent<Image>().color = Color.white;
                myObjects[1].GetComponent<Image>().color = Color.white;
                myObjects[2].GetComponent<Image>().color = Color.green;
                myObjects[3].GetComponent<Image>().color = Color.white;
                myObjects[4].GetComponent<Image>().color = Color.white;
                myObjects[5].GetComponent<Image>().color = Color.white;
                break;
            case 4:
                clickButton = 4;
                myObjects[0].GetComponent<Image>().color = Color.white;
                myObjects[1].GetComponent<Image>().color = Color.white;
                myObjects[2].GetComponent<Image>().color = Color.white;
                myObjects[3].GetComponent<Image>().color = Color.green;
                myObjects[4].GetComponent<Image>().color = Color.white;
                myObjects[5].GetComponent<Image>().color = Color.white;
                break;
            case 5:
                clickButton = 5;
                myObjects[0].GetComponent<Image>().color = Color.white;
                myObjects[1].GetComponent<Image>().color = Color.white;
                myObjects[2].GetComponent<Image>().color = Color.white;
                myObjects[3].GetComponent<Image>().color = Color.white;
                myObjects[4].GetComponent<Image>().color = Color.green;
                myObjects[5].GetComponent<Image>().color = Color.white;
                break;
            default:
                clickButton = 6;
                myObjects[0].GetComponent<Image>().color = Color.white;
                myObjects[1].GetComponent<Image>().color = Color.white;
                myObjects[2].GetComponent<Image>().color = Color.white;
                myObjects[3].GetComponent<Image>().color = Color.white;
                myObjects[4].GetComponent<Image>().color = Color.white;
                myObjects[5].GetComponent<Image>().color = Color.green;
                break;
        }
    }

    public void Confirma()
    {
        Debug.Log("Confirmou");
        gamePanel.SetActive(false);
    }

    public void ConfirmaDesafio()
    {
        switch (clickButton)
        {
            case 0:
                avisoDesafio.color = Color.red;
                avisoDesafio.text = "Por favor, selecione uma US na cafeteria";
                break;
            case 6:
                avisoDesafio.color = Color.green;
                avisoDesafio.text = "Bom trabalho, pode fechar";
                acertou = true;
                myObjects[5].GetComponent<Image>().color = Color.white;
                myObjects[5].GetComponent<Button>().GetComponentInChildren<Text>().text = "--";
                myObjects[5].GetComponent<Button>().enabled = false;
                break;
            default:
                avisoDesafio.color = Color.red;
                avisoDesafio.text = "Isso não é uma US de Desafio";
                break;
        }
    }
    public void ConfirmaAtor()
    {
        switch (clickButton)
        {
            case 0:
                avisoAtor.color = Color.red;
                avisoAtor.text = "Por favor, selecione uma US na cafeteria";
                break;
            case 2:
                avisoAtor.color = Color.green;
                avisoAtor.text = "Bom trabalho, pode fechar";
                acertou = true;
                myObjects[1].GetComponent<Image>().color = Color.white;
                myObjects[1].GetComponent<Button>().GetComponentInChildren<Text>().text = "--";
                myObjects[1].GetComponent<Button>().enabled = false;
                break;
            default:
                avisoAtor.color = Color.red;
                avisoAtor.text = "Isso não é uma US de Ator";
                break;
        }
    }
    public void ConfirmaEspaco()
    {
        switch (clickButton)
        {
            case 0:
                avisoEspaco.color = Color.red;
                avisoEspaco.text = "Por favor, selecione uma US na cafeteria";
                break;
            case 1:
                avisoEspaco.color = Color.green;
                avisoEspaco.text = "Bom trabalho, pode fechar";
                acertou = true;
                myObjects[0].GetComponent<Image>().color = Color.white;
                myObjects[0].GetComponent<Button>().GetComponentInChildren<Text>().text = "--" ;
                myObjects[0].GetComponent<Button>().enabled = false;
                break;
            default:
                avisoEspaco.color = Color.red;
                avisoEspaco.text = "Isso não é uma US de Espaço";
                break;
        }
    }
    public void ConfirmaItem()
    {
        switch (clickButton)
        {
            case 0:
                avisoItem.color = Color.red;
                avisoItem.text = "Por favor, selecione uma US na cafeteria";
                break;
            case 3:
                avisoItem.color = Color.green;
                avisoItem.text = "Bom trabalho, pode fechar";
                myObjects[2].GetComponent<Image>().color = Color.white;
                myObjects[2].GetComponent<Button>().GetComponentInChildren<Text>().text = "--";
                myObjects[2].GetComponent<Button>().enabled = false;
                acertou = true;
                break;
            default:
                avisoItem.color = Color.red;
                avisoItem.text = "Isso não é uma US de Item";
                break;
        }
    }
    public void ConfirmaRegra()
    {
        switch (clickButton)
        {
            case 0:
                avisoRegra.color = Color.red;
                avisoRegra.text = "Por favor, selecione uma US na cafeteria";
                break;
            case 5:
                avisoRegra.color = Color.green;
                avisoRegra.text = "Bom trabalho, pode fechar";
                acertou = true;
                myObjects[4].GetComponent<Image>().color = Color.white;
                myObjects[4].GetComponent<Button>().GetComponentInChildren<Text>().text = "--";
                myObjects[4].GetComponent<Button>().enabled = false;
                break;
            default:
                avisoRegra.color = Color.red;
                avisoRegra.text = "Isso não é uma US de Regra";
                break;
        }
    }
    public void ConfirmaInteracao()
    {
        switch (clickButton)
        {
            case 0:
                avisoInteracao.color = Color.red;
                avisoInteracao.text = "Por favor, selecione uma US na cafeteria";
                break;
            case 4:
                avisoInteracao.color = Color.green;
                avisoInteracao.text = "Bom trabalho, pode fechar";
                acertou = true;                
                myObjects[3].GetComponent<Image>().color = Color.white;
                myObjects[3].GetComponent<Button>().GetComponentInChildren<Text>().text = "--";
                myObjects[3].GetComponent<Button>().enabled = false;
                break;
            default:
                avisoInteracao.color = Color.red;
                avisoInteracao.text = "Isso não é uma US de Interação";
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
        apagaTexto();
        gamePanelDesafio.SetActive(false);
    }
    public void ClosePanelAtor()
    {
        avisoAtor.text = "";
        apagaTexto();
        gamePanelAtor.SetActive(false);
    }
    public void ClosePanelEspaco()
    {
        avisoEspaco.text = "";
        apagaTexto();
        gamePanelEspaco.SetActive(false);
    }
    public void ClosePanelItem()
    {
        avisoItem.text = "";
        apagaTexto();
        gamePanelItem.SetActive(false);
    }
    public void ClosePanelRegra()
    {
        avisoRegra.text = "";
        apagaTexto();
        gamePanelRegra.SetActive(false);
    }
    public void ClosePanelInteracao()
    {
        avisoInteracao.text = "";
        apagaTexto();
        gamePanelInteracao.SetActive(false);
    }

    private void apagaTexto()
    {
        if (acertou)
        {
            clickButton = 0;
            butaoDesafio.text = "--";
            butaoAtor.text = "--";
            butaoEspaco.text = "--";
            butaoItem.text = "--";
            butaoRegra.text = "--";
            butaoInteracao.text = "--";
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (clickButton != 0 && (gamePanelAtor.activeSelf || gamePanelDesafio.activeSelf || gamePanelEspaco.activeSelf || gamePanelInteracao.activeSelf || gamePanelItem.activeSelf || gamePanelRegra.activeSelf)){
            butaoDesafio.text = textos[clickButton-1].text;
            butaoAtor.text = textos[clickButton - 1].text;
            butaoEspaco.text = textos[clickButton - 1].text;
            butaoItem.text = textos[clickButton - 1].text;
            butaoRegra.text = textos[clickButton - 1].text;
            butaoInteracao.text = textos[clickButton - 1].text;
        }
    }
}
