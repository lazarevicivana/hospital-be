﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Tender.Repository
{
    public interface ITenderRepository
    {
        public void Create(Model.Tender tender);
        public void Delete(Model.Tender tender);
        public Task<List<Model.Tender>> GetAll();
        public Model.Tender GetById(Guid id);
        public void Update(Model.Tender tender);

    }
}