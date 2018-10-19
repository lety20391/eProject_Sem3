using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietPhap2018.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDgenerate { get; set; }

        [Required(ErrorMessage = "Nhập Họ tên anh em ơi")]
        [Display(Name = "Họ tên")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Thêm họ tên vào anh em ơi")]
        [RegularExpression("^[a-z,. A-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]*$", ErrorMessage = "Nhập chữ cái anh em ơi")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Nhập Báo cáo anh em ơi")]
        [Display(Name = "Báo cáo")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Thêm Báo cáo vào anh em ơi")]
        [RegularExpression("^[a-z0-9,./%: A-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ-]*$", ErrorMessage = "Nhập chữ cái, chữ số nhé anh em")]
        public string DetailReport { get; set; }

        [Required(ErrorMessage = "Nhập mã Giảng đường vào anh em")]
        [Display(Name = "Giảng đường")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Thêm giảng đường vào anh em")]
        [RegularExpression("^[a-z0-9,./%: A-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ-]*$", ErrorMessage = "Nhập chữ cái, chữ số nhé anh em")]
        public string Hall { get; set; }


        [Display(Name = "Tình trạng")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Chỗ trống, sắp, đang")]
        [RegularExpression("^[a-z0-9,./%: A-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ-]*$", ErrorMessage = "Nhập chữ cái, chữ số nhé anh em")]
        public string Status { get; set; }

        [Display(Name = "Thời gian dự kiến")]
        [DataType(DataType.DateTime)]
        public string TargetTime { get; set; }

        [Display(Name = "Thời gian bắt đầu")]
        [DataType(DataType.DateTime)]
        public string Start { get; set; }

        [Display(Name = "Thời gian kết thúc")]
        [DataType(DataType.DateTime)]
        public string End { get; set; }

        public bool Check { get; set; }

        public string Info2 { get; set; }

        public string Info3 { get; set; }

        public string Info4 { get; set; }
    }
}