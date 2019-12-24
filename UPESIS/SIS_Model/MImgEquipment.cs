using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    /// <summary>
    /// 实体类IMAG_EQUIPMENT，影像设备表
    /// </summary>
    public class MImgEquipment : ILL.IModel
    {
      private int? ImgEquipmentId;      //影像设备标识
      private string ImgEquipmentName;  //影像设备名称
      private int?  ClinicOfficeId;     //所属临床科室代码
      private string Office;            //所属诊室名称
      private string SerialClass;       //流水号类型
      private string EquipmentState;    //设备状态 在用、空闲、等待
      private string OperateDoctor;     //操作医生
      private string Ip;                //设备主机IP地址
      private DateTime? LastCall;       //最后叫号时间
      private string GUID;              //GUID

      /// <summary>
      /// 影像设备标识
      /// </summary>
      public int? IMG_EQUIPMENT_ID
      {
          get { return ImgEquipmentId; }
          set { this.ImgEquipmentId = value; }
      }

        /// <summary>
        /// 影像设备名称
        /// </summary>
      public string IMG_EQUIPMENT_NAME
      {
          get { return ImgEquipmentName; }
          set { this.ImgEquipmentName = value; }
      }

        /// <summary>
        /// 临床科室代码
        /// </summary>
      public int? CLINIC_OFFICE_ID
      {
          get { return ClinicOfficeId; }
          set { this.ClinicOfficeId = value; }
      }

        /// <summary>
        /// 所属诊室名称
        /// </summary>
      public string OFFICE
      {
          get { return Office; }
          set { this.Office = value; }
      }

        /// <summary>
        /// 流水号类型
        /// </summary>
      public string SERIAL_CLASS
      {
          get { return SerialClass; }
          set { this.SerialClass = value; }
      }

        /// <summary>
        /// 设备状态
        /// </summary>
      public string EQUIPMENT_STATE
      {
          get { return EquipmentState; }
          set { this.EquipmentState = value; }
      }

        /// <summary>
        /// 操作医生
        /// </summary>
      public string OPERATOR_DOCTOR
      {
          get { return OperateDoctor; }
          set { this.OperateDoctor = value; }
      }

        /// <summary>
        /// 主机IP地址
        /// </summary>
      public string IP
      {
          get { return Ip; }
          set { this.Ip = value; }
      }

        /// <summary>
        /// 最后呼叫时间
        /// </summary>
      public DateTime? LAST_CALL
      {
          get { return LastCall; }
          set { this.LastCall = value; }
      }

        /// <summary>
        /// 设备GUID
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
        /// 影像设备的构造方法
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
