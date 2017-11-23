using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour {

	public Text startX, startY, startZ;
	public Text endX, endY, endZ;
	public Dropdown colorList;
	public Text LineWidth;
	public Text Radius;


	LineRenderer lineRenderer;
	private Color color;
	private Material colorMaterial;

	public void DrawLine(){
		//get info from slider 
		Vector3 StartPoint = new Vector3(int.Parse(startX.text), int.Parse(startY.text), int.Parse(startZ.text));
		Vector3 EndPoint = new Vector3 (int.Parse(endX.text), int.Parse(endY.text), int.Parse(endZ.text));
		switchColor ();
		float lineWidth = float.Parse (LineWidth.text);

		Material m = new Material (Shader.Find("Standard"));
		m.color = color;

		GameObject line = new GameObject ("line");
		LineRenderer lineRenderer = line.AddComponent<LineRenderer> ();
		lineRenderer.material = m;
		lineRenderer.startWidth = lineWidth;
		lineRenderer.endWidth = lineWidth;
		Vector3[] points = new [] { StartPoint, EndPoint };
		lineRenderer.useWorldSpace = false;
		lineRenderer.SetPositions (points);
		lineRenderer.generateLightingData = true;

	}

	public void DrawCircle(){
		int radius = int.Parse (Radius.text);
		Vector3 position = new Vector3 (int.Parse(startX.text), int.Parse(startY.text), int.Parse(startZ.text));
		//remove degree letter and get only int from Text
		Vector3 orientation = new Vector3 (int.Parse(endX.text.Remove(endX.text.Length-1)), 
			int.Parse(endY.text.Remove(endY.text.Length-1)), 
			int.Parse(endZ.text.Remove(endZ.text.Length-1)));
		switchColor ();

		int size = 50; // circle will be more clear if size is larger
		float lineWidth = float.Parse (LineWidth.text);

		Material m = new Material (Shader.Find("Standard"));
		m.color = color;

		GameObject line = new GameObject ("Circle");
		LineRenderer lineRenderer = line.AddComponent<LineRenderer> ();
		lineRenderer.material = m;
		lineRenderer.startWidth = lineWidth;
		lineRenderer.endWidth = lineWidth;
		lineRenderer.positionCount = size+1; 

		float angle = 20f;
		float x, y;
		for(int i=0; i< size+1; i++){
			x = radius * Mathf.Cos (Mathf.Deg2Rad * angle);
			y = radius * Mathf.Sin (Mathf.Deg2Rad * angle);
			lineRenderer.SetPosition (i, new Vector3(x + position.x, y + position.y, 0 + position.z));
			angle += (360f / size);
		}

		lineRenderer.useWorldSpace = false;
		line.transform.Rotate(orientation);
		lineRenderer.generateLightingData = true;
	}

	public void DrawText(){
		GameObject textObject = new GameObject ("Text");
		TextMesh textmesh = textObject.AddComponent<TextMesh> ();

		textmesh.text = Radius.text;
		switchColor ();
		textmesh.color = color;
		Vector3 position = new Vector3 (int.Parse(startX.text), int.Parse(startY.text), int.Parse(startZ.text));
		Vector3 orientation = new Vector3 (int.Parse(endX.text.Remove(endX.text.Length-1)), 
			int.Parse(endY.text.Remove(endY.text.Length-1)), 
			int.Parse(endZ.text.Remove(endZ.text.Length-1)));
		
		textmesh.transform.position = position;
		textmesh.transform.Rotate(orientation);;
		lineRenderer.generateLightingData = true;
	}

	public void switchColor(){
		switch(colorList.value){
		case 0:
			color = Color.red;
			break;
		case 1:
			color = Color.blue;
			break;
		case 2:
			color = Color.black;
			break;
		case 3:
			color = Color.green;
			break;
		case 4:
			color = Color.yellow;
			break;
		case 5:
			color = Color.white;
			break;
		}
	}
}
