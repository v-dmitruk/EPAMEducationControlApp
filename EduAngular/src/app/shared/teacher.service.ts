import { Injectable } from '@angular/core';
import { Teacher } from './teacher.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  readonly rootUrl = 'http://localhost:52059/';
  allTeacherList : Teacher[];

  constructor(private http : HttpClient) { }

  getTeacherList() {
    this.http.get(this.rootUrl+'api/Teachers')
    .map((data : any) =>{
      return data as Teacher[];
    }).toPromise().then(x => {
      this.allTeacherList = x;
    })
  }
}
