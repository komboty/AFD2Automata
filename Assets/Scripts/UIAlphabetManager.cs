using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Script que controla el alfabeto en la interfaz de usuario.
/// </summary>
public class UIAlphabetManager : MonoBehaviour, IPointerClickHandler
{
    // Contenedor donde se forma la cadena.
    public GameObject UIstring;
    // Prefab de un symbolo de la interfaz de usuario.
    public GameObject prefabUISymbol;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject newSymbol = Instantiate(prefabUISymbol);
        newSymbol.transform.name = transform.name;
        newSymbol.GetComponent<Image>().color = transform.GetComponent<Image>().color;
        //symbol.AddComponent<UISymbolDrag>();        
        //Destroy(symbol.GetComponent<UIAlphabetManager>());
        UnityEditor.GameObjectUtility.SetParentAndAlign(newSymbol, UIstring);
    }
}
