using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Rotation use with raotate menu to made the slider can rotate model on xyz coordinate.
 */
public class Rotation : MonoBehaviour
{
    // Assign in the inspector
    public GameObject objectToRotate;
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
        this.objectToRotate.transform.Rotate(Vector3.right * delta * 180);

        // Set our previous value for the next change
        this.previousValueX = value;
    }

    public void OnSliderChangedY(float value)
    {
        // How much we've changed
        float delta = (value - this.previousValueY);
        this.objectToRotate.transform.Rotate(Vector3.up * delta * 180);

        // Set our previous value for the next change
        this.previousValueY = value;
    }

    public void OnSliderChangedZ(float value)
    {
        // How much we've changed
        float delta = (value - this.previousValueZ);
        this.objectToRotate.transform.Rotate(Vector3.forward * delta * 180);

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
