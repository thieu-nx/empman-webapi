﻿using System.Collections.Generic;
using EmpMan.Data.Infrastructure;
using EmpMan.Data.Repositories;
using EmpMan.Model.Models;
using System.Linq;

namespace EmpMan.Service
{
    /// <summary>
    /// Giao diện thực hiện các tác vụ liên quan đến DB
    /// </summary>
    public interface IEmpProfileService
    {
        /// <summary>
        /// Thêm item vào table đối tượng
        /// </summary>
        /// <param name="empProfile">Thông tin table đối tượng</param>
        /// <returns>Đối tượng đã được add vào</returns>
        EmpProfile Add(EmpProfile empProfile);

        /// <summary>
        /// Cập nhật record đối tượng
        /// </summary>
        /// <param name="empProfile">Record đối tượng</param>
        void Update(EmpProfile empProfile);

        /// <summary>
        /// Xóa vật lý record đối tượng
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns></returns>
        EmpProfile Delete(int id);

        /// <summary>
        /// Xóa logic record (thiết lập flag delete thành true)
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns></returns>
        EmpProfile DeleteLogic(int id);

        /// <summary>
        /// Lấy toàn bộ record của table
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmpProfile> GetAll();

        /// <summary>
        /// Lấy các record của table dựa vào keyword
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <returns></returns>
        IEnumerable<EmpProfile> GetAll(string keyword);

        /// <summary>
        /// Lấy danh sách có phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <param name="page">Trang</param>
        /// <param name="pageSize">Số Record của 1 page</param>
        /// <param name="totalRow">Tổng số record get được</param>
        /// <returns></returns>
        IEnumerable<EmpProfile> GetAllPaging(string keyword, int page, int pageSize, out int totalRow);

        /// <summary>
        /// Tìm kiếm danh sách record đối tượng thỏa mãn điều kiện keyword
        /// </summary>
        /// <param name="keyword">từ khóa tìm kiếm</param>
        /// <param name="page">trang đối tượng</param>
        /// <param name="pageSize">số record trên 1 page</param>
        /// <param name="sort">trình tự sort</param>
        /// <param name="totalRow">số dòng đối tượng get được</param>
        /// <returns></returns>
        IEnumerable<EmpProfile> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        /// <summary>
        /// Lấy record đối tượng dựa vào Id
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns></returns>
        EmpProfile GetById(int id);

        /// <summary>
        /// Lưu các thay đổi vào DB
        /// </summary>
        void SaveChanges();
    }

    public class EmpProfileService : IEmpProfileService
    {
        private IEmpProfileRepository _empProfileRepository;
        private IUnitOfWork _unitOfWork;

        public EmpProfileService(IEmpProfileRepository empProfileRepository, IUnitOfWork unitOfWork)
        {
            this._empProfileRepository = empProfileRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Thêm item vào table đối tượng
        /// </summary>
        /// <param name="empProfile">Thông tin table đối tượng</param>
        /// <returns></returns>
        public EmpProfile Add(EmpProfile empProfile)
        {
            return _empProfileRepository.Add(empProfile);
        }

        /// <summary>
        /// Cập nhật record đối tượng
        /// </summary>
        /// <param name="empProfile">Record đối tượng</param>
        public void Update(EmpProfile empProfile)
        {
            _empProfileRepository.Update(empProfile);
        }

        /// <summary>
        /// Xóa vật lý record đối tượng
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns></returns>
        public EmpProfile Delete(int id)
        {
            return _empProfileRepository.Delete(id);
        }

        /// <summary>
        /// Xóa logic record (thiết lập flag delete thành true)
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns></returns>
        public EmpProfile DeleteLogic(int id)
        {
            var dataFromDb = _empProfileRepository.GetSingleById(id);
            dataFromDb.Status= true;
            _empProfileRepository.Update(dataFromDb);
            return dataFromDb;
        }

        /// <summary>
        /// Lấy các record của table dựa vào keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IEnumerable<EmpProfile> GetAll()
        {
            return _empProfileRepository.GetAll();
        }

        /// <summary>
        /// Lấy các record của table dựa vào keyword
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <returns></returns>
        public IEnumerable<EmpProfile> GetAll(string keyword)
        {
            var query = _empProfileRepository.GetAll();
            //if (!string.IsNullOrEmpty(keyword))
            //    query = query.Where(x => x.Name.Contains(keyword)|| x.ShortName.Contains(keyword));


            return query;
        }

        /// <summary>
        /// Lấy danh sách có phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <param name="page">Trang</param>
        /// <param name="pageSize">Số Record của 1 page</param>
        /// <param name="totalRow">Tổng số record get được</param>
        /// <returns></returns>
        public IEnumerable<EmpProfile> GetAllPaging(string keyword, int page, int pageSize, out int totalRow)
        {
            return _empProfileRepository.GetMultiPaging(x => (x.Status), out totalRow, page, pageSize);
        }

        /// <summary>
        /// Tìm kiếm danh sách record đối tượng thỏa mãn điều kiện keyword
        /// </summary>
        /// <param name="keyword">từ khóa tìm kiếm</param>
        /// <param name="page">trang đối tượng</param>
        /// <param name="pageSize">số record trên 1 page</param>
        /// <param name="sort">trình tự sort</param>
        /// <param name="totalRow">số dòng đối tượng get được</param>
        /// <returns></returns>
        public IEnumerable<EmpProfile> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _empProfileRepository.GetMulti(x => x.Status );

            switch (sort)
            {
                case "name":
                    //query = query.OrderByDescending(x => x.Name);
                    break;

                case "code":
                    //query = query.OrderByDescending(x => x.Code);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Lấy record đối tượng dựa vào Id
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns></returns>
        public EmpProfile GetById(int id)
        {
            return _empProfileRepository.GetSingleById(id);
        }

        /// <summary>
        /// Cập nhật vào DB
        /// </summary>
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

    }
}