using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Common.Enum
{
    public enum IsEndangered
    {
        Extinct,          // Đã tuyệt chủng (Không còn cá thể nào tồn tại)
        Endangered,       // Nguy cấp (Có nguy cơ biến mất)
        Vulnerable,       // Dễ tổn thương (Dễ suy giảm nếu không được bảo vệ)
        Safe,             // An toàn (Đang phát triển tốt)
        Unknown           // Không rõ (Chưa có đủ thông tin)
    }
}
