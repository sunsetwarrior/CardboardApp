using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreehandPen : MonoBehaviour {

	Material material;
	Texture2D texture;

	public Camera cam;

	// Use this for initialization
	void Start () {
        //material = GetComponent<Renderer>().material;
        //texture = material.mainTexture as Texture2D;

        //cam = GetComponent<Camera> ();
        //draw ();

        //position from camera cast the ray 
        //Vector3 p = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cam.nearClipPlane));

        
        Texture2D texture = new Texture2D(128, 128);
        //GetComponent<Renderer>().material.mainTexture = texture;
        RenderSettings.skybox.mainTexture = texture;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                //Color color = ((x & y) != 0 ? Color.white : Color.gray);
                texture.SetPixel(x, y, Color.black);
            }
        }
        texture.Apply();
    }
	
	// Update is called once per frame
	void Update () {
		if (!Input.GetMouseButton (0))
			return;

		//GvrBasePointerRaycaster hit;
		RaycastHit hit;
		if (!Physics.Raycast (cam.ScreenPointToRay (Input.mousePosition), out hit))
			return;

		Renderer rend = hit.transform.GetComponent<Renderer> ();
		MeshCollider meshCollider = hit.collider as MeshCollider;

		if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
			return;

		Texture2D tex = rend.material.mainTexture as Texture2D;
		Vector2 pixelUV = hit.textureCoord;
		pixelUV.x *= tex.width;
		pixelUV.y *= tex.height;
		tex.SetPixel ((int)pixelUV.x, (int)pixelUV.y, Color.black);
		tex.Apply ();
	}

	void Paint(){
		Color[] colors = new Color[3];
		colors [0] = Color.red;
		colors [1] = Color.green;
		colors [2] = Color.blue;
		int mipCount = Mathf.Min (3, texture.mipmapCount);

		//tint each mip level, from Unity API
		for(int mip=0; mip < mipCount; ++mip){
			Color[] cols = texture.GetPixels (mip);
			for(int i=0; i<cols.Length; ++i){
				cols [i] = Color.Lerp (cols[i], colors[mip], 0.33f);
			}
			texture.SetPixels (cols, mip);
		}

		//apply to texture
		texture.Apply (false);
	}

	void draw(){
		Color[] colors = new Color[3];
		colors [0] = Color.red;
		colors [1] = Color.green;
		colors [2] = Color.blue;
		//int mipCount = Mathf.Min (3, texture.mipmapCount);
		texture.SetPixels (colors);
		texture.Apply (false);
	}

    void test() {
        
    }
}
