using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SHSFDX_QNJYRSETGY
{
	// Generate Id:427d34c8-cb3e-430f-8c81-8af6195e1728
	public partial class MainPanel
	{
		public const string Name = "MainPanel";
		
		[SerializeField]
		public RectTransform objMid;
		[SerializeField]
		public RectTransform objPreview;
		[SerializeField]
		public UnityEngine.UI.Button btnConfirm;
		[SerializeField]
		public RectTransform ButtonGroup;
		[SerializeField]
		public UnityEngine.UI.Button btnCognition;
		[SerializeField]
		public UnityEngine.UI.Button btnTrain;
		[SerializeField]
		public UnityEngine.UI.Button btnAnswer;
		[SerializeField]
		public UnityEngine.UI.Button btnReport;
		
		private MainPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			objMid = null;
			objPreview = null;
			btnConfirm = null;
			ButtonGroup = null;
			btnCognition = null;
			btnTrain = null;
			btnAnswer = null;
			btnReport = null;
			
			mData = null;
		}
		
		public MainPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		MainPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new MainPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
