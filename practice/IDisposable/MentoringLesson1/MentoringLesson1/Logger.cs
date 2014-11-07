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
        private bool disposed;
        
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
            if (disposed) return;

            if (disposing)
            {
                if (memoryStream!=null && streamWriter!=null)
                {
                    
                    streamWriter.Dispose();
                    //Console.WriteLine("Stream Writer Disposed");
                    memoryStream.Dispose();
                    //Console.WriteLine("Memory Stream Disposed");
                    memoryStream =null;
                    streamWriter = null;

                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~MemoryStreamLogger()
        {
            Dispose(false);
        }
    }
}
