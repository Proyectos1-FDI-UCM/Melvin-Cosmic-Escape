using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoDeVision : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();
        // Asignamos nuestra malla (mesh) a la del componente
        GetComponent<MeshFilter>().mesh = mesh;

        // Variables para las dimensiones del campo de visión
        float anguloVision = 35f; //Ángulo total de visión
        int rayosVision = 50; // Cuántos rayos de visión se castean
        float anguloActual = 0f; // Irá aumentando en cada interacción
        float anguloIncremento = anguloVision / rayosVision; // Cuánto aumenta el ángulo por cada rayo de visión
        float longitudVision = 5f;
        Vector3 origen = GetComponent<Transform>().position; // El origen está en la posición del enemigo al que va asociado este script

        // Creamos una serie de variables que definen a mesh
        Vector3[] vertices = new Vector3[rayosVision + 2]; // Hay que contar el vértice origen y el primero
        Vector2[] uv = new Vector2[rayosVision + 2];
        int[] triangulos = new int[rayosVision * 3];

        /* vertices[0] = Vector2.zero;
        vertices[1] = new Vector2(50,0);
        vertices[2] = new Vector2(0, -50); */

        vertices[0] = origen;

        int indiceVertices = 1; // no queremos modificar vertices[0]
        int indiceTriangulos = 0;
        for (int i = 0; i <= rayosVision; i++)
        {
            // Para evitar hacer una distinción casos, voy colocando cada vértice en el lugar que viene dado por la siguiente fórmula:
            Vector3 vertice = origen + TransformaAnguloAVector(anguloActual) * longitudVision;
            vertices[indiceVertices] = vertice;

            if (i > 0) // Evita hacer esta asignación en el origen
            {
                triangulos[indiceTriangulos] = 0; // un vértice del triángulo siempre va a estar en el origen (vertices[0]) 
                triangulos[indiceTriangulos + 1] = indiceVertices - 1;
                triangulos[indiceTriangulos + 2] = indiceVertices;
                indiceTriangulos += 3;
            }


            indiceVertices++;
            anguloActual -= anguloIncremento; // resta ya que va en sentido antihorario

        }

        /*// El entero de triangulos, corresponde con una posición del array vertices 
        triangulos[0] = 0;
        triangulos[0] = 1;
        triangulos[0] = 2; */

        // Asignamos las variables creadas a mesh
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangulos;

    }

    void Update()
    {
        
    }

    // Este método transforma un valor en grados a su equivalente Vector3
    static Vector3 TransformaAnguloAVector(float angulo)
    {
        float anguloRad = angulo * (Mathf.PI / 180f);
        return (new Vector3(Mathf.Cos(anguloRad), Mathf.Sin(anguloRad)));
    }
}
