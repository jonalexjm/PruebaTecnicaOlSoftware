using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OLSoftware.exportFile.Utils
{
    public class Log
    {
        private string Path = "";
        private string SaltoLine = "\n";

        public Log(string Path)
        {
            this.Path = Path;
        }

        public void Add(string sLog)
        {
            CreateDirectory();

            string nombre = GetNameFile();
            string cadena = "";
            cadena += DateTime.Now + " - " + sLog + Environment.NewLine;

            StreamWriter sw = new StreamWriter(Path + "/" + nombre, true);
            sw.Write(cadena);
            sw.Close();

        }


        #region Helper

        private string GetNameFile()
        {
            string nombre = "";

            nombre = "log_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".log";

            return nombre;
        }

        private bool CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);

                return true;

            }
            catch (DirectoryNotFoundException ex)
            {

                throw new Exception(ex.Message);

                return false;
            }
        }

        #endregion
    }
}
