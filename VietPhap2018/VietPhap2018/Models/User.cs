using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietPhap2018.Models
{
    public class User
    {
        [Required(ErrorMessage = "Nhập Tên anh em ơi")]
        [Display(Name = "Tên")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Thêm Tên vào anh em ơi")]
        [RegularExpression("^[a-z0-9,. A-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]*$", ErrorMessage = "Nhập chữ cái anh em ơi")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Nhập Pass anh em ơi")]
        [Display(Name = "Pass")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Thêm Pass vào anh em ơi")]
        [RegularExpression("^[a-z0-9,./ A-Z]*$", ErrorMessage = "Nhập chữ cái anh em ơi")]
        [DataType(DataType.Password)]
        public string UserPass { get; set; }
    }
}