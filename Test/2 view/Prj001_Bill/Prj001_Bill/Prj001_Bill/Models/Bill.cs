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
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDgenerate { get; set; }

        [Required(ErrorMessage = "Nhập Họ tên anh em ơi")]
        [Display(Name = "Họ tên")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Thêm họ tên vào anh em ơi")]
        [RegularExpression("^[a-z A-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]*$", ErrorMessage = "Nhập chữ cái anh em ơi")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nhập số điện thoại anh em ơi")]
        [Display(Name = "Điện thoại")]
        [RegularExpression("^[0-9]{9,11}$", ErrorMessage ="Nhập số liền nhau nha anh em")]
        public string UserPhone { get; set; }

        [Required(ErrorMessage = "Nhập Địa chỉ anh em ơi")]
        [Display(Name = "Địa chỉ")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Thêm địa chỉ vào anh em ơi")]
        [RegularExpression("^[a-z0-9.,/: A-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]*$", ErrorMessage = "Nhập chữ cái, chữ số nhé anh em")]
        public string DetailAddress { get; set; }

        [Required(ErrorMessage = "Nhập mã sản phẩm và số lượng cần mua")]
        [Display(Name = "Sản phẩm")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Anh em cần mua gì thêm mã và số lượng vào nhé")]
        [RegularExpression("^[a-z0-9.,/: A-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]*$", ErrorMessage = "Nhập chữ cái, chữ số nhé anh em")]
        public string Product { get; set; }

        
        [Display(Name = "Ghi chú")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Anh em ghi chú ngắn gọn nhé")]
        [RegularExpression("^[a-z0-9.,/: A-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]*$", ErrorMessage = "Nhập chữ cái, chữ số nhé anh em")]
        public string Note { get; set; }

        public string Info1 { get; set; }

        public string Info2 { get; set; }

        public string Info3 { get; set; }

        public string Info4 { get; set; }
    }


}