using System;
using System.Net.Http;

public  class SmsUtil{
     private readonly HttpClient HttpClient;
  public   SmsUtil(){
         HttpClient = new HttpClient ();
     }
   public void Send(string phone,string body){
          var request = new HttpRequestMessage (HttpMethod.Get,
            String.Format ("https://api.kavenegar.com/v1/305158486B4E4332475969725572625657755531744D78686E5A68594A42747731515A4242326F4A6258673D/verify/lookup.json?receptor={1}&token={0}&template=verify", body, phone));
        var response = HttpClient.SendAsync (request);
    }
}