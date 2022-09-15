import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class HttpService {
    constructor(private http: HttpClient) { }
    private baseUrl = "";
    getBaseUrl(value: any) {
        this.baseUrl = value
    }

    public notes = ""

    public post(url: string, data: any): Observable<any> {  
      
      // let requestdata: any = window["requestdata"];
      // this.baseUrl = requestdata["url"]


       this.baseUrl = 'https://localhost:7147/'

      return this.http.post<any>(this.baseUrl+url, data,{ observe: 'response' }).pipe(map((response: any) => response))
  
    } 

    // public post(url: string, data: any): Observable<any> {  
    //     if(this.isXsrfTokenRequired(url)){
    //       const token: any = document.getElementById('RequestVerificationToken');
    //       //const headers = {'X-XSRF-TOKEN': token.value}; 
    //       const headers = {'__RequestVerificationToken': token.value}; 
    //       return this.http.post<any>(this.baseUrl+url, data,{ observe: 'response', headers }); 
    //     }
    //     else{
    //       return this.http.post<any>(this.baseUrl+url, data,{ observe: 'response' });
    //     }  
    // } 

    // check the url, which needed XSRF-TOKEN 
    isXsrfTokenRequired(url: string) {
      let requiredUrls = ['searchPropertyAjax1', 'searchPeopleAjax1'];
      let isRequired = false;
      for (let i = 0; i < requiredUrls.length; i++) {
        if(requiredUrls[i]==url){
          isRequired = true;
          break;
        }      
      }
      return isRequired;
    }

    // get XSRF-TOKEN from Cookie, if cookie contains XSRF-TOKEN
    getXsrfTokenFromCookie() {
      let nameEQ = "XSRF-TOKEN=";
      let ca = document.cookie.split(';');
      for(let i=0;i < ca.length;i++) {
        let c = ca[i];
        while (c.charAt(0)==' ') c = c.substring(1,c.length);
        if (c.indexOf(nameEQ) == 0) {
          return c.substring(nameEQ.length,c.length);
        }
      }
      return null;
    }


    public getTaxViewGeneralInfo(){
      // let requestdata: any = window["requestdata"];
      var body = {
        "token": '1234',
      };
  
     return this.post("GetTaxViewGeneralInfo", body).subscribe({
      next: (res) => {
        this.notes = res.body.text

      },
      error: (error) => { console.log(error) }
    });
    }
  
    // getTaxPortalAccountSummary() {
    //   // let requestdata: any = window["requestdata"];
    //   var body = {
    //     "token": '1234',
    //     RollNumber: this.rollNumber
    //   };
  
    //   this.httpService.post("GetTaxPortalAccountSummary", body).subscribe({
    //     next: (res) => {
    //       this.accountSummary = res.body
    //       if(this.accountSummary.taxLevyHistoryList.length === 0 || this.accountSummary.taxLevyHistoryList === null){this.progress = false; return}
    //       let covertChartData = this.accountSummary.taxLevyHistoryList.map((x)=> { return +x.amount.toFixed(2)})
    //       this.asseHisChart = this.chartService.loadBasicBarChart("Tax Levy History", "Year", this.accountSummary.taxYearList, [{  name: 'Tax', data: covertChartData}])
    //       this.showAsseHisChart = true
    //       let covertChartDataPie = [{name:"Region", y: this.accountSummary.taxLevyRegion},{name:"School", y: this.accountSummary.taxLevySchool}, {name:"City", y: this.accountSummary.taxLevyCity}]
    //       this.taxLevyChart = this.chartService.loadPieChart ("Tax Levy Breakdown",  covertChartDataPie ,"")
    //       this,this.showTaxLevyChart = true
  
    //       this.progress = false
    //     },
    //     error: (error) => { console.log(error) }
    //   });
    // }
}