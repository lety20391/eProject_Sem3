using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Prj001_Bill.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDgenerate { get; set; }

        [Required(ErrorMessage = "Nhập Số thứ tự")]
        [Display(Name = "Số thứ tự")]
        public int IDProduct { get; set; }

        [Required(ErrorMessage = "Nhập Nội dung sản phẩm")]
        [Display(Name = "Sản phẩm")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Thêm họ tên vào anh em ơi")]
        [RegularExpression("^[a-z A-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]*$", ErrorMessage = "Nhập chữ cái anh em ơi")]
        public string productContent { get; set; }

        public string Info1 { get; set; }

        public string Info2 { get; set; }

        public string Info3 { get; set; }

        public string Info4 { get; set; }
    }
}