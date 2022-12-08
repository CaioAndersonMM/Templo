using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour
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

        // Para isso os Oráculos tiveram que receber um nome único

        //Debug.Log(portasOraculo.transform.GetChild(0).position);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saiu da colisão com " + other.name);
        verificador.SetActive(false); //desativar também o verificador
        texto.enabled = false;
        enter = false;
        portasPlayer.SetActive(false);
        portasOraculo.transform.GetChild(0).gameObject.SetActive(false);
        materialPlayer.color = Color.red;
        materialOraculo.color = Color.red;

        
    }
    private void Start()
    {
        materialPlayer.color = Color.red;
        materialOraculo.color = Color.red;

        //As cores dos materiais devem começar vermelhos!
    }
    void Update()
    {
        if (enter == true) {
            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter")){
                texto.enabled = false;
                portasOraculo.transform.GetChild(0).gameObject.SetActive(true); //Ativando o filho (Porta de Controle) do Oráculo
                portasPlayer.SetActive(true);
                StartCoroutine(WaitBeforeShow(verificador, portasOraculo.transform.GetChild(0).gameObject, portasPlayer, 0.07f));
                // mudar cor pra verde: myMaterial.color = Color.green;

            }
        }
    }

    IEnumerator WaitBeforeShow(GameObject verificador, GameObject portaOraculo, GameObject portaPlayer, float speedTranslation)
    {

        // HÁ UM ERRO DE QUANDO A CONEXÃO É INTERROMPIADA, POIS DEVE SER QUEBRADO ESSA FUNÇÃO E COMEÇAR ELA DO 0!!!


        verificador.transform.position = portasPlayer.transform.position; //Colocando o verificador na posição da Porta do Player
        verificador.SetActive(true);

        while (verificador.transform.position != portaOraculo.transform.position)
        {
            verificador.transform.position = Vector3.MoveTowards(verificador.transform.position, portaOraculo.transform.position, speedTranslation * Time.deltaTime);
            yield return null;
        }
  
        materialPlayer.color = Color.yellow;
        yield return new WaitForSeconds(1); //Precisou disso como barreira para nao entrar no while de cima (?)

        while (verificador.transform.position != portaPlayer.transform.position)
        {
            verificador.transform.position = Vector3.MoveTowards(verificador.transform.position, portaPlayer.transform.position, speedTranslation * Time.deltaTime);
            yield return null;
        }

        materialOraculo.color = Color.yellow;
        yield return new WaitForSeconds(1);

        while (verificador.transform.position != portaOraculo.transform.position)
        {
            verificador.transform.position = Vector3.MoveTowards(verificador.transform.position, portaOraculo.transform.position, speedTranslation * Time.deltaTime);
            yield return null;
        }

        materialPlayer.color = Color.green;
        yield return new WaitForSeconds(1);


        while (verificador.transform.position != portaPlayer.transform.position)
        {
            verificador.transform.position = Vector3.MoveTowards(verificador.transform.position, portaPlayer.transform.position, speedTranslation * Time.deltaTime);
            yield return null;
        }

        materialOraculo.color = Color.green;
        yield return new WaitForSeconds(1);
    }

}
