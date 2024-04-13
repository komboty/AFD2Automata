using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

/// <summary>
/// Script que controla las transiciones de un estado.
/// </summary>
public class TransitionsManager : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;
    // Cadena a mover por las transiciones.
    public SplineAnimate stringMove;
    // Es estado final?.
    public bool isStateFinal = false;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        // Si la cadena entro al estado.
        if (other.CompareTag(constants.tagString))
        {
            string nameSymbol = other.transform.GetChild(1).GetChild(0).name;
            Debug.Log("Simbolo de cadena: " + nameSymbol);
            //Transform symbols = other.transform.GetChild(1);


            // Se asigna la transicion segun el simbolo.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform transition = transform.GetChild(i);

                // Si el primer simbolo de la cadena es igual al de la transicion.
                if (nameSymbol.Equals(transition.name))
                {
                    // Se dirije al nuevo estado por su transicion respectiva.
                    Debug.Log("Ir a transicion " + transition.name);
                    stringMove.Container = transition.GetChild(0).GetComponent<SplineContainer>();
                    stringMove.Restart(true);
                    return;
                
                }
            }

            // Si el estado es final y el simbolo que queda es epsilon.
            if (isStateFinal && nameSymbol.Equals(constants.SymbolEpsilonName)) {
                Debug.Log("Ganaste");
            }
            // Si el estado NO es final o el simbolo que queda NO es epsilon.
            else
            {
                Debug.Log("Perdiste");
            }
        }
    }
}
