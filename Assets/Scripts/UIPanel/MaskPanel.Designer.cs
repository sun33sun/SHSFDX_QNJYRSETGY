using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SHSFDX_QNJYRSETGY
{
	// Generate Id:ffa01e4f-d43f-4632-b000-74048100f906
	public partial class MaskPanel
	{
		public const string Name = "MaskPanel";
		
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpHead_ID;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpContent_ID;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpHead_ASD;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpContent_ASD;
		
		private MaskPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			tmpHead_ID = null;
			tmpContent_ID = null;
			tmpHead_ASD = null;
			tmpContent_ASD = null;
			
			mData = null;
		}
		
		public MaskPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		MaskPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new MaskPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
