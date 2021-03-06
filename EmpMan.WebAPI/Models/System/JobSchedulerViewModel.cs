using EmpMan.Web.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmpMan.Web.Models
{
    public class JobSchedulerViewModel : AuditableViewModel
    {
        /// <summary>
        /// Khóa chính tự  sinh
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// Loại job
        /// </summary>
        public string JobType { set; get; }

        /// <summary>
        /// Tên job
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Tên tắt
        /// </summary>
        [MaxLength(256)]
        public string ShortName { set; get; }

        /// <summary>
        /// Tên table liên quan
        /// </summary>
        public string TableNameRelation { set; get; }

        /// <summary>
        /// Tên cột liên kết
        /// </summary>
        public string TableKey { set; get; }

        /// <summary>
        /// ID tự sinh của cột liên kết với table định nghĩa tại TableNamRelation
        /// </summary>
        public string TableKeyID { set; get; }

        /// <summary>
        /// Thời gian dự định job
        /// </summary>
        public DateTime? ScheduleRunJobDate { set; get; }

        /// <summary>
        /// Nội dung job
        /// </summary>
        public string JobContent { set; get; }
        /// <summary>
        /// Gửi từ địa chỉ mail nào
        /// </summary>
        public string FromEmail { set; get; }
        /// <summary>
        /// Tập hợp các email to ( Ngăn cách dấu ;)
        /// </summary>
        public string ToNotiEmailList { set; get; }
        /// <summary>
        /// CC
        /// </summary>
        public string CcNotiEmailList { set; get; }

        /// <summary>
        /// BCC
        /// </summary>
        public string BccNotiEmailList { set; get; }
        /// <summary>
        /// Số phone gửi đi ( tổng  đài)
        /// </summary>
        public string SMSFromNumber { set; get; }
        /// <summary>
        /// Số điện thoại gửi tới
        /// </summary>
        public string SMSToNumber { set; get; }
        /// <summary>
        /// Nội dung message
        /// </summary>
        public string SMSContent { set; get; }

        /// <summary>
        /// Trạng thái của job ( 0: chưa thực thi ; 1 : đang thực thi ; 2 : thực thi thất bại ; 9 : đã thực thi thành công )
        /// </summary>
        public int? JobStatus { set; get; }

        /// <summary>
        /// Thời gian thực thi job
        /// </summary>
        public DateTime? ActualRunJobDate { set; get; }

        /// <summary>
        /// Template của SMS / Mail
        /// </summary>
        public int? TemplateID { set; get; }

        /// <summary>
        /// File đính kèm
        /// </summary>
        public int? AttachmementID { set; get; }
    }
}