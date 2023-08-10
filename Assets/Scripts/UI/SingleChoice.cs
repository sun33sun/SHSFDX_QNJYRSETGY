using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public struct SingleData
{
	public string strHead;
	public List<string> list;
	public string strAnalysis;
	public int score;
}
public class SingleChoice : MonoBehaviour
{
	public TextMeshProUGUI tmpHead;
	public List<TextMeshProUGUI> tmpOptions;
	public TextMeshProUGUI tmpAnalysis;
	public SingleData mData = default(SingleData);

	public void LoadData()
	{
	}
}
