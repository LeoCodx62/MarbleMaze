using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public Canvas UICanvas;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillObstacle"))
        {

            Destroy(gameObject, 0.2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.CompareTag("Win"))
        {

            Destroy(gameObject, 0.2f);

            if (UICanvas != null)
            {
                UICanvas.gameObject.SetActive(true);
            }
        }
    }
}
