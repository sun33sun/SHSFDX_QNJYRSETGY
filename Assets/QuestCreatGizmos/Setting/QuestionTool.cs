using System;
using System.Collections;
using System.Collections.Generic;
using LTYFrameWork.UI;
using UnityEngine;
using UnityEngine.UI;

public class QuestionTool : MonoBehaviour
{
    public static Text _题目文字框_Static;

    public Transform _选项组_Static;

    public static GameObject _选项预制体_Static;

    public Text _解析文字框_Static;

    public List<Toggle> _所有选项 = new List<Toggle>();
    public List<UICornerText> _所有选项文字框 = new List<UICornerText>();

    public void OnEnable()
    {
        _题目文字框_Static = this.gameObject.transform.Find("题目").GetChild(0).GetComponent<UICornerText>();
        _选项组_Static = this.gameObject.transform.Find("选项组");
        _解析文字框_Static = this.gameObject.transform.Find("解析").GetChild(0).GetComponent<UICornerText>();
        _解析文字框_Static.text = "";
        _选项预制体_Static = Resources.Load<GameObject>("QuestionPrefabs/选项");
    }

    public void SetQuestion(string _题目,List<string> _选项,bool _是否为单选)
    {
        _题目文字框_Static.text = _题目.ToString()+"E";
        GameObject go;
        if (_是否为单选)
        {
            _选项组_Static.gameObject.AddComponent<ToggleGroup>().allowSwitchOff = true;
        }
        Color color = new Color(255f / 255, 200f / 255, 33f / 255, 1);
        for (int i = 0; i < _选项.Count; i++)
        {
            go = Instantiate(_选项预制体_Static, _选项组_Static);
            _所有选项文字框.Add(go.transform.Find("选项内容").GetComponent<UICornerText>());
            _所有选项文字框[i].text = _选项[i].ToString();
            _所有选项.Add(go.GetComponent<Toggle>());
            int nowIndex = i;
            _所有选项[i].onValueChanged.AddListener(isOn =>
            {
                if (isOn)
                {
                    _所有选项文字框[nowIndex].color = color;
                    _所有选项[nowIndex].graphic.color = color;
                    _所有选项[nowIndex].targetGraphic.color = color;
                }
                else
                {
                    _所有选项文字框[nowIndex].color = Color.white;
                    _所有选项[nowIndex].graphic.color = Color.white;
                    _所有选项[nowIndex].targetGraphic.color = Color.white;
                }
            });
            if (_是否为单选)
            {
                go.GetComponent<Toggle>().group = this._选项组_Static.gameObject.GetComponent<ToggleGroup>();
            }
            else
            {
                _选项预制体_Static.GetComponent<Toggle>().group = null;
            }
            go.GetComponent<Toggle>().isOn = false;
        }
    }

    public float SingleJudge(QuestionController.MyChoiceIndex _正确答案,string _解析内容,float _该题分值)
    {
        int I = 0;
        int correctIndex = _正确答案.GetHashCode();
        for (int i = 0; i < _所有选项.Count; i++)
        {
			if (_所有选项[i].isOn)
			{
                if(correctIndex == i)
				{
                    _所有选项文字框[i].color = Color.green;
                    _所有选项[i].graphic.color = Color.green;
                    _所有选项[i].targetGraphic.color = Color.green;
                    I = 1;
                }
				else
				{
                    _所有选项文字框[i].color = Color.red;
                    _所有选项[i].graphic.color = Color.red;
                    _所有选项[i].targetGraphic.color = Color.red;
                }
			}
            _所有选项[i].interactable = false;
        }
        
        if (I == 1)
        {
            _解析文字框_Static.text = "回答正确！"+_解析内容.ToString()+"E";
            _解析文字框_Static.color = Color.green;
            return _该题分值;
        }
        else
        {
            _解析文字框_Static.text = "回答错误！" + "正确答案为：" + _正确答案.ToString() +"、"+ _解析内容.ToString()+"E";
            _解析文字框_Static.color = Color.red;
            return 0;
        }
    }

    public float MultipleJudge(List<QuestionController.MyChoiceIndex> _正确答案组,string _解析内容,float _该题分值)
    {
        int I = 0;
        string X = "";
        for (int i = 0; i < _所有选项.Count; i++)
        {
			if (_所有选项[i].isOn)
			{
                _所有选项文字框[i].color = Color.red;
                _所有选项[i].graphic.color = Color.red;
                _所有选项[i].targetGraphic.color = Color.red;
            }
            _所有选项[i].interactable = false;
        }

        for (int i = 0; i < _正确答案组.Count; i++)
        {
            if (_所有选项[_正确答案组[i].GetHashCode()].isOn)
            {
                _所有选项文字框[i].color = Color.green;
                _所有选项[i].graphic.color = Color.green;
                _所有选项[i].targetGraphic.color = Color.green;
                I++;
            }

            X = X + _正确答案组[i].ToString() + "、";
        }

        if (I == _正确答案组.Count)
        {
            _解析文字框_Static.text = "回答正确！"+_解析内容.ToString()+"E";
            _解析文字框_Static.color = Color.green;
            return _该题分值;
        }
        else
        {
            _解析文字框_Static.text = "回答错误！" + "正确答案为：" + X + _解析内容.ToString()+"E";
            _解析文字框_Static.color = Color.red;
            return 0;
        }
    }
}