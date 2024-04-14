using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

/// <summary>
/// Script que maneja el nivel.
/// </summary>
public class NivelTestManager : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;
    // Cadena a mover por las transiciones.
    public SplineAnimate stringMove;
    // Contenedor de simbolos (cadena).
    public Transform stringSymbols;
    // Transicion inicial.
    public SplineContainer transitionInitial;
    // Cadena hecha por el usuario.
    public Transform uiString;
    // Prefabs del simbolo E.
    public GameObject symbolE;
    // Prefabs de cada simbolo del alfabeto del automata.
    public List<GameObject> symbolsAlphabet;

    public void StartAutomata()
    {
        // Si ya se inicio el automata. No hacer nada.
        if (!uiString.parent.gameObject.activeSelf)
        {
            return;
        }            

        // Auxiliar para la creacion de un simbolo.
        GameObject symbolPrefa = null;
        GameObject newSymbol;

        for (int i = 0; i < uiString.childCount; i++) 
        { 
            Transform uiSymbol = uiString.GetChild(i);
            // Se busca el modelo 3d del symbolo.
            foreach (GameObject symbol in symbolsAlphabet)
            {
                if (symbol.name.Equals(uiSymbol.name))
                {
                    symbolPrefa = symbol;
                }
            }
            // Se crea el symbolo.
            newSymbol = Instantiate(symbolPrefa);
            newSymbol.name = uiSymbol.name;
            newSymbol.transform.SetParent(stringSymbols);
            newSymbol.transform.position = new Vector3(stringSymbols.position.x,
                stringSymbols.position.y, stringSymbols.position.z - (i * 1.2f));
        }

        // Se crea el symbolo E.
        newSymbol = Instantiate(symbolE);
        newSymbol.name = constants.SymbolEpsilonName;
        newSymbol.transform.SetParent(stringSymbols);
        newSymbol.transform.position = new Vector3(stringSymbols.position.x,
            stringSymbols.position.y, 
            stringSymbols.position.z - (uiString.childCount * 1.2f));

        // Se inicia el automata.
        stringMove.Container = transitionInitial;
        stringMove.Restart(true);
        CameraController.instance.followTransform = stringMove.transform;
        //uiString.parent.gameObject.SetActive(false);
        // Se ocultan elementos de la interfaz de usaurio.
        for (int i = 1; i < uiString.parent.childCount; i++)
        {
            uiString.parent.GetChild(i).gameObject.SetActive(false);
        }
        // Se elimina el drag de los symbolos de la interfaz de usuario.
        for (int i = 0; i < uiString.childCount; i++)
        {
            Destroy(uiString.GetChild(i).GetComponent<UISymbolDrag>());
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(constants.SceneNameNivelTest);
    }
}
