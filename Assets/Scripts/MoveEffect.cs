using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MoveEffect : MonoBehaviour
{
    private bool upDown = false;
    private bool sideToSide = false;
    void FixedUpdate()
    {
        if(this.transform.localPosition.y >= Random.Range(50, 100))
            upDown = false;
        
        if(this.transform.localPosition.y <= Random.Range(-50, -100))
            upDown=true;

        if (this.transform.localPosition.x >= Random.Range(50, 100))
            sideToSide = false;

        if (this.transform.localPosition.x <= Random.Range(-50, -100))
            sideToSide = true;


        if (!upDown)
            this.transform.Translate(Vector2.down);
        else if (upDown)
        {
            this.transform.Translate(Vector2.up);
        }

        if (!sideToSide)
            this.transform.Translate(Vector2.left);
        else if (sideToSide)
        {
            this.transform.Translate(Vector2.right);
        }

    }
}
