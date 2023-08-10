using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SHSFDX_QNJYRSETGY
{
	// Generate Id:dc11e0f8-4901-4858-82be-69d469646fa9
	public partial class MaskPanel
	{
		public const string Name = "MaskPanel";
		
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpContent_ID;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpContent_ASD;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpHead_ID;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpHead_ASD;
		
		private MaskPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			tmpContent_ID = null;
			tmpContent_ASD = null;
			tmpHead_ID = null;
			tmpHead_ASD = null;
			
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
