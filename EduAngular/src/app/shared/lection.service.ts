import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Lection } from './lection.model';

@Injectable({
  providedIn: 'root'
})
export class LectionService {
  readonly rootUrl = 'http://localhost:52059/';
  allLectionList : Lection[];

  constructor(private http : HttpClient) { }

  getLectionList() {
    this.http.get(this.rootUrl+'api/Lections')
    .map((data : any) =>{
      return data as Lection[];
    }).toPromise().then(x => {
      this.allLectionList = x;
    })
  }
}
