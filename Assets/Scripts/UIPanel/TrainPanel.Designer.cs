using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SHSFDX_QNJYRSETGY
{
	// Generate Id:8d7aa651-af8b-4891-a9c8-4b3a6f7dc13f
	public partial class TrainPanel
	{
		public const string Name = "TrainPanel";
		
		[SerializeField]
		public RectTransform objMid;
		[SerializeField]
		public UnityEngine.UI.Button btnLearn;
		[SerializeField]
		public UnityEngine.UI.Button btnTest;
		[SerializeField]
		public UnityEngine.UI.Button btn_ID;
		[SerializeField]
		public UnityEngine.UI.Button btn_ASD;
		[SerializeField]
		public UnityEngine.UI.Image imgTip;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpTip;
		[SerializeField]
		public UnityEngine.UI.Button btnConfirmTip;
		[SerializeField]
		public UnityEngine.UI.Image imgSelectionTitle;
		[SerializeField]
		public RectTransform Content;
		[SerializeField]
		public UnityEngine.UI.Button btnConfirmTitle;
		[SerializeField]
		public RectTransform RetractTip;
		[SerializeField]
		public UnityEngine.UI.Button btnRetractTip;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpOperationContent;
		[SerializeField]
		public UnityEngine.UI.Button ExpandTip;
		[SerializeField]
		public UnityEngine.UI.Image imgDialogue;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpCharacter;
		[SerializeField]
		public UnityEngine.UI.Image imgCharacter;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpDialogueContent;
		[SerializeField]
		public UnityEngine.UI.Button btnConfirmDialogue;
		[SerializeField]
		public UnityEngine.UI.Button ExpandStudent;
		[SerializeField]
		public RectTransform RetractStudent;
		[SerializeField]
		public UnityEngine.UI.Button btnRetractStudent;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpStudentType;
		[SerializeField]
		public UnityEngine.UI.Image imgShortAnswer;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpShortAnswerHead;
		[SerializeField]
		public UnityEngine.UI.InputField inputShortAnswer;
		[SerializeField]
		public UnityEngine.UI.Button btnConfirmShortAnswer;
		
		private TrainPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			objMid = null;
			btnLearn = null;
			btnTest = null;
			btn_ID = null;
			btn_ASD = null;
			imgTip = null;
			tmpTip = null;
			btnConfirmTip = null;
			imgSelectionTitle = null;
			Content = null;
			btnConfirmTitle = null;
			RetractTip = null;
			btnRetractTip = null;
			tmpOperationContent = null;
			ExpandTip = null;
			imgDialogue = null;
			tmpCharacter = null;
			imgCharacter = null;
			tmpDialogueContent = null;
			btnConfirmDialogue = null;
			ExpandStudent = null;
			RetractStudent = null;
			btnRetractStudent = null;
			tmpStudentType = null;
			imgShortAnswer = null;
			tmpShortAnswerHead = null;
			inputShortAnswer = null;
			btnConfirmShortAnswer = null;
			
			mData = null;
		}
		
		public TrainPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		TrainPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new TrainPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
