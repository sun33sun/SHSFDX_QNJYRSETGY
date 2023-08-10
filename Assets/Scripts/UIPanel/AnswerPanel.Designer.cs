using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SHSFDX_QNJYRSETGY
{
	// Generate Id:7c7afb7e-49aa-46a6-a807-88f91be0befb
	public partial class AnswerPanel
	{
		public const string Name = "AnswerPanel";
		
		[SerializeField]
		public RectTransform objMid;
		[SerializeField]
		public UnityEngine.UI.Button btnSubmit;
		[SerializeField]
		public UnityEngine.UI.Image imgDoubleConfirm;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpTip;
		[SerializeField]
		public UnityEngine.UI.Button btnDoubleConfirm;
		[SerializeField]
		public UnityEngine.UI.Button btnDoubleCancel;
		
		private AnswerPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			objMid = null;
			btnSubmit = null;
			imgDoubleConfirm = null;
			tmpTip = null;
			btnDoubleConfirm = null;
			btnDoubleCancel = null;
			
			mData = null;
		}
		
		public AnswerPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		AnswerPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new AnswerPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
