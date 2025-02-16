﻿using System.Threading;
using System.Threading.Tasks;
using LoyaltyPrime.DataAccessLayer.Infrastructure.Repositories;
using LoyaltyPrime.DataAccessLayer.Repositories;
using LoyaltyPrime.DataLayer;
using LoyaltyPrime.Models;

namespace LoyaltyPrime.DataAccessLayer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoyaltyPrimeContext _context;
        private IRepository<Company> _companyRepository;
        private IRepository<Member> _memberRepository;
        private IRepository<Account> _accountRepository;
        private IRepository<CompanyRedeem> _companyRedeemRepository;
        private IRepository<CompanyReward> _companyRewardRepository;
        private IRepository<AccountRedeemHistory> _accountRedeemHistoryRepository;
        private IRepository<AccountRewardHistory> _accountRewardHistoryRepository;
        private ISearchRepository _searchRepository;

        public UnitOfWork(LoyaltyPrimeContext context)
        {
            _context = context;
        }

        public IRepository<Company> CompanyRepository
        {
            get { return _companyRepository ??= new Repository<Company>(_context); }
        }

        public IRepository<Member> MemberRepository
        {
            get { return _memberRepository ??= new Repository<Member>(_context); }
        }

        public IRepository<Account> AccountRepository
        {
            get { return _accountRepository ??= new Repository<Account>(_context); }
        }

        public IRepository<CompanyRedeem> CompanyRedeemRepository
        {
            get { return _companyRedeemRepository ??= new Repository<CompanyRedeem>(_context); }
        }

        public IRepository<CompanyReward> CompanyRewardRepository
        {
            get { return _companyRewardRepository ??= new Repository<CompanyReward>(_context); }
        }

        public IRepository<AccountRedeemHistory> AccountRedeemHistoryRepository
        {
            get { return _accountRedeemHistoryRepository ??= new Repository<AccountRedeemHistory>(_context); }
        }

        public IRepository<AccountRewardHistory> AccountRewardHistoryRepository
        {
            get { return _accountRewardHistoryRepository ??= new Repository<AccountRewardHistory>(_context); }
        }

        public ISearchRepository SearchRepository
        {
            get { return _searchRepository ??= new SearchRepository(_context); }
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}