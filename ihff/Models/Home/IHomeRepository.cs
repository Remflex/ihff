﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    interface IHomeRepository
    {
        List<HomeModel> GetSuggested();
    }
}