using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE072024.DataAcceess_NetFrameWork.DO
{
    public struct AnimalStruct
    {
        private int soChan { get; set; }
        public string Name { get; set; }
        public string sound { get; set; }
        public AnimalStruct(int _sochan, string _name, string _sound)
        {
            this.soChan = _sochan;
            this.Name = _name;
            this.sound = _sound;
        }
        public string Sound()
        {
            return sound;
        }

        public int Get_SoChan()
        {
            return soChan;
        }
    }

   public enum TRANG_THAI_GIAO_DICH
    {
        THATBAI = 1,
        THANH_CONG = 2
    }
}
