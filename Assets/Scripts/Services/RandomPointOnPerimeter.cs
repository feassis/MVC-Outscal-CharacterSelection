using UnityEngine;

public class RandomPointOnPerimeter 
{
    // Método para obter um ponto aleatório no perímetro de um círculo
    public static Vector3 GetRandomPointOnPerimeter(Vector3 center, float radius)
    {
        // Gera um ângulo aleatório entre 0 e 360 graus
        float randomAngle = Random.Range(0f, 360f);

        // Converte o ângulo para radianos para usar com funções trigonométricas
        float angleInRadians = randomAngle * Mathf.Deg2Rad;

        // Calcula a posição do ponto no círculo usando seno e cosseno
        float x = center.x + Mathf.Cos(angleInRadians) * radius;
        float z = center.z + Mathf.Sin(angleInRadians) * radius;

        // Retorna o ponto calculado. Se você estiver no plano 2D, use center.y como valor de y.
        return new Vector3(x, center.y, z);
    }

    /// <summary>
    /// Generates a random point on the circumference behind the given transform, considering a radius and an angular tolerance.
    /// </summary>
    /// <param name="center">The central point (transform.position) around which the point will be generated.</param>
    /// <param name="forward">The forward vector of the transform (facing direction).</param>
    /// <param name="radius">The radius of the circumference.</param>
    /// <param name="thetaTolerance">Angular tolerance in degrees to limit the point generated behind the transform.</param>
    /// <returns>A random point behind the transform at the specified radius and within the angular tolerance.</returns>
    public static Vector3 GetRandomPointBehind(Vector3 center, Vector3 forward, float radius, float thetaTolerance)
    {
        // Calculate the "behind" direction of the transform based on its forward direction
        Vector3 backward = -forward.normalized;

        // Generate a random angle within the specified angular tolerance, relative to the "behind" direction
        float randomAngle = Random.Range(180f - thetaTolerance, 180f + thetaTolerance);

        // Convert the angle to radians to use with trigonometric functions
        float angleInRadians = randomAngle * Mathf.Deg2Rad;

        // Calculate the point on the circumference, using the "behind" vector as the base and applying the generated angle
        float x = Mathf.Cos(angleInRadians) * radius;
        float z = Mathf.Sin(angleInRadians) * radius;

        // Create a point in the local plane behind the transform
        Vector3 localPoint = new Vector3(x, 0, z);

        // Convert the local point to global coordinates by applying the transform's rotation
        Vector3 globalPoint = center + Quaternion.LookRotation(backward) * localPoint;

        return globalPoint;
    }
}