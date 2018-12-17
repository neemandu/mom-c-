﻿using a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Models;

namespace a1.Repositories
{
    public interface IIvhunimRepository
    {
        Task Delete(int id);
        Task Duplicate(int id);
        Task Post(Ivhunim ivhun);
        Task Upsert(Ivhunim ivhun);
        IvhunimAndActions GetAll(bool isUserAdmin);
    }
}