using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    void LateUpdate()
    {
        if (Player == null) return;

        if (Player.position.y > transform.position.y)
        {
            transform.position = new Vector3(
                transform.position.x,
                Player.position.y,
                transform.position.z
            );
        }
    }
}