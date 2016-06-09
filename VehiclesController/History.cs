using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VehiclesController
{
    public class HistoryOperations
    {
        public IEnumerable<string> ReadAllHistoryLog()
        {
            return this.ReadHistoryLog();
        }

        public IEnumerable<string> SelectLogsEntry(string regNo)
        {
            var parsedRegNo = regNo.ToUpper().Replace(" ", "");
            var logs = this.ReadHistoryLog();

            var pattern = string.Format("| RegNo: {0} |", parsedRegNo);

            return logs.ToList().Where(x => x.Contains(pattern));
        }

        private IEnumerable<string> ReadHistoryLog()
        {
            var path = Path.GetFullPath("history.txt");

            IEnumerable<string> output = new List<string>();

            try
            {
                output = File.ReadLines(path);
            }
            catch (FileNotFoundException)
            {
                output = new List<string> { "Log file with services's history is not created." };
            }
            catch (Exception)
            {
                output = new List<string> { "Problem with reading history file occurred." };
            }

            return output;
        }
    }
}
