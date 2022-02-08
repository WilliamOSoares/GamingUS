using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GU_Box : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (GU_PlayerController.caixas != null)
        {
            GU_PlayerController.caixas.Add(transform);
        }
    }

    public void Report()
    {
        Debug.Log("Reportado");
        Destroy(gameObject);
    }


}
