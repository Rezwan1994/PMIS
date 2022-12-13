﻿using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.Security.Security
{
    public interface IMenuMasterManager
    {
        string LoadData(string db, int companyId);
        Task<string> AddOrUpdate(string db, MENU_CONFIGURATION model);
        Task<string> ActivateMenu(string db, int id);
        Task<string> DeactivateMenu(string db, int id);
        Task<string> DeleteMenu(string db,int id);
    }
}