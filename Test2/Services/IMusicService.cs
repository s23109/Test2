﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.DTOs;

namespace Test2.Services
{
    interface IMusicService
    {

        AlbumDto GetAlbum(int idAlbum);

    }
}
