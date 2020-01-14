import { Injectable } from '@angular/core';
import { Test } from './test.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  readonly rootUrl = 'http://localhost:52059/';
  allTestList : Test[];

  constructor(private http : HttpClient) { }

  getTestList() {
    this.http.get(this.rootUrl+'api/Tests')
    .map((data : any) =>{
      return data as Test[];
    }).toPromise().then(x => {
      this.allTestList = x;
    })
  }
}
