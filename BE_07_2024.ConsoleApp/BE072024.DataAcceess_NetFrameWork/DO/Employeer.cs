using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DO
{
    public struct Employeer
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeerId { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeerName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Ngày vào làm
        /// </summary>
        public DateTime DateOfStart { get; set; }
    }
}
