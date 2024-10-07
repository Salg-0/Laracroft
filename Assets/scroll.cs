// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;

// public class scroll : MonoBehaviour
// {
//     public MeshRenderer MRI;
//     public Material[] Materials;
//     private int slice = 25;
//     private float acumulator = 0;
//     private int multiplier = 1;
//     // Start is called before the first frame update
//     private IEnumerator UpdateSlice()
//     {
//         yield return new WaitForSeconds(0.5f);
//         acumulator += Input.GetAxis("Mouse X");
//         Debug.Log("ienumerator " + Input.GetAxis("Mouse X") + "\n" + Input.GetAxis("Mouse Y") + "\n" + slice);
//         slice += (int) (acumulator * multiplier);
//         MRI.material = Materials[slice % Materials.Length];
//     }
//     void Start()
//     {
//         StartCoroutine(UpdateSlice());
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         acumulator += Input.GetAxis("Mouse X");
//         Debug.Log(Input.GetAxis("Mouse X") + "\n" + Input.GetAxis("Mouse Y") + "\n" + slice);
//         slice += (int) (acumulator * multiplier);
//         MRI.material = Materials[slice % Materials.Length];
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    private float rotation = 0.0f;
    public GameObject slider;
    public MeshRenderer MRI;
    public Material[] Materials;
    private int slice = 25;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotation = Input.GetAxis("Mouse Y");
        //Debug.Log("rotation: " + rotation + " slice: " + slice + " inverse tranform" + this.transform.InverseTransformPoint(slider.transform.position) + " tranform" + slider.transform.position);//-5 a 5
        //Debug.Log("slice: " + (int)(((this.transform.InverseTransformPoint(slider.transform.position).x + 5f) / 10f) * Materials.Length));
        //Debug.Log((this.transform.InverseTransformPoint(slider.transform.position).x + 5f));
        //Debug.Log(((this.transform.InverseTransformPoint(slider.transform.position).x + 5f) / 10f));
        //Debug.Log((((this.transform.InverseTransformPoint(slider.transform.position).x + 5f) / 10f) * Materials.Length));
        //Debug.Log((int)(((this.transform.InverseTransformPoint(slider.transform.position).x + 5f) / 10f) * Materials.Length));
        if(rotation > 0.5f)
        {
            MRI.material = Materials[slice++];
            adjustSlider();
        }
        else if(rotation < -0.5f)
        {
            MRI.material = Materials[slice--];
            adjustSlider();
        }
        if(slice > 49)
        {
            slice = 0;
        }
        else if(slice < 0)
        {
            slice = 49;
        }
        MRI.material = Materials[(int)(((this.transform.InverseTransformPoint(slider.transform.position).x + 5f) / 10f) * Materials.Length)];

    }

    void adjustSlider(){
        Vector3 sliderPosition = slider.transform.position;
        Vector3 sliderLocalPos = this.transform.InverseTransformPoint(slider.transform.position);
        slider.transform.localPosition = new Vector3((((slice / (float)Materials.Length) * 10f) - 5f), sliderLocalPos.y, sliderLocalPos.z);

    }

}