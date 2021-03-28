using RevisionProgram2.dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.onlineFeatures
{
    public static class ClientConnect
    {
        public static bool Attempt(TcpClient client, string ip, int port)
        {
            bool closed = false;
            WaitingForm.BeginWait("Connecting to host...", ev =>
            {
                while (!client.Connected)
                {
                    try
                    {
                        client.Connect(ip, port);
                    }
                    catch (SocketException)
                    {
                        if (closed || !ConnectionFailure())
                        {
                            break;
                        }
                    }
                }
            }, () =>
            {
                closed = true;
                client.Close();
                return true;
            });

            if (closed || !client.Connected) return false;

            return true;
        }

        static bool ConnectionFailure() => MsgBox.ShowWait($"Could not connect to recipient." +
                                                           $"{Helper.twoLines}" +
                                                           $"Would you like to try again?",
                                                           "Connection timeout.",
                                                           MsgBox.Options.yesNo,
                                                           MsgBox.MsgIcon.ERROR) == "Yes";
    }
}
