using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shopmohinh.Models
{
    public class fig
    {
      
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Title { get; set; }
        [Display(Name = "Ngày đặt hàng")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Ngày đặt hàng")]
        public string Genre { get; set; }
        [Display(Name = "Giá Tiền")]
        public decimal Price { get; set; }
        [Display(Name = "Xếp hạng")]
        public string Rating { get; set; }


    }
}
