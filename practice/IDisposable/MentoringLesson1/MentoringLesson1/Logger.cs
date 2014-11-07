using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringLesson1
{
    public class MemoryStreamLogger:ILogger,IDisposable
    
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;
      
        
        public MemoryStreamLogger()
        {
            this.memoryStream = new FileStream(@"D:\log.txt",FileMode.OpenOrCreate);
            this.streamWriter = new StreamWriter(memoryStream);
        }

        public void Log(string message)
        {
          
            streamWriter.Write(message);
            streamWriter.Flush();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && memoryStream != null && streamWriter != null)
            {
                streamWriter.Dispose();
                memoryStream.Dispose();

                memoryStream = null;
                streamWriter = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            
        }

      
    }
}
