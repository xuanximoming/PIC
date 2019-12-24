using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// ʵ����IMAG_EQUIPMENT��Ӱ���豸��
    /// </summary>
    public class MImgEquipment : ILL.IModel
    {
      private int? ImgEquipmentId;      //Ӱ���豸��ʶ
      private string ImgEquipmentName;  //Ӱ���豸����
      private int?  ClinicOfficeId;     //�����ٴ����Ҵ���
      private string Office;            //������������
      private string SerialClass;       //��ˮ������
      private string EquipmentState;    //�豸״̬ ���á����С��ȴ�
      private string OperateDoctor;     //����ҽ��
      private string Ip;                //�豸����IP��ַ
      private DateTime? LastCall;       //���к�ʱ��
      private string GUID;              //GUID

      /// <summary>
      /// Ӱ���豸��ʶ
      /// </summary>
      public int? IMG_EQUIPMENT_ID
      {
          get { return ImgEquipmentId; }
          set { this.ImgEquipmentId = value; }
      }

        /// <summary>
        /// Ӱ���豸����
        /// </summary>
      public string IMG_EQUIPMENT_NAME
      {
          get { return ImgEquipmentName; }
          set { this.ImgEquipmentName = value; }
      }

        /// <summary>
        /// �ٴ����Ҵ���
        /// </summary>
      public int? CLINIC_OFFICE_ID
      {
          get { return ClinicOfficeId; }
          set { this.ClinicOfficeId = value; }
      }

        /// <summary>
        /// ������������
        /// </summary>
      public string OFFICE
      {
          get { return Office; }
          set { this.Office = value; }
      }

        /// <summary>
        /// ��ˮ������
        /// </summary>
      public string SERIAL_CLASS
      {
          get { return SerialClass; }
          set { this.SerialClass = value; }
      }

        /// <summary>
        /// �豸״̬
        /// </summary>
      public string EQUIPMENT_STATE
      {
          get { return EquipmentState; }
          set { this.EquipmentState = value; }
      }

        /// <summary>
        /// ����ҽ��
        /// </summary>
      public string OPERATOR_DOCTOR
      {
          get { return OperateDoctor; }
          set { this.OperateDoctor = value; }
      }

        /// <summary>
        /// ����IP��ַ
        /// </summary>
      public string IP
      {
          get { return Ip; }
          set { this.Ip = value; }
      }

        /// <summary>
        /// ������ʱ��
        /// </summary>
      public DateTime? LAST_CALL
      {
          get { return LastCall; }
          set { this.LastCall = value; }
      }

        /// <summary>
        /// �豸GUID
        /// </summary>
      public string EQU_GUID
      {
          get { return GUID; }
          set { this.GUID = value; }
      }

      public MImgEquipment()
      {
      }

        /// <summary>
        /// Ӱ���豸�Ĺ��췽��
        /// </summary>
        /// <param name="MImgEquipmentId"></param>
        /// <param name="MImgEquipmentName"></param>
        /// <param name="MImgOfficeId"></param>
        /// <param name="MOffice"></param>
        /// <param name="MSerialClass"></param>
        /// <param name="MEquipmentState"></param>
        /// <param name="MOperateDoctor"></param>
        /// <param name="MIp"></param>
        /// <param name="MLastCall"></param>
        /// <param name="MGUID"></param>
      public MImgEquipment(int MImgEquipmentId,string MImgEquipmentName,int  MImgOfficeId,string MOffice,string MSerialClass,string MEquipmentState,string MOperateDoctor,string MIp,DateTime MLastCall,string MGUID)
      {
          this.ImgEquipmentId = MImgEquipmentId;
          this.ImgEquipmentName = MImgEquipmentName;
          this.ClinicOfficeId = MImgOfficeId;
          this.Office = MOffice;
          this.SerialClass = this.SERIAL_CLASS;
          this.EquipmentState = MEquipmentState;
          this.OperateDoctor = MOperateDoctor;
          this.Ip = MIp;
          this.LastCall = MLastCall;
          this.GUID = MGUID;
      }

    }
}
