using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GU_CharacterSelection : MonoBehaviour
{
    [SerializeField] int playerNumber;
    [SerializeField] GameObject panel;

    public void setPlayer(int playerNumber)
    {
        GU_GameController.Instancia.SetPlayer(playerNumber);        
    }

    public void NextScene(int sceneIndex)
    {
        if (GU_GameController.Instancia.naCena==null)
        {
            Debug.Log("Escolha um personagem");
        }
        else
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
