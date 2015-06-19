using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Contract
{
  [ServiceContract(CallbackContract = typeof(IDataReciever))]
  public interface ICaptureServer
  {
    [OperationContract]
    void Subscribe(IDataReciever reciever);
    [OperationContract]
    void UnSubscribe(IDataReciever reciever);

    event OnRecieverChangedDelegate OnStringRegistered;
  }
  public interface IDataReciever
  {
    void RecieveData(Int16 Data);
  }
  public delegate void OnRecieverChangedDelegate(string value);
}
