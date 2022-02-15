using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GU_Minigame1 : MonoBehaviour
{
    [SerializeField] int clickButton;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject[] myObjects;

    // Start is called before the first frame update
    void Start()
    {
        clickButton = 0;
    }

    private void OnEnable()
    {
        clickButton = 0;
        for (int i = 0; i < myObjects.Length; i++)
        {
            myObjects[i].transform.SetSiblingIndex(Random.Range(0,3));
        }
    }

    public void ButtonClick(int button)
    {
        if (button == 1)
        {
            clickButton = 1;
        }
        else if (button == 2)
        {
            clickButton = 2;
        }
        else
        {
            clickButton = 3;
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

    public void OpenPanel()
    {
        gamePanel.SetActive(true);
    }

    public void ClosePanel()
    {
        gamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
