using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*ScaleMenu use with scale menu to made the slider can increase or decrease the model.
 */
public class ScaleMenu : MonoBehaviour
{
    // Assign in the inspector
    public GameObject objectToScale;
    public Slider sliderX;

    // Preserve the original and current orientation
    private float previousValueX;

    void Awake()
    {

        // And current value
        this.previousValueX = this.sliderX.value;
    }

    public void OnSliderChangedX(float value)
    {
        // How much we've changed
        float delta = (value - this.previousValueX);
        this.objectToScale.transform.localScale += Vector3.one * delta;

        // Set our previous value for the next change
        this.previousValueX = value;
    }

    public void Reset()
    {
        this.sliderX.value = 1;
    }
}
