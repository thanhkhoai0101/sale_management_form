using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BEL;
namespace BAL
{
    public class BAL_OrderDetail
    {
        public DataTable showListOrderDetail()
        {
            DAL_OrderDetail _OrderDetail = new DAL_OrderDetail();
            return _OrderDetail.showListOrderDetail();
        }
        public bool addOrderDetail(OrderDetail orderDetail)
        {
            DAL_OrderDetail _OrderDetail = new DAL_OrderDetail();
            return _OrderDetail.addOrderDetail(orderDetail);
        }
        public bool deleteOrderDetail(int id)
        {
            DAL_OrderDetail _OrderDetail = new DAL_OrderDetail();
            return _OrderDetail.deleteOrderDetail(id);
        }
        public bool updateOrderDetail(OrderDetail orderDetail)
        {
            DAL_OrderDetail _OrderDetail = new DAL_OrderDetail();
            return _OrderDetail.updateOrderDetail(orderDetail);
        }
        public DataTable searchListOrderDetail(int id)
        {
            DAL_OrderDetail _OrderDetail = new DAL_OrderDetail();
            return _OrderDetail.searchOrderDetail(id);
        }
        public DataTable bieuDoSanPhamBanDuoc()
        {
            DAL_OrderDetail _OrderDetail = new DAL_OrderDetail();
            return _OrderDetail.bieuDoSanPhamBanDuoc();
        }
        public DataTable searchOrderId(string orderId)
        {
            DAL_OrderDetail _OrderDetail = new DAL_OrderDetail();
            return _OrderDetail.searchOrderId(orderId);
        }
    }
}
