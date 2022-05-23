
using shopmohinh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopmohinh.Models
{
    public class dulieu
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new shopmohinhContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<shopmohinhContext>>()))
            {
                // Kiểm tra thông tin cuốn sách đã tồn tại hay chưa
                if (context.fig.Any())
                {
                    return; // Không thêm nếu cuốn sách đã tồn tại trong DB
                }
                context.fig.AddRange(
                new fig
                {
                    Title = "Mô hình hãng HOTTOYS",
                    ReleaseDate = DateTime.Parse("2022-02-28"),
                    Genre = "Mô hình tỉ lệ 1/6",
                    Price = 245.99M,
                    Rating = "cao cấp"  
                },
                new fig
                {
                    Title = "Mô hình tĩnh Tam Quốc hãng Inflames Toys",
                    ReleaseDate = DateTime.Parse("2022-02-28"),
                    Genre = "Mô hình tỉ lệ 1/6",
                    Price = 149.99M,
                    Rating = "cao cấp"

                },
                new fig
                {
                    Title = "Mô hình hãng ZDTOYS",
                    ReleaseDate = DateTime.Parse("2022-02-25"),
                    Genre = "Bản không led",
                    Price = 24.99M,
                    Rating = "Trung bình"
                    
                },
                new fig
                {
                    Title = "Mô hình hãng ZDTOYS",
                    ReleaseDate = DateTime.Parse("2022-02-25"),
                    Genre = "Bản có led",
                    Price = 39.99M,
                    Rating = "Trung bình"

                }
                ) ;
                context.SaveChanges();//lưu dữ liệu Update-Database

            }
        }
    }
}

