using UnityEngine;

[ExecuteInEditMode]
public class Lens : MonoBehaviour
{
    public Shader shader;

    public float ratio = 1;  	// The ratio of the height to the length of the screen to display properly shader
    public float radius = 0; 	// The radius of the black hole measured in the same units as the other objects in the scene

    GameObject[] BHs;
    private Material _material; // Material which is located shader
    protected Material material
    {
        get
        {
            if (_material == null)
            {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }

    protected virtual void OnDisable()
    {
        if (_material)
        {
            DestroyImmediate(_material);
        }
    }

    void Start()
    {
        BHs = GameObject.FindGameObjectsWithTag("BlackHole");
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (shader && material)
        {
            material.SetFloat("_Ratio", ratio);
            material.SetFloat("_Rad", radius);
            material.SetInt("_BHCount", BHs.Length);

            for(int f1=0;f1<BHs.Length;f1++)
            {
                Vector2 pos = new Vector2(
                    this.GetComponent<Camera>().WorldToScreenPoint(BHs[f1].transform.position).x / this.GetComponent<Camera>().pixelWidth,
                    1 - this.GetComponent<Camera>().WorldToScreenPoint(BHs[f1].transform.position).y / this.GetComponent<Camera>().pixelHeight);

                material.SetVector("_Positions"+f1.ToString(), new Vector2(pos.x, pos.y));
            }

            Graphics.Blit(source, destination, material);
        }
    }
}