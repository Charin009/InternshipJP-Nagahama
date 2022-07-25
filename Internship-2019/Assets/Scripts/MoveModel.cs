using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*MoveModel use with Move menu to made the slider can move model on xyz coordinate.
 */
public class MoveModel : MonoBehaviour
{
    // Assign in the inspector
    public GameObject objectToMove;
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    // Preserve the original and current orientation
    private float previousValueX;
    private float previousValueY;
    private float previousValueZ;

    void Awake()
    {

        // And current value
        this.previousValueX = this.sliderX.value;
        this.previousValueY = this.sliderY.value;
        this.previousValueZ = this.sliderZ.value;
    }

    public void OnSliderChangedX(float value)
    {
        // How much we've changed
        float delta = (value - this.previousValueX);
        this.objectToMove.transform.position += Vector3.right * delta;

        // Set our previous value for the next change
        this.previousValueX = value;
    }

    public void OnSliderChangedY(float value)
    {
        // How much we've changed
        float delta = (value - this.previousValueY);
        this.objectToMove.transform.position += Vector3.up * delta ;

        // Set our previous value for the next change
        this.previousValueY = value;
    }

    public void OnSliderChangedZ(float value)
    {
        // How much we've changed
        float delta = (value - this.previousValueZ);
        this.objectToMove.transform.position += Vector3.forward * delta;

        // Set our previous value for the next change
        this.previousValueZ = value;
    }

    public void Reset()
    {
        this.sliderX.value = 0;
        this.sliderY.value = 0;
        this.sliderZ.value = 0;
    }
}
