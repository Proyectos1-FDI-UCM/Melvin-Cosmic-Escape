using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoDeVision : MonoBehaviour
{
    Renderer renderer;
    private Mesh mesh;
    private Vector3 origen;
    private float anguloInicial;
    private float anguloVision;
    public bool melvinEncontrado;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        mesh = new Mesh();
        // Asignamos nuestra malla (mesh) a la del componente
        GetComponent<MeshFilter>().mesh = mesh;
        // Variable para las dimensiones del campo de visión
        anguloVision = 90f; // Ángulo total de visión
    }

    void LateUpdate()
    {
        melvinEncontrado = false;
        if (renderer.isVisible) // Solo se renderiza el campo si está en cámara
        {
            // Debug.Log("Un campo de visión está en cámara");

            int rayosVision = 20; // Cuántos rayos de visión se castean
            float anguloActual = anguloInicial; // Irá aumentando en cada interacción
            float incrementoAngulo = anguloVision / rayosVision; // Cuánto aumenta el ángulo por cada rayo de visión
            float longitudVision = 3f;

            // Creamos una serie de variables que definen a mesh
            Vector3[] vertices = new Vector3[rayosVision + 2]; // Hay que contar el vértice origen y el primero
            Vector2[] uv = new Vector2[rayosVision + 2];
            int[] triangulos = new int[rayosVision * 3];

            vertices[0] = origen;

            int indiceVertices = 1; // No queremos modificar vertices[0]
            int indiceTriangulos = 0;
            for (int i = 0; i <= rayosVision; i++)
            {
                // Voy colocando cada vértice en el lugar que le corresponde
                Vector3 vertice;
                RaycastHit2D raycast = Physics2D.Raycast(origen, TransformaAnguloAVector(anguloActual), longitudVision);

                // Según lo que choca (o no) con los rayos
                if (raycast.collider == null || raycast.collider.GetComponent<Bala>())
                {
                    vertice = origen + TransformaAnguloAVector(anguloActual) * longitudVision;
                }
                else
                {
                    //Debug.Log("Punto: " + raycast.point + " " + raycast.collider.name);
                    vertice = raycast.point;

                    if (raycast.collider.GetComponentInParent<MelvinController>() && !raycast.collider.GetComponent<EnemigoCientifico>())
                    {
                        melvinEncontrado = true;
                        //Debug.Log("Melvin encontrado!");
                    }
                }

                vertices[indiceVertices] = vertice;

                if (i > 0) // Evita hacer esta asignación en el origen
                {
                    triangulos[indiceTriangulos + 0] = 0; // un vértice del triángulo siempre va a estar en el origen (vertices[0]) 
                    triangulos[indiceTriangulos + 1] = indiceVertices - 1;
                    triangulos[indiceTriangulos + 2] = indiceVertices;

                    indiceTriangulos += 3;
                }

                indiceVertices++;
                anguloActual -= incrementoAngulo; // resta ya que va en sentido antihorario
            }

            // Se asigna lo asociado a la malla
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangulos;
        }

    }   

    static Vector3 TransformaAnguloAVector(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    static float TransformaVectorAAngulo(Vector3 vector)
    {
        vector = vector.normalized;
        float angulo = Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg;
        if (angulo < 0)
        {
            angulo += 360;
        }
        return angulo;
    }

    // Pone el origen del campo de visión en el punto indicado
    public void Origen(Vector3 nuevoOrigen)
    {
        origen = nuevoOrigen;
    }

    // Instancia el campo de visión en la dirección indicada
    public void Direccion(Vector3 direccion)
    {
        anguloInicial = TransformaVectorAAngulo(direccion) - (anguloVision / 2f); 
    }
}
