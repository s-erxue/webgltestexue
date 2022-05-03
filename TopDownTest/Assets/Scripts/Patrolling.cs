using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private int duration;

    private int fixedFrames = 0;
    private bool backwards = false;

    private void FixedUpdate()
    {
        if (backwards)
        {
            transform.Translate(-direction / duration);
            fixedFrames--;
        }
        else
        {
            transform.Translate(direction / duration);
            fixedFrames++;
        }
        if (fixedFrames == duration)
        {
            backwards = true;
        }
        else if (fixedFrames == 0)
        {
            backwards = false;
        }
    }
}
