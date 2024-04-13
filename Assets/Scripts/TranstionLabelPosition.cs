using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

/// <summary>
/// Script que cambia la posicion de la etiqueta una transicion de un estado.
/// </summary>
public class TranstionLabelPosition : MonoBehaviour
{
    // Transicion.
    public SplineContainer splineContainer;
    // Etiqueta de la transicion.
    public Transform label;

    void Start()
    {
        // Se posiciona el verificador de simbolo en medio de la transicion.
        IEnumerable<BezierKnot> knots = splineContainer.Spline.Knots;
        BezierKnot middleKnot = knots.ElementAt(knots.Count() / 2);
        Vector3 middlePosition = new Vector3(middleKnot.Position.x, middleKnot.Position.y, middleKnot.Position.z) 
            + transform.parent.position;
        //Debug.Log(middleKnot.Position);
        //model.position = model.InverseTransformVector(middleKnot.Position);
        //model.position = model.InverseTransformPoint(middleKnot.Position);
        //model.position -= new Vector3(middleKnot.Position.x * -1, 0f, middleKnot.Position.z);
        label.SetPositionAndRotation(middlePosition, middleKnot.Rotation);
    }
}
