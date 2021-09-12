using Homework.SkillTree.Models;
using Homework.SkillTree.MVC.Models;
using ServiceLayer_SkillTree.Areas.WithServiceAndLogInUnitOfWork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework.SkillTree.MVC.Service
{
    public class AccountBooksService
    {
        private readonly Repository<AccountBook> _accountBookRepository;
        //private readonly Model1 _db;
        public AccountBooksService(IUnitOfWork unitOfWork)
        {
            _accountBookRepository = new Repository<AccountBook>(unitOfWork);
            //_db = new Model1();
        }
        public IEnumerable<CategoriesViewModel> Lookup()
        {
            var source = _accountBookRepository.LookupAll();
            var result = source.Select(account => new CategoriesViewModel() 
            { 
                Category = (CategoryEnum)account.Categoryyy,
                Money = account.Amounttt,
                Date = account.Dateee,
                Notes =account.Remarkkk      
            }).OrderByDescending(account => account.Date);
            return result;
        }
        public CategoriesViewModel GetSingle(Guid accountId)
        {
            var source = _accountBookRepository.GetSingle(d => d.Id == accountId);
            return new CategoriesViewModel
            { 
                Category = (CategoryEnum)source.Categoryyy,
                Money = source.Amounttt,
                Date = source.Dateee,
                Notes = source.Remarkkk
            };
        }
        public void Add(CategoriesViewModel categories)
        {
            _accountBookRepository.Create(new AccountBook 
            {
                Id = Guid.NewGuid(),
                Categoryyy = (int)categories.Category,
                Amounttt = categories.Money,
                Dateee =categories.Date,
                Remarkkk = categories.Notes

            });
        }
        public void Edit(Guid id, CategoriesViewModel pageData)
        {
            var oldData = _accountBookRepository.GetSingle(d=>d.Id == id);
            if (oldData != null)
            {
                oldData.Categoryyy = (int)pageData.Category;
                oldData.Amounttt = pageData.Money;
                oldData.Dateee = pageData.Date;
                oldData.Remarkkk = pageData.Notes;
            }
        }
        public void Delete(Guid id)
        {
            _accountBookRepository.Remove(_accountBookRepository.GetSingle(d => d.Id == id));
        }
        #region <沒有UnitOfWork>
        //public IEnumerable<AccountBook> Lookup()
        //{
        //    return _db.AccountBook.ToList();
        //}
        //public AccountBook GetSingle(Guid AccountBookId)
        //{
        //    return _db.AccountBook.Find(AccountBookId);
        //}
        //public void Add(AccountBook accountBook)
        //{
        //    _db.AccountBook.Add(accountBook);
        //}
        //public void Edit(AccountBook newData,AccountBook oldData)
        //{
        //    oldData.Amounttt = newData.Amounttt;
        //    oldData.Categoryyy = newData.Categoryyy;
        //    oldData.Dateee = newData.Dateee;
        //}
        //public void Delete(AccountBook data)
        //{
        //    _db.AccountBook.Remove(data);
        //}
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}
        #endregion
    }
}