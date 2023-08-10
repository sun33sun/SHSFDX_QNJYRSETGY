using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SHSFDX_QNJYRSETGY
{
	// Generate Id:2fa8ac67-745c-4267-b2c9-9a222f7753f5
	public partial class CognitionPanel
	{
		public const string Name = "CognitionPanel";
		
		[SerializeField]
		public RectTransform objMid;
		[SerializeField]
		public UnityEngine.UI.Toggle tog_ID;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpInner_ID;
		[SerializeField]
		public UnityEngine.UI.Toggle tog_ASD;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpInner_ASD;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmp_ID;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmp_ASD;
		
		private CognitionPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			objMid = null;
			tog_ID = null;
			tmpInner_ID = null;
			tog_ASD = null;
			tmpInner_ASD = null;
			tmp_ID = null;
			tmp_ASD = null;
			
			mData = null;
		}
		
		public CognitionPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		CognitionPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new CognitionPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
