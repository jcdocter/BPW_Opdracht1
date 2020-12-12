using UnityEngine;

//made by Joey Docter
//minimap
public class MinimapScript : MonoBehaviour
{
    public Transform Player;
    void LateUpdate()
    {
        //follow player
        Vector3 newPosition = Player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, Player.eulerAngles.y, 0f);
    }
}
