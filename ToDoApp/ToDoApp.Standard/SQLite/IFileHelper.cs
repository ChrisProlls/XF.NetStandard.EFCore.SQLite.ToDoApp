﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Standard.SQLite
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
