using UnityEngine;

public class MazeController : MonoBehaviour
{

    [Header("Rotation Settings")]
    public float torqueStrength = 10f;
    public float maxTiltAngle = 15f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY; // blocca il movimento e rotazione su asse Y
    }

    void FixedUpdate()
    {

        float inputX = Input.GetAxis("Vertical");   // avanti/indietro
        float inputZ = -Input.GetAxis("Horizontal"); // destra/sinistra

        // Calcolo torque da applicare sui due assi
        Vector3 torque = new Vector3(inputX, 0, inputZ) * torqueStrength;

        rb.AddTorque(torque);

        // Limita l'inclinazione della piattaforma
        ClampTilt();
    }

    void ClampTilt()
    {
        Vector3 currentRotation = transform.localEulerAngles;

        // Portiamo l’angolo da [0,360] a [-180,180]
        float x = (currentRotation.x > 180) ? currentRotation.x - 360 : currentRotation.x;
        float z = (currentRotation.z > 180) ? currentRotation.z - 360 : currentRotation.z;

        x = Mathf.Clamp(x, -maxTiltAngle, maxTiltAngle);
        z = Mathf.Clamp(z, -maxTiltAngle, maxTiltAngle);

        transform.localRotation = Quaternion.Euler(x, 0, z);
        rb.angularVelocity = Vector3.zero; // evitiamo accumulo continuo
    }
}
