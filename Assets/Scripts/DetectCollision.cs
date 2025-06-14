
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public Birb birb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        birb.UpdateScore();
    }
}
