using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM
{
    public static class Values
    {
        public const string URL_SEARCH = "search.png",
            URL_EDIT = "edit.png",
            URL_LOCATE = "locate.png",
            URL_REFRESH = "refresh.png",
            URL_ADD = "add.png",
            URL_DELETE = "delete.png";

        public const string ROLE_ADMIN = "Admin",
                       ROLE_MANAGER = "Quản lí",
                       ROLE_EMPLOYEE = "Nhân viên",
                       ROLE_CUSTOMER = "Khách",
                        OWNER_NONE = "Không";
        public const string STATE_ACTIVE = "Hoạt động",
                       STATE_BAN = "Khóa";
        public const string ORDER_STATE_SENT = "Đã gửi",
                        ORDER_STATE_DELIVERED = "Đang chuyển",
                        ORDER_STATE_RECEIVED = "Đã nhận";

        public const string EMP_STATE_FREE = "Rảnh",
                        EMP_STATE_BUSY = "Giao hàng";
        public const string PRODUCT_STATE_AVAILABLE = "Còn",
            PRODUCT_STATE_ORDERED = "Đã đặt hàng",
            PRODUCT_STATE_SOLD = "Đã bán",
            PRODUCT_STATE_BROKEN = "Hỏng";

    }
}
