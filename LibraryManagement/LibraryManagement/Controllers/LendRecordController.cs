using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Entities;
using LibraryManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendRecordController : ControllerBase
    {

        private readonly ILendRecordRepository _lendRecordRepository;
        public LendRecordController(ILendRecordRepository lendRecordRepository)
        {
            _lendRecordRepository = lendRecordRepository;
        }

        // GET: api/lendrecord
        [HttpGet(Name = "GetLendRecords")]
        public List<LendRecord> Get()
        {
            List<LendRecord> lendRecords = _lendRecordRepository.GetLendRecords();
            return lendRecords;
        }

        // GET: api/lendrecord/{id}
        [HttpGet("{id}", Name = "GetLendRecord")]
        public LendRecord Get(int id)
        {
            return _lendRecordRepository.Get(id);
        }

        // POST: api/lendrecord
        [HttpPost(Name = "AddLendRecord")]
        public void Post([FromBody] LendRecord lendRecord)
        {
            _lendRecordRepository.Add(lendRecord);
        }

        [HttpPut("{id}", Name = "EditLendRecord")]
        public int Edit([FromBody] LendRecord lendRecord)
        {
            return _lendRecordRepository.Edit(lendRecord);
        }

        // DELETE: api/lendrecord/{id}
        [HttpDelete("{id}", Name = "DeleteLendRecord")]
        public int Delete(int id)
        {
            return _lendRecordRepository.Delete(id);
        }
    }
}