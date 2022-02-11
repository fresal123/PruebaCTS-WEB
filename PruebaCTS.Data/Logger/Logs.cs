using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PruebaCTS.Data.Logger
{
    public class Logs
    {
        private string path = @"D:\PruebaCTS\";

        public void Add(string sLog) 
        {
            CreateDirectory();
            string name = GetNameFile();
            string cadena = "";

            cadena += DateTime.Now + " - " + sLog + Environment.NewLine;

            StreamWriter sw = new StreamWriter(path + "/" + name, true);
            sw.Write(cadena);
            sw.Close();
        }

        private string GetNameFile() 
        {
            string name;
            name = "log_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";
            return name;
        }

        private void CreateDirectory() 
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
