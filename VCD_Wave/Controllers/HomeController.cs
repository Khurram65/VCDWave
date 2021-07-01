using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VCD_Wave.Models;

namespace VCD_Wave.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            Wave obj = new Wave();
            try
            {
                mod_vcd_Main modulelst = new mod_vcd_Main();
                mod_vcd_TimeScale_Main timelst = new mod_vcd_TimeScale_Main();

                string data = Get_URLData_Str("http://192.168.70.5/WebApplication1/VcdReader/GetModuleData?fileid=17");
                DataContractJsonSerializer objs = new DataContractJsonSerializer(typeof(mod_vcd_Main));
                modulelst = (mod_vcd_Main)objs.ReadObject(new MemoryStream(Encoding.ASCII.GetBytes(data)));
                if (modulelst != null && modulelst.lstmodule != null && modulelst.lstmodule.Count != 0)
                {
                    foreach (var item in modulelst.lstmodule)
                    {
                        item.lstvariables = new List<mod_Variables>();
                        if (item.scopevariables.Length != 0)
                        {
                            foreach (var var in item.scopevariables.Split("$end"))
                            {
                                if (var != "")
                                {
                                    mod_Variables v = new mod_Variables();
                                    var d = var.Trim().Split(' ');
                                    v.type = d[1];
                                    v.length = Convert.ToInt32(d[2]);
                                    v.sign = d[3];
                                    v.name = d[4];
                                    item.lstvariables.Add(v);
                                }
                            }
                        }
                    }
                }
                obj.module = modulelst;
                //data = Get_URLData_Str("http://192.168.70.5/WebApplication1/VcdReader/GetTimeScaleData?fileid=18&pageNumber=1&interval=10000");
                //objs = new DataContractJsonSerializer(typeof(mod_vcd_TimeScale_Main));
                //timelst = (mod_vcd_TimeScale_Main)objs.ReadObject(new MemoryStream(Encoding.ASCII.GetBytes(data)));
                //if (timelst != null && timelst.lstTimeScale != null && timelst.lstTimeScale.Count != 0)
                //{
                //    foreach (var item in timelst.lstTimeScale)
                //    {
                //        item.lstSignalData = new List<mod_signal_values>();
                //        if (item.timedata.Length != 0)
                //        {
                //            foreach (var var in item.timedata.Replace("\r", "").Split("\n"))
                //            {
                //                if (var != "" && var != "$dumpvars")
                //                {
                //                    mod_signal_values v = new mod_signal_values();
                //                    var d = var.Replace("b", "").Trim();
                //                    v.sign = d.Substring(d.Length - 1);
                //                    v.data = d.Replace(v.sign, "");
                //                    item.lstSignalData.Add(v);
                //                }
                //            }
                //        }
                //    }
                //}
                //obj.time = timelst;
            }
            catch (Exception ex)
            {

            }
          
            return View(obj);
        }
        public string Get_URLData_Str(string str)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
                webClient.Proxy = null;
                string serviceURL = string.Format(str);
                byte[] data = webClient.DownloadData(serviceURL);
                string result = Encoding.UTF8.GetString(data);
                webClient.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Sample Grid Page
        public IActionResult Grid()
        {
            return View();
        }
        //Sample Grid Page
    }
}
