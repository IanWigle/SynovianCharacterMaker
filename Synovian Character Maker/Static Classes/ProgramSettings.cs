﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synovian_Character_Maker.Static_Classes
{
    public class ProgramSettings
    {
        public bool FocusOnZipsOverTxts { get; set; }
        public bool HideMainMenu { get; set; }
        public bool LoopSong { get; set; }

        ~ProgramSettings()
        {
            LoopSong = false;
            DataWriter.ExportSettings(this);
        }
    }
}
