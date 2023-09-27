using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThucHanh1.Models
{
    public class Student
    {
        public int Id { get; set; }//Mã sinh viên
        [Required(ErrorMessage = "Hãy nhập họ và tên")]
        [Display(Name = "Họ Và Tên")]
        [StringLength(100,MinimumLength = 4,ErrorMessage = "độ dài họ tên trong khoảng 4 -  100" )]
        public string? Name { get; set; } //Họ tên
        [Display(Name="Địa chỉ Email")]
        [Required(ErrorMessage = "Email bắt buộc phài được nhập")]
        [RegularExpression(@"^[a-z0-9](\.?[a-z0-9]){5,}@g(oogle)?mail\.com$" , ErrorMessage = "Email phải đúng định dạng")]
        public string? Email { get; set; } //Email
        [StringLength(100,MinimumLength =8,ErrorMessage = "Độ dài mật khẩu từ 8 - 100 kí tự")]
        [Required(ErrorMessage = "Mật khẩu phải nhập")]
        [Display(Name = "Mật khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&*!])[A-Za-z\d@#$%^&*!]{8,}$",ErrorMessage = "Mật khẩu có ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt")]
        public string? Password { get; set; }//Mật khẩu
        [Required(ErrorMessage = "Ngành học phải đc chọn")]
        [Display(Name = "Nghành học")]
        public Branch? Branch { get; set; }//Ngành học
        [Required(ErrorMessage = "Hãy Chọn Giới Tính")]
        [Display(Name = "Giới Tính ")]
        public Gender? Gender { get; set; }//Giới tính
        [Display(Name="Hệ Đào Tạo")]
        public bool IsRegular { get; set; }//Hệ: true-chính qui, false-phi cq
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Nhập vào địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }//Địa chỉ
        [Range(typeof(DateTime),"1/1/1963","12/31/2005",ErrorMessage = "Năm sinh trong khoảng 1963 - 2005")]
        [Required(ErrorMessage = "Hay nhập ngày sinh")]
        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBorth { get; set; }//Ngày sinh
        [Display(Name = "Điểm")]
        [Required(ErrorMessage = "Hãy nhập điểm")]
        [RegularExpression(@"^(10(\.0{1,2})?|[0-9](\.\d{1,2})?)$",ErrorMessage = "bắt buộc nhập kiểu số thực và miền giá trị từ 0.0 đến 10.0")]
        public float Diem { get; set; }
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public IFormFile? ImageURL { get; set; }
    }
}
