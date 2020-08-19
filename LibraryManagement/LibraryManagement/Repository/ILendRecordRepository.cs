using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public interface ILendRecordRepository
    {
        int Add(LendRecord lendRecord);
        List<LendRecord> GetLendRecords();
        LendRecord Get(int id);
        int Edit(LendRecord lendRecord);
        int Delete(int id);

    }
}