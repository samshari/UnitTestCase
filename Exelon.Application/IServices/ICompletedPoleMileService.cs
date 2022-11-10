﻿using Exelon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exelon.Application.IServices
{
    public interface ICompletedPoleMileService
    {
        Task<CompletedPoleAndMile> GetCompletedPoleMileById(int id);
        Task<Dictionary<CompletedPoleAndMile, string>> SaveUpdateCompletedPoleMile(CompletedPoleAndMile model);
        Task<CompletedPoleAndMile> UpdateCompletedPoleMile(CompletedPoleAndMile model);
        Task<CompletedPoleAndMile> GetCompletedPoleMileByLinkId(int id);
    }
}
