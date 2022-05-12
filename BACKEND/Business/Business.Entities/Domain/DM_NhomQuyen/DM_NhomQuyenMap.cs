﻿using System;

namespace Business.Entities.Domain
{
    public class DM_NhomQuyenMap:PagesModel
    {
        public long Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public int ThuTuHienThi { get; set; }
        public bool CongKhai { get; set; }
    }
    public class DM_NhomQuyenParam : PagesParamModel
    {
        public string TuKhoa { get; set; }
    }
    public class DM_NhomQuyenAdd
    {
        public long Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public int ThuTuHienThi { get; set; }
        public bool CongKhai { get; set; }
        public Guid CreatedUserID { get; set; }
    }
}
