import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/common-utils/http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  progress = false;
  addtoMenuModal = false;
  list = [];
  paginatedData = []
  successMsg = ""
  globalAttibute: any;
  search = "";
  constructor(private httpService: HttpService) {   }

  ngOnInit() {
    // this.getGlobalAttributeList();
  }
  blockbtn(e:any) {
    if(e.keyCode == 9 || e.keyCode == 16  ) { return ;}
  }

  getTextList() {
    this.progress = true
    let body = {
      "Text" : this.search
    }
    this.httpService.post("getData", body)
      .subscribe(
        (response) => {
          this.list = response.body   
          this.paginatedData = this.list
          this.progress = false
        },
        (error) => console.log(error)
      );
  }
}

