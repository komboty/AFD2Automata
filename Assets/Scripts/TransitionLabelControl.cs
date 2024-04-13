using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que controla la etiqueta de la transicion de un estado.
/// </summary>
public class TransitionLabelControl : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;

    private void OnTriggerEnter(Collider other)
    {        
        //Debug.Log(other.name);
        // Si la cadena entro al control.
        if (other.CompareTag(constants.tagString))
        {            
            // Se quita el primer simbolo de la cadena.
            Transform symbols = other.transform.GetChild(1);
            Destroy(symbols.GetChild(0).gameObject);
        }
    }
}
