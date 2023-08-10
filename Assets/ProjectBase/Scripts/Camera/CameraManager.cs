using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using QFramework;
using ProjectBase;
using UnityEngine.EventSystems;

namespace ProjectBase
{
	public class CameraManager : SingletonMono<CameraManager>
	{
		List<IPersonView> personViews = new List<IPersonView>();
		PersonViewField pvField;
		public PersonViewType pvType = PersonViewType.FirstPerson;


		[SerializeField] Camera mainC;
		[SerializeField] CinemachineVirtualCamera noneC = null;
		[SerializeField] CinemachineVirtualCamera firstC = null;
		[SerializeField] CinemachineVirtualCamera followC = null;
		[SerializeField] CinemachineVirtualCamera thirdC = null;

		//��������ĸ���
		Rigidbody roamRig = null;

		Vector3 originPos;
		Vector3 originAngle;
		float originFieldOfView;
		Vector3 nowPos;
		[SerializeField] bool isEnable = false;
		public bool IsEnable
		{
			get{return isEnable;}
			set
			{
				if (value)
					roamRig.constraints = RigidbodyConstraints.FreezeRotation;
				else
					roamRig.constraints = RigidbodyConstraints.FreezeAll;
				isEnable = value;
			}
		}

		bool isRotate = false;

		private void Start()
		{
			//�������
			roamRig = firstC.GetComponent<Rigidbody>();
			//��¼��ʼλ��
			originPos = firstC.transform.position;
			originAngle = firstC.transform.rotation.eulerAngles;
			originFieldOfView = firstC.m_Lens.FieldOfView;

			#region �ƶ�����ת
			//�ƶ�
			InputMgr.GetInstance().ChangerInput(true);
			//�����ƶ�
			EventCenter.GetInstance().AddEventListener(KeyCode.LeftControl + "����", OnEState);
			EventCenter.GetInstance().AddEventListener<float>("������", OnMouseScrollWheel);
			//��ת
			EventCenter.GetInstance().AddEventListener("����Ҽ�����", OnMouseRightDown);
			EventCenter.GetInstance().AddEventListener("����Ҽ�̧��", OnMouseRightUp);
			EventCenter.GetInstance().AddEventListener<Vector2>("��껬��", OnMouseSliding);
			EventCenter.GetInstance().AddEventListener(KeyCode.Space + "����", OnQState);
			EventCenter.GetInstance().AddEventListener<Vector2>("�ƶ�����", UpdateVelocity);
			#endregion

			#region ��ʼ������
			personViews.Add(new NonePersonView());
			personViews.Add(new FirstPersonView(firstC.transform));
			personViews.Add(new ThirdPersonView(thirdC.transform));
			pvField.moveSpeed = 3;
			pvField.upSpeed = 2;
			pvField.rotateSpeed = 3;
			pvField.viewSpeed = 10;
			#endregion
		}

		#region �ƶ��������ƶ�����ת��������Ұ
		void UpdateVelocity(Vector2 dir)
		{
			personViews[(int)pvType].UpdateVelocity(dir);
		}
		private void OnEState()
		{
			if (!IsEnable)
				return;
			personViews[(int)pvType].OnEState();
		}
		private void OnQState()
		{
			if (!IsEnable)
				return;
			personViews[(int)pvType].OnQState();
		}
		private void OnMouseRightDown()
		{
			if (!IsEnable)
				return;
			isRotate = true;
		}
		private void OnMouseRightUp()
		{
			if (!IsEnable)
				return;
			isRotate = false;
		}
		private void OnMouseSliding(Vector2 slidingValue)
		{
			if (!isRotate || !IsEnable)
				return;
			personViews[(int)pvType].OnMouseSliding(slidingValue);
		}
		private void OnMouseScrollWheel(float distance)
		{
			if (!IsEnable)
				return;
			personViews[(int)pvType].OnMouseScrollWheel(distance);
		}
		#endregion

		
		private void OnDestroy()
		{
			//�����ƶ�
			EventCenter.GetInstance().RemoveEventListener(KeyCode.LeftControl + "����", OnEState);
			EventCenter.GetInstance().RemoveEventListener<float>("������", OnMouseScrollWheel);
			//��ת
			EventCenter.GetInstance().RemoveEventListener("����Ҽ�����", OnMouseRightDown);
			EventCenter.GetInstance().RemoveEventListener("����Ҽ�̧��", OnMouseRightUp);
			EventCenter.GetInstance().RemoveEventListener<Vector2>("��껬��", OnMouseSliding);
			EventCenter.GetInstance().RemoveEventListener(KeyCode.Space + "����", OnQState);
			EventCenter.GetInstance().RemoveEventListener<Vector2>("�ƶ�����", UpdateVelocity);
		}
	}

}
