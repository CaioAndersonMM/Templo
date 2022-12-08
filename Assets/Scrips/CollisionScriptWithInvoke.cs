using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScriptWithInvoke : MonoBehaviour
{
    public Canvas texto;
    public GameObject portasPlayer;
    public GameObject portasOraculo;
    public bool enter;

    public Material materialPlayer;
    public Material materialOraculo;

    public GameObject verificador;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colidindo com " + other.name);
        texto.enabled = true;
        enter = true;
        portasOraculo = GameObject.Find(other.name); //Pegando o Oráculo da colisão 

        verificador.transform.position = portasPlayer.transform.position;

        // Para isso os Oráculos tiveram que receber um nome único

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saiu da colisão com " + other.name);
        texto.enabled = false;
        enter = false;
        portasPlayer.SetActive(false);
        portasOraculo.transform.GetChild(0).gameObject.SetActive(false);
        materialPlayer.color = Color.red;
        materialOraculo.color = Color.red;

        verificador.SetActive(false); //desativar também o verificador
    }
    private void Start()
    {
        materialPlayer.color = Color.red;
        materialOraculo.color = Color.red;

        //As cores dos materiais devem começar vermelhos!
    }
    void Update()
    {
        if (enter == true)
        {
            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter"))
            {
                texto.enabled = false;
                portasOraculo.transform.GetChild(0).gameObject.SetActive(true); //Ativando o filho (Porta de Controle) do Oráculo
                portasPlayer.SetActive(true);

                Invoke("MovePlayerToOraculo", 1f);
                Invoke("ChangeColorPlayer", 1.5f);

                Invoke("MoveOraculoToPlayer", 3f);
                Invoke("ChangeColorOraculo", 3.5f);
            }
        }
    }

    void MovePlayerToOraculo()
    {
        verificador.SetActive(true);
        var portaOraculo = portasOraculo.transform.GetChild(0).gameObject;
        verificador.transform.position = Vector3.MoveTowards(verificador.transform.position, portaOraculo.transform.position, 0.05f);
    }

    void MoveOraculoToPlayer()
    {
        verificador.SetActive(true);
        var portaOraculo = portasOraculo.transform.GetChild(0).gameObject;
        verificador.transform.position = Vector3.MoveTowards(verificador.transform.position, portasPlayer.transform.position, 0.05f);
    }


    void ChangeColorPlayer()
    {
        materialPlayer.color = Color.yellow;
    }
    void ChangeColorOraculo()
    {
        materialOraculo.color = Color.yellow;
    }

}
