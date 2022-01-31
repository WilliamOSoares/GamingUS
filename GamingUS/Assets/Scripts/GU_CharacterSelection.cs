using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GU_CharacterSelection : MonoBehaviour
{
    [SerializeField] int playerNumber;

    public void setPlayer(int playerNumber)
    {
        GU_PlayerController.eu.SetPlayer(playerNumber);
    }

    public void NextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
