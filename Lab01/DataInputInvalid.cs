using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public class DataInputInvalidEventArgs
    {
        public DataInputInvalidEventArgs(string errorMsg) { ErrorMsg = errorMsg; }
        public string ErrorMsg { get; }
    }
    public delegate void DataInputInvalidEventHandler(object? sender, DataInputInvalidEventArgs e);

    public interface INotifyDataInputInvalid
    {
        event DataInputInvalidEventHandler? DataInputInvalid;
    }
}
