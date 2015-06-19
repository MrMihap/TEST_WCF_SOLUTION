using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ServiceModel;
using Contract;
namespace Server.Core
{
  public class Singleton<T> where T : class
  {
    private static T _instance;

    protected Singleton()
    {
    }

    private static T CreateInstance()
    {
      ConstructorInfo cInfo = typeof(T).GetConstructor(
          new Type[0]);

      return (T)cInfo.Invoke(null);
    }

    public static T Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = CreateInstance();
        }

        return _instance;
      }
    }
  }

  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
  public class CServer : Singleton<CServer>, ICaptureServer
  {
    private List<IDataReciever> SendList = new List<IDataReciever>();
    private object SendListLock = new object();


    void ICaptureServer.Subscribe(IDataReciever reciever)
    {
      lock (SendListLock)
      {
        if (!SendList.Contains(reciever))
          SendList.Add(reciever);
      }
    }
    void ICaptureServer.UnSubscribe(IDataReciever reciever)
    {
      lock (SendListLock)
      {
        if (SendList.Contains(reciever))
          SendList.Remove(reciever);
      }
    }
    public void SendDataToAll(Int16 Data)
    {
      lock (SendListLock)
      {
        foreach (IDataReciever reciever in SendList)
        {
          reciever.RecieveData(Data);
        }
      }
    }
    public event OnRecieverChangedDelegate OnStringRegistered;
  }
}
