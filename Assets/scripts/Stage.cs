using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	private float[] leftEndPoses = new float[16];
	private float[] rightEndPoses = new float[16];

	private float leftEndPos;
	private float rightEndPos;

	// Use this for initialization
	void Start () {
/*		string[] tmpStr = this.name.Split('_');
		//Debug.Log(this.name.ToString() + " : " + tmpStr[1]);
		string tmpStr2 = tmpStr[1].Substring(0, 1);
		int tmpNum = int.Parse(tmpStr2);

		leftEndPoses[0] = 0.0f;	rightEndPoses[0] = 0.0f;
		leftEndPoses[1] = 0.0f;	rightEndPoses[1] = 2.0f;
		leftEndPoses[2] = 2.0f;	rightEndPoses[2] = 1.0f;
		leftEndPoses[3] = 1.0f;	rightEndPoses[3] = 0.0f;
		leftEndPoses[4] = 0.0f;	rightEndPoses[4] = -2.0f;
		leftEndPoses[5] = -2.0f;	rightEndPoses[5] = 2.0f;
		leftEndPoses[6] = 2.0f;	rightEndPoses[6] = 1.0f;
		leftEndPoses[7] = 1.0f;	rightEndPoses[7] = 1.0f;
		leftEndPoses[8] = 1.0f;	rightEndPoses[8] = 0.0f;
		leftEndPoses[9] = 0.0f;	rightEndPoses[9] = 1.0f;
		leftEndPoses[10] = 1.0f;	rightEndPoses[10] = 0.0f;
		leftEndPoses[11] = 0.0f;	rightEndPoses[11] = 1.0f;
		leftEndPoses[12] = 1.0f;	rightEndPoses[12] = 0.0f;
		leftEndPoses[13] = 0.0f;	rightEndPoses[13] = 0.0f;
		leftEndPoses[14] = 0.0f;	rightEndPoses[14] = -3.0f;
		leftEndPoses[15] = -3.0f;	rightEndPoses[15] = 0.0f;

		leftEndPos = leftEndPoses[tmpNum-1];
		rightEndPos = rightEndPoses[tmpNum-1];

		Debug.Log(this.name +  leftEndPos.ToString() + " : " + rightEndPos.ToString());
*/	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
