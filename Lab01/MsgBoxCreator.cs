using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public class MsgBoxCreatorEventArgs
    {
        public MsgBoxCreatorEventArgs(string msg) { Msg = msg; }
        public string Msg { get; }
    }
    public delegate void MsgBoxCreatorEventHandler(object? sender, MsgBoxCreatorEventArgs e);

    public interface INotifyMsgBoxCreator
    {
        event MsgBoxCreatorEventHandler? MsgBoxCreator;
    }
}
