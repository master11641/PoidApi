using System;
using System.Net.Http;

public  class SmsUtil{
     private readonly HttpClient HttpClient;
  public   SmsUtil(){
         HttpClient = new HttpClient ();
     }
   public void Send(string phone,string body){
          var request = new HttpRequestMessage (HttpMethod.Get,
            String.Format ("https://api.kavenegar.com/v1/33735370676E55562B46367761763335756852594966616161416E37387A683547573851336E2F465379513D/verify/lookup.json?receptor={1}&token={0}&template=verify", body, phone));
      //  var response = HttpClient.SendAsync (request);
    }
}