using UnityEngine;

public class FailDetector : MonoBehaviour
{
    public float failOffset = 5.5f;
    bool failed = false;

    void Update()
    {
        if (failed) return;

        float cameraBottom = Camera.main.transform.position.y - failOffset;

        if (transform.position.y < cameraBottom)
        {
            failed = true;
            GameManager.Instance.GameOver();
        }
    }
}
