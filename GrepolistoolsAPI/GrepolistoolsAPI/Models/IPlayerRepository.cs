﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll(String server, int id);
        IEnumerable<Player> GetById(int id, String server, int world);
        Player GetByIdDate(int id, String server, int world, String date);
        IEnumerable<Player> GetTop(int top, String server, int world);

    }
}
