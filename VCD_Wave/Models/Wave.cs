using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VCD_Wave.Models
{
    public class Wave
    {
        public mod_vcd_Main module { get; set; }
        public mod_vcd_TimeScale_Main time { get; set; }
    }
    public class mod_vcd_Main 
    {
        public long file_ID { get; set; } = 0;
        public string file_datetime { get; set; } = "";
        public string file_version { get; set; } = "";
        public string file_timescale { get; set; } = "";
        public string file_comments { get; set; } = "";
        public string file_Name { get; set; } = "";
        public string file_Size { get; set; } = "";
        public int file_moduleCount { get; set; } = 0;
        public int file_timeScaleCount { get; set; } = 0;
        public List<mod_vcd_Modules> lstmodule { get; set; } = new List<mod_vcd_Modules>();
    }

    public class mod_vcd_Modules
    {
        public long file_IDFK { get; set; } = 0;
        public long scopecounter { get; set; } = 0;
        public long scopeparentid { get; set; } = 0;
        public string scopeparent { get; set; } = "";
        public string scopename { get; set; } = "";
        public string scopetype { get; set; } = "";
        public string scopevariables { get; set; } = "";
        public List<mod_Variables> lstvariables = new List<mod_Variables>();
    }
    public class mod_Variables
    {
        public string name { get; set; } = "";
        public string type { get; set; } = "";
        public int length { get; set; } = 0;
        public string sign { get; set; } = "";
    }
    public class mod_vcd_TimeScale_Main 
    {
        public List<mod_vcd_TimeScale> lstTimeScale { get; set; } = new List<mod_vcd_TimeScale>();
    }
    public class mod_vcd_TimeScale
    {
        public long timescaleID { get; set; } = 0;
        public string timescale { get; set; } = "";
        public string timedata { get; set; } = "";
        public List<mod_signal_values> lstSignalData = new List<mod_signal_values>();
    }
    public class mod_signal_values
    {
        public string sign { get; set; } = "";
        public string data { get; set; } = "";
    }
}
