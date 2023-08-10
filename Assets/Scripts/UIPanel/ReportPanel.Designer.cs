using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SHSFDX_QNJYRSETGY
{
	// Generate Id:ab8077fb-5ee1-49e3-8dd8-a3638b433181
	public partial class ReportPanel
	{
		public const string Name = "ReportPanel";
		
		[SerializeField]
		public RectTransform objMid;
		[SerializeField]
		public UnityEngine.UI.Image imgTotalTime;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpTotalTime;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpInner_IDRecommend;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpInner_ASDRecommend;
		[SerializeField]
		public UnityEngine.UI.Button btnSubmit;
		
		private ReportPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			objMid = null;
			imgTotalTime = null;
			tmpTotalTime = null;
			tmpInner_IDRecommend = null;
			tmpInner_ASDRecommend = null;
			btnSubmit = null;
			
			mData = null;
		}
		
		public ReportPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		ReportPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new ReportPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
